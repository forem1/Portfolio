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
    public partial class QuestionsDetails : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataReader ExecuteReader;

        private string[] QuestionList = { "Please rate our aircraft flown on AMONIC Airlines", "How would you rate our flight attendants", "How would you rate our inflight entertainment", "Please rate the ticket price for the trip you are taking" };
        private string[] MarkList = { "Outstanding", "Very Good", "Good", "Adequate", "Needs Improvement", "Poor", "Don’t know" };
        private string[] QueryList = {
            "Gender = 'M'",
            "Gender = 'F'",
            "Age > 18 AND Age < 24",
            "Age > 25 AND Age < 39",
            "Age > 40 AND Age < 59",
            "Age < 60",
            "CabinType = 'Economy'",
            "CabinType = 'Business'",
            "CabinType = 'First'",
            "Arrival = 'AUH'",
            "Arrival = 'BAH'",
            "Arrival = 'DOH'",
            "Arrival = 'RUH'",
            "Arrival = 'CAI'"
        };
        private string QuerySearchDate = "";

        public QuestionsDetails()
        {
            InitializeComponent();

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSDate = new DataSet();
                SqlDataAdapter DADate = new SqlDataAdapter("SELECT DISTINCT Date FROM Questions ORDER BY Date DESC", connection);
                DADate.Fill(DSDate);
                DSDate.Tables[0].Rows.Add(new DateTime());

                QuestionsDetailsDate_Combo.DataSource = DSDate.Tables[0];
                QuestionsDetailsDate_Combo.DisplayMember = "Date";
                QuestionsDetailsDate_Combo.ValueMember = "Date";
                QuestionsDetailsDate_Combo.SelectedIndex = QuestionsDetailsDate_Combo.Items.Count - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            ReCountGrid();
        }

        public void ReCountGrid()
        {
            int NumberOfQuestion = 1;
            int RowsCounter = 0;
            QuestionsGrid_View.Rows.Clear();

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                for (int i = 0; i < 4; i++)
                {
                    QuestionsGrid_View.Rows.Add(new object[] { QuestionList[i] });
                    QuestionsGrid_View.Rows[RowsCounter].DefaultCellStyle.BackColor = Color.Yellow;
                    RowsCounter++;

                    for (int j = 0; j < 7; j++)
                    {
                        QuestionsGrid_View.Rows.Add(MarkList[j]);

                        for (int k = 0; k < 14; k++)
                        {
                            cmd = new SqlCommand(string.Format("SELECT Count(*) FROM Questions WHERE Q{0} = {1} AND {2} {3}", NumberOfQuestion, j + 1, QueryList[k], QuerySearchDate), connection);
                            ExecuteReader = cmd.ExecuteReader();

                            while (ExecuteReader.Read())
                            {
                                QuestionsGrid_View.Rows[RowsCounter].Cells[k + 2].Value = ExecuteReader[""].ToString();
                            }

                            ExecuteReader.Close();
                        }

                        QuestionsGrid_View.Rows[RowsCounter].Cells[1].Value = Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[2].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[3].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[4].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[5].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[6].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[7].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[8].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[9].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[10].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[11].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[12].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[13].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[14].Value) + Convert.ToInt32(QuestionsGrid_View.Rows[RowsCounter].Cells[15].Value);
                        RowsCounter++;
                    }

                    NumberOfQuestion++;

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuestionsDetailsApply_Btn_Click(object sender, EventArgs e)
        {
            if (QuestionsDetailsDate_Combo.SelectedIndex != QuestionsDetailsDate_Combo.Items.Count - 1)
            {
                DateTime LowEdge = Convert.ToDateTime(QuestionsDetailsDate_Combo.SelectedValue);
                DateTime HighEdge = Convert.ToDateTime(QuestionsDetailsDate_Combo.SelectedValue).AddMonths(1);

                QuerySearchDate = "AND DATE >= '" + LowEdge.AddDays(-LowEdge.Day + 1).ToShortDateString() + "' AND DATE < '" + HighEdge.AddDays(-LowEdge.Day + 1).ToShortDateString()+"'";
                //MessageBox.Show(QuerySearchDate);
            }
            else QuerySearchDate = "";

            ReCountGrid();
        }
    }
}
