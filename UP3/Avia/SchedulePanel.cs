using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avia
{
    public partial class SchedulePanel : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet DS;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        private bool DateFlightChanged = false;

        public SchedulePanel()
        {
            InitializeComponent();

            UpdateDataGridSchedules();
        }

        public void UpdateDataGridSchedules()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DS = new DataSet();
                SqlDataAdapter DAShedule = new SqlDataAdapter("SELECT Schedules.Date AS 'Date', Schedules.Time AS 'Time', (SELECT IATACode FROM Airports WHERE ID = Routes.DepartureAirportID) AS 'From', (SELECT IATACode FROM Airports WHERE ID = Routes.ArrivalAirportID) AS 'To', Schedules.FlightNumber AS 'Flight number', Aircrafts.Name AS 'Aircraft', CAST(Schedules.EconomyPrice AS int) AS 'Economy price', FLOOR(Schedules.EconomyPrice+(Schedules.EconomyPrice*0.35)) AS 'Business price', FLOOR(Schedules.EconomyPrice+(Schedules.EconomyPrice*0.30)) AS 'First class price', Schedules.Confirmed, Schedules.ID FROM Schedules INNER JOIN Aircrafts ON Schedules.AircraftID = Aircrafts.ID INNER JOIN Routes ON Schedules.RouteID = Routes.ID", connection);
                DAShedule.Fill(DS);
                ScheduleGrid_View.DataSource = DS.Tables[0];

                foreach (DataGridViewRow row in ScheduleGrid_View.Rows)
                {
                    if (row.Cells[9].Value.ToString() == "False") row.DefaultCellStyle.BackColor = Color.Red;
                    else row.DefaultCellStyle.BackColor = Color.White;
                }

                DataSet DSFrom = new DataSet();
                SqlDataAdapter DAFrom = new SqlDataAdapter("SELECT IATACode FROM Airports", connection);
                DAFrom.Fill(DSFrom);
                DSFrom.Tables[0].Rows.Add("");

                DataSet DSTo = new DataSet();
                SqlDataAdapter DATo = new SqlDataAdapter("SELECT IATACode FROM Airports", connection);
                DATo.Fill(DSTo);
                DSTo.Tables[0].Rows.Add("");

                ScheduleFrom_ComboBox.DataSource = DSFrom.Tables[0];
                ScheduleFrom_ComboBox.DisplayMember = "IATACode";
                ScheduleFrom_ComboBox.ValueMember = "IATACode";

                ScheduleTo_ComboBox.DataSource = DSTo.Tables[0];
                ScheduleTo_ComboBox.DisplayMember = "IATACode";
                ScheduleTo_ComboBox.ValueMember = "IATACode";

                ScheduleFrom_ComboBox.SelectedIndex = ScheduleFrom_ComboBox.Items.Count - 1;
                ScheduleTo_ComboBox.SelectedIndex = ScheduleTo_ComboBox.Items.Count - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ScheduleSortApply_Btn_Click(object sender, EventArgs e)
        {
            int FilterCounter = 0;
            if (ScheduleFrom_ComboBox.SelectedValue.ToString().Length > 0) (ScheduleGrid_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("From = '{0}'", ScheduleFrom_ComboBox.SelectedValue.ToString());
            else FilterCounter++;
            if (ScheduleTo_ComboBox.SelectedValue.ToString().Length > 0) (ScheduleGrid_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("To = '{0}'", ScheduleTo_ComboBox.SelectedValue.ToString());
            else FilterCounter++;
            if (ScheduleFlightNumber_Box.Text.Length > 0) (ScheduleGrid_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("`Flight number` = '{0}'", ScheduleFlightNumber_Box.Text);
            else FilterCounter++;
            if (DateFlightChanged) (ScheduleGrid_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("Date = '{0}'", ScheduleOutbound_Picker.Value.ToShortDateString());
            else FilterCounter++;
            if (FilterCounter == 4 && !DateFlightChanged) (ScheduleGrid_View.DataSource as DataTable).DefaultView.RowFilter = null;

            switch (ScheduleSortBy_ComboBox.SelectedIndex) {
                    case 0:
                        ScheduleGrid_View.Sort(ScheduleGrid_View.Columns["Date"], ListSortDirection.Descending);
                        break;
                    case 1:
                        ScheduleGrid_View.Sort(ScheduleGrid_View.Columns["Date"], ListSortDirection.Ascending);
                        break;
                    case 2:
                        ScheduleGrid_View.Sort(ScheduleGrid_View.Columns["Economy price"], ListSortDirection.Ascending);
                        break;
                    case 3:
                        ScheduleGrid_View.Sort(ScheduleGrid_View.Columns["Confirmed"], ListSortDirection.Ascending);
                        break;
                }
            DateFlightChanged = false;
        }

        private void ScheduleOutbound_Picker_ValueChanged(object sender, EventArgs e)
        {
            DateFlightChanged = true;
        }

        private void ScheduleCancelFlight_Btn_Click(object sender, EventArgs e)
        {
            string TempFlightActive = "";
            if (ScheduleGrid_View.SelectedRows[0].Cells[9].Value.ToString() == "True") TempFlightActive = "False";
            else TempFlightActive = "True";

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("UPDATE Schedules SET Confirmed='{0}' WHERE ID='{1}'", TempFlightActive, ScheduleGrid_View.SelectedRows[0].Cells[10].Value), connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            UpdateDataGridSchedules();
        }

        private void ScheduleEditFlight_Btn_Click(object sender, EventArgs e)
        {
            ScheduleEdit ScheduleEditForm = new ScheduleEdit(ScheduleGrid_View.CurrentRow.Cells[10].Value.ToString(), ScheduleGrid_View.CurrentRow.Cells[2].Value.ToString(), ScheduleGrid_View.CurrentRow.Cells[3].Value.ToString(), ScheduleGrid_View.CurrentRow.Cells[5].Value.ToString(), ScheduleGrid_View.CurrentRow.Cells[0].Value.ToString(), ScheduleGrid_View.CurrentRow.Cells[1].Value.ToString(), ScheduleGrid_View.CurrentRow.Cells[6].Value.ToString());
            ScheduleEditForm.Show();
        }

        private void ScheduleImport_Btn_Click(object sender, EventArgs e)
        {
            ImportSchedule ImportScheduleForm = new ImportSchedule();
            ImportScheduleForm.Show();
        }
    }
}

/* 
 * импорт
 */