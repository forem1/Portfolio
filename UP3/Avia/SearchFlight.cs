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
    public partial class SearchFlight : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        private bool Returning = false;
        private int UserID = 0;

        public SearchFlight(int UID)
        {
            InitializeComponent();
            UserID = UID;

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSFrom = new DataSet();
                SqlDataAdapter DAFrom = new SqlDataAdapter("SELECT IATACode FROM Airports", connection);
                DAFrom.Fill(DSFrom);
                DSFrom.Tables[0].Rows.Add("");

                DataSet DSTo = new DataSet();
                SqlDataAdapter DATo = new SqlDataAdapter("SELECT IATACode FROM Airports", connection);
                DATo.Fill(DSTo);
                DSTo.Tables[0].Rows.Add("");

                DataSet DSCabin = new DataSet();
                SqlDataAdapter DACabin = new SqlDataAdapter("SELECT * FROM CabinTypes", connection);
                DACabin.Fill(DSCabin);

                SearchParametersFrom_Combobox.DataSource = DSFrom.Tables[0];
                SearchParametersFrom_Combobox.DisplayMember = "IATACode";
                SearchParametersFrom_Combobox.ValueMember = "IATACode";

                SearchParametersTo_Combobox.DataSource = DSTo.Tables[0];
                SearchParametersTo_Combobox.DisplayMember = "IATACode";
                SearchParametersTo_Combobox.ValueMember = "IATACode";

                SearchParametersCabin_Combobox.DataSource = DSCabin.Tables[0];
                SearchParametersCabin_Combobox.DisplayMember = "Name";
                SearchParametersCabin_Combobox.ValueMember = "ID";

                SearchParametersFrom_Combobox.SelectedIndex = SearchParametersFrom_Combobox.Items.Count - 1;
                SearchParametersTo_Combobox.SelectedIndex = SearchParametersTo_Combobox.Items.Count - 1;

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

        private void SearchCancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchParametersApply_Btn_Click(object sender, EventArgs e)
        {
            Returning = false;
            int CountCabinPrice = 0;
            string LowDateOutbound = "";
            string HighDateOutbound = "";
            string LowDateReturn = "";
            string HighDateReturn = "";

            switch (SearchParametersCabin_Combobox.SelectedIndex)
            {
                case 0:
                    CountCabinPrice = 0;
                    break;
                case 1:
                    CountCabinPrice = 35;
                    break;
                case 2:
                    CountCabinPrice = 30;
                    break;
            }

            if(SearchOutboundThree_Check.Checked)
            {
                LowDateOutbound = SearchParametersOutbound_Picker.Value.AddDays(-3).ToShortDateString();
                HighDateOutbound = SearchParametersOutbound_Picker.Value.AddDays(3).ToShortDateString();
            }
            else
            {
                LowDateOutbound = SearchParametersOutbound_Picker.Value.ToShortDateString();
                HighDateOutbound = SearchParametersOutbound_Picker.Value.ToShortDateString();
            }

            if (SearchReturnThree_Check.Checked)
            {
                LowDateReturn = SearchParametersReturn_Picker.Value.AddDays(-3).ToShortDateString();
                HighDateReturn = SearchParametersReturn_Picker.Value.AddDays(3).ToShortDateString();
            }
            else
            {
                LowDateReturn = SearchParametersReturn_Picker.Value.ToShortDateString();
                HighDateReturn = SearchParametersReturn_Picker.Value.ToShortDateString();
            }

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSSearchFrom = new DataSet();
                SqlDataAdapter DASearchFrom = new SqlDataAdapter(string.Format("SELECT '{0}' AS 'From', '{1}' AS 'To', Schedules.Date AS 'Date', Schedules.Time AS 'Time', Schedules.FlightNumber AS 'Flight number', FLOOR(Schedules.EconomyPrice+(Schedules.EconomyPrice/100*{2})) AS 'Cabin price', '0' AS 'Number of stops', Schedules.ID FROM Schedules WHERE Date >= '{3}' AND Date <= '{4}' AND RouteID = (SELECT ID FROM Routes WHERE DepartureAirportID = (SELECT ID FROM Airports WHERE IATACode = '{0}') AND ArrivalAirportID = (SELECT ID FROM Airports WHERE IATACode = '{1}'))", SearchParametersFrom_Combobox.SelectedValue, SearchParametersTo_Combobox.SelectedValue, CountCabinPrice, LowDateOutbound, HighDateOutbound), connection);
                DASearchFrom.Fill(DSSearchFrom);
                SearchOutboundGrid_View.DataSource = DSSearchFrom.Tables[0];

                if (SearchParametersReturn_Radio.Checked)
                {
                    Returning = true;
                    DataSet DSSearchReturn = new DataSet();
                    SqlDataAdapter DASearchReturn = new SqlDataAdapter(string.Format("SELECT '{0}' AS 'From', '{1}' AS 'To', Schedules.Date AS 'Date', Schedules.Time AS 'Time', Schedules.FlightNumber AS 'Flight number', FLOOR(Schedules.EconomyPrice+(Schedules.EconomyPrice/100*{2})) AS 'Cabin price', '0' AS 'Number of stops', Schedules.ID FROM Schedules WHERE Date >= '{3}' AND Date <= '{4}' AND RouteID = (SELECT ID FROM Routes WHERE DepartureAirportID = (SELECT ID FROM Airports WHERE IATACode = '{0}') AND ArrivalAirportID = (SELECT ID FROM Airports WHERE IATACode = '{1}'))", SearchParametersTo_Combobox.SelectedValue, SearchParametersFrom_Combobox.SelectedValue, CountCabinPrice, LowDateReturn, HighDateReturn), connection);
                    DASearchReturn.Fill(DSSearchReturn);
                    SearchReturnGrid_View.DataSource = DSSearchReturn.Tables[0];
                }
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

        private void SearchBook_Btn_Click(object sender, EventArgs e)
        {
            string ReturnDate = "";
            string ReturnNumber = "";
            int ReturnCost = 0;
            string ReturnSchID = "";
            if (SearchReturnGrid_View.CurrentRow != null)
            {
                ReturnDate = SearchReturnGrid_View.CurrentRow.Cells[2].Value.ToString().Remove(SearchReturnGrid_View.CurrentRow.Cells[2].Value.ToString().Length-8);
                ReturnNumber = SearchReturnGrid_View.CurrentRow.Cells[4].Value.ToString();
                ReturnCost = Convert.ToInt32(SearchReturnGrid_View.CurrentRow.Cells[5].Value);
                ReturnSchID = SearchReturnGrid_View.CurrentRow.Cells[7].Value.ToString();
            }


            if (SearchPassengers_Box.Text.Length > 0 && SearchOutboundGrid_View.CurrentRow.Cells[0].Value.ToString().Length > 0)
            {
                BookingFlight BookingFlightForm = new BookingFlight(SearchParametersFrom_Combobox.SelectedValue.ToString(), SearchParametersTo_Combobox.SelectedValue.ToString(), Convert.ToInt32(SearchParametersCabin_Combobox.SelectedValue), SearchOutboundGrid_View.CurrentRow.Cells[2].Value.ToString().Remove(SearchOutboundGrid_View.CurrentRow.Cells[2].Value.ToString().Length-8), ReturnDate, SearchOutboundGrid_View.CurrentRow.Cells[4].Value.ToString(), ReturnNumber, Returning, Convert.ToInt32(SearchOutboundGrid_View.CurrentRow.Cells[5].Value), ReturnCost, SearchOutboundGrid_View.CurrentRow.Cells[7].Value.ToString(), ReturnSchID, UserID);
                BookingFlightForm.Show();
            }
            else MessageBox.Show("Enter number of passengers or select flight");
        }
    }
}
