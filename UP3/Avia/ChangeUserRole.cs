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
    public partial class ChangeUserRole : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        int TempRole = 0;
        int UserID = 0;

        public ChangeUserRole(string Email, string FirstName, string LastName, string Office, string Role, string id)
        {
            InitializeComponent();

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSOffices = new DataSet();
                SqlDataAdapter DAOffices = new SqlDataAdapter("SELECT * FROM Offices", connection);
                DAOffices.Fill(DSOffices);

                UpdateUserOffice_Combobox.DataSource = DSOffices.Tables[0];
                UpdateUserOffice_Combobox.DisplayMember = "Title";
                UpdateUserOffice_Combobox.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            UserID = Convert.ToInt32(id);
            UpdateUserEmail_Box.Text = Email;
            UpdateUserName_Box.Text = FirstName;
            UpdateUserLastname_Box.Text = LastName;
            UpdateUserOffice_Combobox.SelectedIndex = UpdateUserOffice_Combobox.FindString(Office); //Доделать
            if (Role == "Administrator") UpdateUserAdm_Radio.Checked = true;
            else UpdateUserUsr_Radio.Checked = true;
        }

        private void UpdateUserApply_Btn_Click(object sender, EventArgs e)
        {
            if (UpdateUserEmail_Box.Text.Length > 0 && UpdateUserName_Box.Text.Length > 0 && UpdateUserLastname_Box.Text.Length > 0)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Users SET Email='{0}', FirstName='{1}', LastName='{2}', OfficeID='{3}', RoleID={4} WHERE ID={5}", UpdateUserEmail_Box.Text, UpdateUserName_Box.Text, UpdateUserLastname_Box.Text, UpdateUserOffice_Combobox.SelectedValue, TempRole, UserID), connection);
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

        private void UpdateUserCancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateUserUsr_Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked) TempRole = 2;
        }

        private void UpdateUserAdm_Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked) TempRole = 1;
        }
    }
}
