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
    public partial class QuestionsSummary : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataReader ExecuteReader;

        private int MaleCounter = 0;
        private int FemaleCounter = 0;
        private int AgeACounter = 0;
        private int AgeBCounter = 0;
        private int AgeCCounter = 0;
        private int AgeDCounter = 0;
        private int EconomyCounter = 0;
        private int BusinessCounter = 0;
        private int FirstCounter = 0;
        private int AirACounter = 0;
        private int AirBCounter = 0;
        private int AirCCounter = 0;
        private int AirDCounter = 0;
        private int AirECounter = 0;

        private DateTime MinInterval;
        private DateTime MaxInterval;
        private int Counter = 0;

        public QuestionsSummary()
        {
            InitializeComponent();

            UpdateSummary();
        }

        private void importResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionsImport QuestionsImportForm = new QuestionsImport();
            QuestionsImportForm.Show();
        }

        public void UpdateSummary()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand("SELECT * FROM Questions", connection);
                ExecuteReader = cmd.ExecuteReader();
                while (ExecuteReader.Read())
                {
                    if (Counter == 0) MinInterval = Convert.ToDateTime(ExecuteReader["Date"]);
                    else if (Convert.ToDateTime(ExecuteReader["Date"]) < MinInterval) MinInterval = Convert.ToDateTime(ExecuteReader["Date"]);
                    if (Convert.ToDateTime(ExecuteReader["Date"]) > MaxInterval) MaxInterval = Convert.ToDateTime(ExecuteReader["Date"]);

                    Counter++;


                    if (ExecuteReader["Gender"].ToString() == "M") MaleCounter++;
                    else FemaleCounter++;

                    switch (ExecuteReader["CabinType"].ToString())
                    {
                        case "Economy":
                            EconomyCounter++;
                            break;
                        case "Business":
                            BusinessCounter++;
                            break;
                        case "First":
                            FirstCounter++;
                            break;
                    }

                    switch (ExecuteReader["Arrival"].ToString())
                    {
                        case "AUH":
                            AirACounter++;
                            break;
                        case "BAH":
                            AirBCounter++;
                            break;
                        case "DOH":
                            AirCCounter++;
                            break;
                        case "RUH":
                            AirDCounter++;
                            break;
                        case "CAI":
                            AirECounter++;
                            break;
                    }

                    if (Convert.ToInt32(ExecuteReader["Age"]) >= 18 && Convert.ToInt32(ExecuteReader["Age"]) <= 24) AgeACounter++;
                    else if (Convert.ToInt32(ExecuteReader["Age"]) >= 25 && Convert.ToInt32(ExecuteReader["Age"]) <= 39) AgeBCounter++;
                    else if (Convert.ToInt32(ExecuteReader["Age"]) >= 40 && Convert.ToInt32(ExecuteReader["Age"]) <= 59) AgeCCounter++;
                    else AgeDCounter++;
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

            MaleCounter_Label.Text = MaleCounter.ToString();
            FemaleCounter_Label.Text = FemaleCounter.ToString();
            AgeACounter_Label.Text = AgeACounter.ToString();
            AgeBCounter_Label.Text = AgeBCounter.ToString();
            AgeCCounter_Label.Text = AgeCCounter.ToString();
            AgeDCounter_Label.Text = AgeDCounter.ToString();
            EconomyCounter_Label.Text = EconomyCounter.ToString();
            BusinessCounter_Label.Text = BusinessCounter.ToString();
            FirstCounter_Label.Text = FirstCounter.ToString();
            AirACounter_Label.Text = AirACounter.ToString();
            AirBCounter_Label.Text = AirBCounter.ToString();
            AirCCounter_Label.Text = AirCCounter.ToString();
            AirDCounter_Label.Text = AirDCounter.ToString();
            AirECounter_Label.Text = AirECounter.ToString();
            QuestionsSummarySize_Label.Text = "Sample size: " + Counter.ToString();
            QuestionsSummaryInterval_Label.Text = "Fieldwork: " + MinInterval.ToString("MMMM-yyyy") + " - " + MaxInterval.ToString("MMMM-yyyy");
        }

        private void viewSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionsDetails QuestionsDetailsForm = new QuestionsDetails();
            QuestionsDetailsForm.Show();
        }
    }
}
