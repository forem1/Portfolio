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
    public partial class UserPanel : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet DS;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        bool ExitOK = false;
        int UserID = 0;
        string UserName = "";

        public UserPanel(int id, string name)
        {
            InitializeComponent();
            UserID = id;
            UserName = name;

            UpdateDataGridUsers();
            SaveExit();

            UserPanelWelcome_Label.Text = "Hi " + UserName + ", Welcome to AMONIC Airlines.";
        }

        public void UpdateDataGridUsers()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DS = new DataSet();
                SqlDataAdapter DAUser = new SqlDataAdapter(String.Format("SELECT Tracks.Date AS Date, Tracks.Login AS 'Login time', Tracks.Logout AS 'Logout time',  DATEDIFF (minute, Tracks.Login, Tracks.Logout) AS 'Time spent on system',Tracks.Reason AS 'Unsuccessful logout reason' FROM Tracks WHERE UserID = {0} AND ExitOK = 'True'", UserID), connection);
                DAUser.Fill(DS);
                UserGridUser_View.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            int ErrorCounter = 0;
            int SpendTime = 0;
            foreach (DataGridViewRow row in UserGridUser_View.Rows)
            {
                if (row.Cells[4].Value.ToString().Length > 0) ErrorCounter++;
                if (row.Cells[3].Value.ToString().Length > 0) SpendTime += Convert.ToInt32(row.Cells[3].Value);
            }
            UserPanelErrors_Label.Text = "Number of crashes: " + ErrorCounter.ToString();
            UserPanelTime_Label.Text = "Time spent on system: " + SpendTime.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveExit();
        }


        private void SaveExit()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("SELECT * FROM Tracks WHERE UserID={0}", UserID), connection);
                ExecuteReader = cmd.ExecuteReader();
                while (ExecuteReader.Read())
                {
                    if (ExecuteReader["ExitOK"].ToString() == "False" && !ExitOK)
                    {
                        ExitReason ExitReasonForm = new ExitReason(ExecuteReader["ID"].ToString(), ExecuteReader["Date"].ToString(), ExecuteReader["Login"].ToString());
                        ExitReasonForm.Show();
                    }
                }
                ExecuteReader.Close();


                if (!ExitOK)
                {
                    cmd = new SqlCommand(String.Format("INSERT INTO Tracks (UserID, Date, Login, Logout, ExitOK, Reason) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", UserID, DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), null, "False", null), connection);
                    cmd.ExecuteNonQuery();
                    ExitOK = true;
                }
                else
                {
                    cmd = new SqlCommand(String.Format("UPDATE Tracks SET Logout='{0}', ExitOK='{1}' WHERE UserID={2} AND ID = (SELECT MAX(ID) FROM Users)", DateTime.Now.ToString("HH:mm:ss"), "True", UserID), connection);
                    cmd.ExecuteNonQuery();
                    Application.Exit();
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

        private void searchFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchFlight SearchFlightForm = new SearchFlight(UserID);
            SearchFlightForm.Show();
        }

        private void userFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionsSummary QuestionsSummaryForm = new QuestionsSummary();
            QuestionsSummaryForm.Show();
        }

        private void amenitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmenitiesPurchase AmenitiesPurchaseForm = new AmenitiesPurchase();
            AmenitiesPurchaseForm.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmenitiesReport AmenitiesReportForm = new AmenitiesReport();
            AmenitiesReportForm.Show();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Summary SummaryForm = new Summary();
            SummaryForm.Show();
        }
    }
}
