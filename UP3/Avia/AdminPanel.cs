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
    public partial class AdminPanel : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet DS;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        int StartupCounter = 0;
        bool ExitOK = false;

        int UserID = 0;

        public AdminPanel(int id)
        {
            UserID = id;
            InitializeComponent();
            UpdateDataGridUsers();
            SaveExit();
        }

        public void UpdateDataGridUsers()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DS = new DataSet();
                SqlDataAdapter DAUserAdmin = new SqlDataAdapter("SELECT Users.FirstName AS Name, Users.LastName, DATEDIFF( year, Users.Birthdate, getDate() ) AS Age, Roles.Title AS 'User Role', Users.Email AS Email, Offices.Title AS Office, Users.Active, Users.ID FROM Users INNER JOIN Offices ON Users.OfficeID = Offices.ID INNER JOIN Roles ON Users.RoleID = Roles.ID", connection);
                DAUserAdmin.Fill(DS);
                UserGridAdmin_View.DataSource = DS.Tables[0];

                foreach (DataGridViewRow row in UserGridAdmin_View.Rows)
                {
                    if (row.Cells[6].Value.ToString() == "False") row.DefaultCellStyle.BackColor = Color.Red;
                    else row.DefaultCellStyle.BackColor = Color.White;
                }

                DataSet DSOffices = new DataSet();
                SqlDataAdapter DAOffices = new SqlDataAdapter("SELECT DISTINCT Users.OfficeID, Offices.Title, Offices.ID FROM Users INNER JOIN Offices  ON Users.OfficeID = Offices.ID", connection);
                DAOffices.Fill(DSOffices);
                DSOffices.Tables[0].Rows.Add(new object[] { null, "All offices" });

                SelectOfficesAdmin_ComboBox.DataSource = DSOffices.Tables[0];
                SelectOfficesAdmin_ComboBox.DisplayMember = "Title";
                SelectOfficesAdmin_ComboBox.ValueMember = "Title";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            SelectOfficesAdmin_ComboBox.SelectedIndex = SelectOfficesAdmin_ComboBox.Items.Count - 1;
        }

        private void SelectOfficesAdmin_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectOfficesAdmin_ComboBox.SelectedValue.ToString() == "All offices") (UserGridAdmin_View.DataSource as DataTable).DefaultView.RowFilter = null;
                else (UserGridAdmin_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("Office = '{0}'", SelectOfficesAdmin_ComboBox.SelectedValue.ToString());
                if (StartupCounter < 2)
                {
                    StartupCounter++;
                    (UserGridAdmin_View.DataSource as DataTable).DefaultView.RowFilter = null;
                    SelectOfficesAdmin_ComboBox.SelectedIndex = SelectOfficesAdmin_ComboBox.Items.Count - 1;
                }
            }
            catch { }
        }

        private void ChangeActivateAdmin_Btn_Click(object sender, EventArgs e)
        {
            string TempUserActive = "";
            if (UserGridAdmin_View.SelectedRows[0].Cells[6].Value.ToString() == "True") TempUserActive = "False";
            else TempUserActive = "True";

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("UPDATE Users SET Active='{0}' WHERE Email='{1}'", TempUserActive, UserGridAdmin_View.SelectedRows[0].Cells[4].Value), connection);
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
            UpdateDataGridUsers();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser AddUserForm = new AddUser();
            AddUserForm.Show();
        }

        private void ChangeRoleAdmin_Btn_Click(object sender, EventArgs e)
        {
            ChangeUserRole ChangeUserRoleForm = new ChangeUserRole(UserGridAdmin_View.CurrentRow.Cells[4].Value.ToString(), UserGridAdmin_View.CurrentRow.Cells[0].Value.ToString(), UserGridAdmin_View.CurrentRow.Cells[1].Value.ToString(), UserGridAdmin_View.CurrentRow.Cells[5].Value.ToString(), UserGridAdmin_View.CurrentRow.Cells[3].Value.ToString(), UserGridAdmin_View.CurrentRow.Cells[7].Value.ToString());
            ChangeUserRoleForm.Show();
        }

        private void UserGridAdmin_View_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ChangeRoleAdmin_Btn.Enabled = true;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchedulePanel ShedulePanelForm = new SchedulePanel();
            ShedulePanelForm.Show();
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveExit();
        }
    }
}

/*
 * Смена цвета заблокиров пользов
 * 
 * 
 * 
 * 
 * 
 */
