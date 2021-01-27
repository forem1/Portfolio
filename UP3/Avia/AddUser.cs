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
    public partial class AddUser : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;

        public AddUser()
        {
            InitializeComponent();

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSOffices = new DataSet();
                SqlDataAdapter DAOffices = new SqlDataAdapter("SELECT * FROM Offices", connection);
                DAOffices.Fill(DSOffices);

                AddUserOffice_Combobox.DataSource = DSOffices.Tables[0];
                AddUserOffice_Combobox.DisplayMember = "Title";
                AddUserOffice_Combobox.ValueMember = "Title";
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

        private void AddUserSave_Btn_Click(object sender, EventArgs e)
        {
            if(AddUserEmail_Box.Text.Length > 0 && AddUserName_Box.Text.Length > 0 && AddUserLastname_Box.Text.Length > 0 && AddUserPassword_Box.Text.Length > 0 && AddUserBirthdate_Picker.Value < DateTime.Now)
            {
                byte[] hash = Encoding.ASCII.GetBytes(AddUserPassword_Box.Text);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hashenc = md5.ComputeHash(hash);
                string SecurePass = "";
                foreach (var b in hashenc)
                {
                    SecurePass += b.ToString("x2");
                }

                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO Users (RoleID, Email, Password, FirstName, LastName, OfficeID, Birthdate, Active) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", 1, AddUserEmail_Box.Text, SecurePass, AddUserName_Box.Text, AddUserLastname_Box.Text, 1, AddUserBirthdate_Picker.Value.ToShortDateString(), "True"), connection);
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
                (Application.OpenForms["AdminPanel"] as AdminPanel).UpdateDataGridUsers();
                this.Close();
            }
            else MessageBox.Show("Not all fields are filled");
        }

        private void AddUserCancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
