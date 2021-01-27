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
    public partial class ScheduleEdit : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;

        int UserID = 0;

        public ScheduleEdit(string id, string from, string to, string aircraft, string date, string time, string price)
        {
            InitializeComponent();

            UserID = Convert.ToInt32(id);

            UpdateScheduleFrom_Label.Text = "From: " + from;
            UpdateScheduleTo_Label.Text = "To: " + to;
            UpdateScheduleAircraft_Label.Text = "Aircraft: " + aircraft;
            UpdateScheduleDate_Picker.Value = Convert.ToDateTime(date);
            UpdateScheduleTime_Picker.Value = Convert.ToDateTime(time);
            UpdateSchedulePrice_Box.Text = price;
        }

        private void UpdateScheduleCancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateScheduleApply_Btn_Click(object sender, EventArgs e)
        {
            if (UpdateSchedulePrice_Box.Text.Length > 0)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Schedules SET Date='{0}', Time='{1}', EconomyPrice='{2}' WHERE ID={3}", UpdateScheduleDate_Picker.Value.ToShortDateString(), UpdateScheduleTime_Picker.Value.ToShortTimeString(), UpdateSchedulePrice_Box.Text, UserID), connection);
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
                (Application.OpenForms["SchedulePanel"] as SchedulePanel).UpdateDataGridSchedules();
                this.Close();
            }
            else MessageBox.Show("Not all fields are filled");
        }
    }
}
