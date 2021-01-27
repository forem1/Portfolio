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
    public partial class Summary : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet DS;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        public Summary()
        {
            InitializeComponent();

            int ConfirmedFlightCounter = 0;
            int CancelledFlightCounter = 0;
            int[] AverageFlightCounter =  new int[20000];
            DateTime LowDate;
            DateTime HighDate;

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                cmd = new SqlCommand(String.Format("Select Schedules.Confirmed AS 'ConfirmedFlight', FlightTime, Date From Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID INNER JOIN Routes ON Schedules.RouteID = Routes.ID WHERE Date <= GETDATE() AND Date > dateadd(day, -30, getdate())"), connection);
                ExecuteReader = cmd.ExecuteReader();
                int CounterArray = 0;
                while (ExecuteReader.Read())
                {
                    if (ExecuteReader["ConfirmedFlight"].ToString() == "True") ConfirmedFlightCounter++;
                    else CancelledFlightCounter++;

                    AverageFlightCounter[CounterArray] = Convert.ToInt32(ExecuteReader["FlightTime"]);


                    CounterArray++;
                }
                ExecuteReader.Close();

                int FlightTimeResult = 0;
                for (int i = 0; i < CounterArray; i++)
                {
                    FlightTimeResult += AverageFlightCounter[i];
                }
                FlightTimeResult = FlightTimeResult / CounterArray;

                SummaryFlightsCancelled_Label.Text = "Number confirmed: " + ConfirmedFlightCounter.ToString();
                SummaryFlightsCancelled_Label.Text = "Number cancelled: " + CancelledFlightCounter.ToString();
                SummaryFlightsTime_Label.Text = "Average flight time: " + FlightTimeResult.ToString() + "mins";
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

        private void SummaryExit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
