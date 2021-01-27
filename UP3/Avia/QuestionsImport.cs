using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avia
{
    public partial class QuestionsImport : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;

        private bool FirstIterate = false;
        private string[] Questions;

        public QuestionsImport()
        {
            InitializeComponent();
        }

        private void ImportQuestionsOpen_Btn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "schedule Files|*.csv";
            dialog.Title = "Select schedule files";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != null)
                {
                    ImportQuestionsPath_Box.Text = dialog.FileName;

                    Questions = File.ReadAllLines(dialog.FileName);
                }
            }
        }

        private void ImportQuestionsImport_Btn_Click(object sender, EventArgs e)
        {
            if(Questions.Length > 0)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();

                    foreach (string Row in Questions)
                    {
                        if (FirstIterate)
                        {
                            string[] ParsedRow = Row.Split(',');
                            cmd = new SqlCommand(String.Format("INSERT INTO Questions (Date, Departure, Arrival, Age, Gender, CabinType, Q1, Q2, Q3, Q4) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", ImportQuestionsDate_Picker.Value.ToString(), ParsedRow[0], ParsedRow[1], ParsedRow[2], ParsedRow[3], ParsedRow[4], ParsedRow[5], ParsedRow[6], ParsedRow[7], ParsedRow[8]), connection);
                            cmd.ExecuteNonQuery();
                        }

                        FirstIterate = true;
                    }

                    MessageBox.Show("Success!");
                    (Application.OpenForms["QuestionsSummary"] as QuestionsSummary).UpdateSummary();
                    this.Close();
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
            else MessageBox.Show("Read file error!");
        }
    }
}
