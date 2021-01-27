using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avia
{
    public partial class Login : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataReader ExecuteReader;

        public int EnterCounter = 0;
        Timer Tm = null;
        public int StartValue = 0;

        public Login()
        {
            InitializeComponent();

            Tm = new Timer();
            Tm.Tick += new EventHandler(Tm_Tick);
            Tm.Interval = 1000;

            //AdminPanel AdminForm = new AdminPanel(1);
            //AdminForm.Show(); //test

            //UserPanel UserForm = new UserPanel(1, "Henry");
            //UserForm.Show(); //test

            //SchedulePanel ShedulePanelForm = new SchedulePanel();
            //ShedulePanelForm.Show(); //test

            //SearchFlight SearchFlightForm = new SearchFlight(1);
            //SearchFlightForm.Show(); //test

            //BookingFlight BookingFlight = new BookingFlight("ASD","DSA",1,"1","2","3","4", true, 100,200,"5","6",1);
            //BookingFlight.Show(); //test

            QuestionsSummary QuestionsSummary = new QuestionsSummary();
            QuestionsSummary.Show(); //test

            QuestionsDetails QuestionsDetailsForm = new QuestionsDetails();
            QuestionsDetailsForm.Show();

            //AmenitiesPurchase AmenitiesPurchase = new AmenitiesPurchase();
            //AmenitiesPurchase.Show();

            //AmenitiesReport AmenitiesReportForm = new AmenitiesReport();
            //AmenitiesReportForm.Show();

            //Summary Summary = new Summary();
            //Summary.Show();
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            if (PasswordEnter_Box.Text.Length > 0 && LoginEnter_Box.Text.Length > 0)
            {
                byte[] hash = Encoding.ASCII.GetBytes(PasswordEnter_Box.Text);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hashenc = md5.ComputeHash(hash);
                string SecurePass = "";
                foreach (var b in hashenc)
                {
                    SecurePass += b.ToString("x2");
                }
                //MessageBox.Show(SecurePass);

                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("SELECT * FROM Users WHERE Email='{0}'", LoginEnter_Box.Text), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read())
                    {
                        if (ExecuteReader["Active"].ToString() != "False")
                        {
                            if (ExecuteReader["Password"].ToString() == SecurePass)
                            {
                                if (ExecuteReader["RoleID"].ToString() == "1")
                                {
                                    AdminPanel AdminForm = new AdminPanel(Convert.ToInt32(ExecuteReader["ID"]));
                                    AdminForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    UserPanel UserForm = new UserPanel(Convert.ToInt32(ExecuteReader["ID"]), ExecuteReader["FirstName"].ToString());
                                    UserForm.Show();
                                    this.Hide();
                                }
                            }
                            else {
                                EnterCounter++;
                                MessageBox.Show("Incorrect login or password");

                                if(EnterCounter == 3)
                                {
                                    Login_Btn.Enabled = false;

                                    StartValue = 10;
                                    Tm.Start();
                                }
                            }
                        }
                        else MessageBox.Show("Account was deactivated");
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
            else MessageBox.Show("Not all fields are filled");
        }

        void Tm_Tick(object sender, EventArgs e)
        {
            if (StartValue != 0)
            {
                Login_Btn.Text = (StartValue - (StartValue - (StartValue % (60 * 60))) / (60 * 60) * 60 * 60 - (StartValue - StartValue % 60) / 60 - (StartValue - (StartValue % (60 * 60))) / (60 * 60) * 60 * 60).ToString();
                StartValue--;
            }
            else
            {
                (sender as Timer).Stop();
                (sender as Timer).Dispose();
                Login_Btn.Text = "Login";
                Login_Btn.Enabled = true;
                EnterCounter = 0;
            }
        }

        private void ExitLogin_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

/* 
 * Включить авторизацию
 * 
 * 
 * 
 * 
 * 
 */
