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
    public partial class ExitReason : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;

        int ProblemID = 0;
        string TempReason = "";

        const string MainText = "No logout detected for you last login on: ";
        public ExitReason(string ID, string Date, string Login)
        {
            ProblemID = Convert.ToInt32(ID);
            InitializeComponent();

            NoLogoutText_Label.Text = MainText + Date + Login;
        }

        private void NoLogoutConfirm_Btn_Click(object sender, EventArgs e)
        {
            if (NoLogoutReason_Box.Text.Length > 0)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Tracks SET ExitOK='{0}', Reason='{1}' WHERE ID={2}", "True", TempReason + NoLogoutReason_Box.Text, ProblemID), connection);
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
                this.Close();
            }
            else MessageBox.Show("Not all fields are filled");
        }

        private void NoLogoutSoft_Radio_CheckedChanged(object sender, EventArgs e)
        {
            TempReason = "Software : ";
        }

        private void NoLogoutHard_Radio_CheckedChanged(object sender, EventArgs e)
        {
            TempReason = "Hardware : ";
        }
    }
}
