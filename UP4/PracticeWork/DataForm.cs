using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PracticeWork
{
    public partial class DataForm : Form
    {
        private string baseName = "DB.db3";
        private string[] GridUpdaterQuery = {
            "SELECT * FROM CategoryOfTeacher",
            "SELECT * FROM Diploms",
            "SELECT * FROM FormOfControl",
            "SELECT * FROM Groups",
            "SELECT * FROM Marks",
            "SELECT * FROM Students",
            "SELECT * FROM StudyOrders",
            "SELECT * FROM StudyPlans",
            "SELECT * FROM Teachers",
            "SELECT * FROM TypeOfActivity",
            "SELECT * FROM Users"
        };

        private SQLiteConnection connection = new SQLiteConnection();
        private SQLiteCommand cmd = new SQLiteCommand();
        private SQLiteDataReader ExecuteReader;
        private DataSet ds;
        private SQLiteDataAdapter da;

        private DataSet OrdersDs;
        private DataSet MarksDs;
        private DataSet DiplomsDs;

        public DataForm()
        {
            InitializeComponent();
            GridUpdate();
        }

        void GridUpdate()
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                for (int i = 0; i <= 10; i++)
                {
                    da = new SQLiteDataAdapter(GridUpdaterQuery[i], connection);
                    ds = new DataSet();
                    da.Fill(ds);
                    switch (i)
                    {
                        case 0:
                            dataGridView9.DataSource = ds.Tables[0];
                            break;
                        case 1:
                            dataGridView11.DataSource = ds.Tables[0];
                            DiplomsDs = ds;
                            break;
                        case 2:
                            dataGridView6.DataSource = ds.Tables[0];
                            break;
                        case 3:
                            dataGridView4.DataSource = ds.Tables[0];
                            break;
                        case 4:
                            dataGridView10.DataSource = ds.Tables[0];
                            MarksDs = ds;
                            break;
                        case 5:
                            dataGridView7.DataSource = ds.Tables[0];
                            break;
                        case 6:
                            dataGridView3.DataSource = ds.Tables[0];
                            OrdersDs = ds;
                            break;
                        case 7:
                            dataGridView2.DataSource = ds.Tables[0];
                            break;
                        case 8:
                            dataGridView8.DataSource = ds.Tables[0];
                            break;
                        case 9:
                            dataGridView5.DataSource = ds.Tables[0];
                            break;
                        case 10:
                            dataGridView1.DataSource = ds.Tables[0];
                            break;
                    }
                }

                DataSet dsTeachers = new DataSet();
                SQLiteDataAdapter daTeachers = new SQLiteDataAdapter("SELECT * FROM Teachers", connection);
                daTeachers.Fill(dsTeachers);
                comboBox1.DataSource = dsTeachers.Tables[0];
                comboBox1.DisplayMember = "Initials";
                comboBox1.ValueMember = "Id";
                comboBox15.DataSource = dsTeachers.Tables[0];
                comboBox15.DisplayMember = "Initials";
                comboBox15.ValueMember = "Id";

                DataSet dsTypeOfActivity = new DataSet();
                SQLiteDataAdapter daTypeOfActivity = new SQLiteDataAdapter("SELECT * FROM TypeOfActivity", connection);
                daTypeOfActivity.Fill(dsTypeOfActivity);
                comboBox4.DataSource = dsTypeOfActivity.Tables[0];
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "Id";

                DataSet dsFormOfControl = new DataSet();
                SQLiteDataAdapter daFormOfControl = new SQLiteDataAdapter("SELECT * FROM FormOfControl", connection);
                daFormOfControl.Fill(dsFormOfControl);
                comboBox5.DataSource = dsFormOfControl.Tables[0];
                comboBox5.DisplayMember = "Name";
                comboBox5.ValueMember = "Id";

                DataSet dsGroups = new DataSet();
                SQLiteDataAdapter daGroups = new SQLiteDataAdapter("SELECT * FROM Groups", connection);
                daGroups.Fill(dsGroups);
                comboBox6.DataSource = dsGroups.Tables[0];
                comboBox6.DisplayMember = "Name";
                comboBox6.ValueMember = "Id";
                comboBox10.DataSource = dsGroups.Tables[0];
                comboBox10.DisplayMember = "Name";
                comboBox10.ValueMember = "Id";
                comboBox7.DataSource = dsGroups.Tables[0];
                comboBox7.DisplayMember = "Department";
                comboBox7.ValueMember = "Department";

                DataSet dsStudyPlans = new DataSet();
                SQLiteDataAdapter daStudyPlans = new SQLiteDataAdapter("SELECT * FROM StudyPlans", connection);
                daStudyPlans.Fill(dsStudyPlans);
                comboBox8.DataSource = dsStudyPlans.Tables[0];
                comboBox8.DisplayMember = "Name";
                comboBox8.ValueMember = "Id";
                comboBox13.DataSource = dsStudyPlans.Tables[0];
                comboBox13.DisplayMember = "Name";
                comboBox13.ValueMember = "Id";

                DataSet dsCategoryOfTeacher = new DataSet();
                SQLiteDataAdapter daCategoryOfTeacher = new SQLiteDataAdapter("SELECT * FROM CategoryOfTeacher", connection);
                daCategoryOfTeacher.Fill(dsCategoryOfTeacher);
                comboBox12.DataSource = dsCategoryOfTeacher.Tables[0];
                comboBox12.DisplayMember = "Name";
                comboBox12.ValueMember = "Id";

                DataSet dsStudents = new DataSet();
                SQLiteDataAdapter daStudents = new SQLiteDataAdapter("SELECT * FROM Students", connection);
                daStudents.Fill(dsStudents);
                comboBox14.DataSource = dsStudents.Tables[0];
                comboBox14.DisplayMember = "Initials";
                comboBox14.ValueMember = "Id";
                comboBox16.DataSource = dsStudents.Tables[0];
                comboBox16.DisplayMember = "Initials";
                comboBox16.ValueMember = "Id";

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

        //--------------------------Users----------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");

            if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 50 && regex.IsMatch(textBox2.Text) && textBox2.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO Users (Login, Password) VALUES ('{0}', '{1}')", textBox1.Text, textBox2.Text), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");

            if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 50 && regex.IsMatch(textBox2.Text) && textBox2.Text.Length <= 50)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Users SET Login='{0}', Password='{1}' WHERE Id={2}", textBox1.Text, textBox2.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM Users WHERE Id={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridUpdate();
        }
        //--------------------------Users-----------------------------

        //--------------------Plans-----------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);

            if (textBox4.Text.Length > 0 && textBox4.Text.Length <= 50 && textBox3.Text.Length > 0 && textBox2.Text.Length <= 50 && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO StudyPlans (Name, Course, Semester, Hours, TeacherId, FormId, TypeId) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", textBox4.Text, Convert.ToInt32(comboBox2.SelectedItem), Convert.ToInt32(comboBox3.SelectedItem), Convert.ToInt32(textBox3.Text), comboBox1.SelectedValue, comboBox5.SelectedValue, comboBox4.SelectedValue), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0 && textBox4.Text.Length <= 50 && textBox3.Text.Length > 0 && textBox2.Text.Length <= 50 && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE StudyPlans SET Name='{0}', Course='{1}', Semester='{2}', Hours='{3}', TeacherId='{4}', FormId='{5}', TypeId='{6}' WHERE Id={7}", textBox4.Text, comboBox2.SelectedValue, comboBox3.SelectedValue, textBox3.Text, comboBox1.SelectedValue, comboBox5.SelectedValue, comboBox4.SelectedValue, dataGridView2.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM StudyPlans WHERE Id={0}", dataGridView2.SelectedRows[0].Cells[0].Value), connection);
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
            GridUpdate();
        }
        //--------------------------Plans------------------------------

        //--------------------------Orders-----------------------------
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex != -1 && comboBox7.SelectedIndex != -1 && comboBox8.SelectedIndex != -1)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO StudyOrders (Department, StudyPlanId, GroupId) VALUES ('{0}', '{1}', '{2}')", comboBox7.SelectedValue, comboBox8.SelectedValue, comboBox6.SelectedValue), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex != -1 && comboBox7.SelectedIndex != -1 && comboBox8.SelectedIndex != -1)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE StudyOrders SET Department='{0}', StudyPlanId='{1}', GroupId='{2}' WHERE Id={3}", comboBox7.SelectedValue, comboBox8.SelectedValue, comboBox6.SelectedValue, dataGridView3.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM StudyOrders WHERE Id={0}", dataGridView3.SelectedRows[0].Cells[0].Value), connection);
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
            GridUpdate();
        }
        //--------------------------Orders-----------------------------

        //--------------------------Groups-----------------------------
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0 && textBox6.Text.Length <= 50 && textBox5.Text.Length > 0 && textBox5.Text.Length <= 50 && textBox14.Text.Length > 0 && textBox14.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO Groups (Name, Department, Faculty) VALUES ('{0}','{1}','{2}')", textBox6.Text, textBox14.Text, textBox5.Text), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0 && textBox6.Text.Length <= 50 && textBox5.Text.Length > 0 && textBox5.Text.Length <= 50 && textBox14.Text.Length > 0 && textBox14.Text.Length <= 50)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Groups SET Name='{0}', Department='{1}', Faculty='{2}' WHERE Id={3}", textBox6.Text, textBox14.Text, textBox5.Text, dataGridView4.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM Groups WHERE Id={0}", dataGridView4.SelectedRows[0].Cells[0].Value), connection);
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
            GridUpdate();
        }
        //--------------------------Groups-----------------------------

        //--------------------------Types------------------------------
        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0 && textBox7.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO TypeOfActivity (Name) VALUES ('{0}')", textBox7.Text), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0 && textBox7.Text.Length <= 50)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Groups SET Name='{0}' WHERE Id={1}", textBox7.Text, dataGridView5.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM TypeOfActivity WHERE Id={0}", dataGridView5.SelectedRows[0].Cells[0].Value), connection);
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
            GridUpdate();
        }
        //--------------------------Types------------------------------

        //--------------------------Forms------------------------------
        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0 && textBox8.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO FormOfControl (Name) VALUES ('{0}')", textBox8.Text), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0 && textBox8.Text.Length <= 50)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE FormOfControl SET Name='{0}' WHERE Id={1}", textBox8.Text, dataGridView6.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM FormOfControl WHERE Id={0}", dataGridView6.SelectedRows[0].Cells[0].Value), connection);
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
            GridUpdate();
        }
        //--------------------------Forms------------------------------

        //--------------------------Students---------------------------

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0 && textBox9.Text.Length <= 50 && comboBox10.SelectedIndex != -1 && comboBox11.SelectedIndex != -1)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO Students (Initials, Course, GroupId) VALUES ('{0}','{1}','{2}')", textBox9.Text, Convert.ToInt32(comboBox11.SelectedItem), Convert.ToInt32(comboBox10.SelectedValue)), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0 && textBox9.Text.Length <= 50 && comboBox10.SelectedIndex != -1 && comboBox11.SelectedIndex != -1)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Students SET Initials='{0}', Course='{1}', GroupId='{2}' WHERE Id={3}", textBox9.Text, Convert.ToInt32(comboBox11.SelectedItem), Convert.ToInt32(comboBox10.SelectedValue), dataGridView7.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM Students WHERE Id={0}", dataGridView7.SelectedRows[0].Cells[0].Value), connection);
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
        }
        //--------------------------Students---------------------------

        //--------------------------Teachers---------------------------
        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Length > 0 && textBox10.Text.Length <= 50 && comboBox12.SelectedIndex != -1)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO Teachers (Initials, CategoryId) VALUES ('{0}','{1}')", textBox10.Text, Convert.ToInt32(comboBox12.SelectedValue)), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Length > 0 && textBox10.Text.Length <= 50 && comboBox12.SelectedIndex != -1)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Teachers SET Initials='{0}', CategoryId='{1}' WHERE Id={2}", textBox10.Text, Convert.ToInt32(comboBox12.SelectedValue), dataGridView8.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM Teachers WHERE Id={0}", dataGridView8.SelectedRows[0].Cells[0].Value), connection);
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
        }
        //--------------------------Teachers---------------------------

        //--------------------------Category---------------------------
        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Length > 0 && textBox11.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO CategoryOfTeacher (Name) VALUES ('{0}')", textBox11.Text), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Length > 0 && textBox11.Text.Length <= 50)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE CategoryOfTeacher SET Name='{0}' WHERE Id={1}", textBox11.Text, dataGridView9.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM CategoryOfTeacher WHERE Id={0}", dataGridView9.SelectedRows[0].Cells[0].Value), connection);
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
        }
        //--------------------------Category---------------------------

        //--------------------------Marks------------------------------
        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Length > 0 && textBox12.Text.Length <= 50 && comboBox13.SelectedIndex != -1 && comboBox14.SelectedIndex != -1)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO Marks (Rating, StudentId, StudyPlanId) VALUES ('{0}', '{1}', '{2}')", textBox12.Text, Convert.ToInt32(comboBox14.SelectedValue), Convert.ToInt32(comboBox13.SelectedValue)), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Length > 0 && textBox12.Text.Length <= 50 && comboBox13.SelectedIndex != -1 && comboBox14.SelectedIndex != -1)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Marks SET Rating='{0}', StudentId='{1}', StudyPlanId='{2}' WHERE Id={3}", textBox12.Text, Convert.ToInt32(comboBox14.SelectedValue), Convert.ToInt32(comboBox13.SelectedValue), dataGridView10.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM Marks WHERE Id={0}", dataGridView10.SelectedRows[0].Cells[0].Value), connection);
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
        }
        //--------------------------Marks------------------------------

        //--------------------------Diploms----------------------------
        private void button32_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Length > 0 && textBox13.Text.Length <= 50 && comboBox15.SelectedIndex != -1 && comboBox16.SelectedIndex != -1)
            {
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("INSERT INTO Diploms (Number, StudentId, TeacherId) VALUES ('{0}', '{1}', '{2}')", Convert.ToInt32(textBox13.Text), Convert.ToInt32(comboBox16.SelectedValue), Convert.ToInt32(comboBox15.SelectedValue)), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Length > 0 && textBox13.Text.Length <= 50 && comboBox15.SelectedIndex != -1 && comboBox16.SelectedIndex != -1)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("UPDATE Diploms SET Number='{0}', StudentId='{1}', TeacherId='{2}' WHERE Id={3}", Convert.ToInt32(textBox13.Text), Convert.ToInt32(comboBox16.SelectedValue), Convert.ToInt32(comboBox15.SelectedValue), dataGridView11.SelectedRows[0].Cells[0].Value), connection);
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
                GridUpdate();
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + baseName);
            try
            {
                connection.Open();
                cmd = new SQLiteCommand(String.Format("DELETE FROM Diploms WHERE Id={0}", dataGridView11.SelectedRows[0].Cells[0].Value), connection);
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
        }
        //--------------------------Diploms----------------------------

        //--------------------------Select row-------------------------
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox1.SelectedValue = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox2.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox3.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox4.SelectedValue = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBox5.SelectedValue = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox7.SelectedValue = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox6.SelectedValue = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox8.SelectedValue = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox6.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox14.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox7.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox8.Text = dataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox9.Text = dataGridView7.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox11.SelectedItem = dataGridView7.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox10.SelectedValue = dataGridView7.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox10.Text = dataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox12.SelectedValue = dataGridView8.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox11.Text = dataGridView9.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox12.Text = dataGridView10.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox14.SelectedValue = dataGridView10.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox13.SelectedValue = dataGridView10.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox13.Text = dataGridView11.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox16.SelectedValue = dataGridView11.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox15.SelectedValue = dataGridView11.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }
        //--------------------------Select row-------------------------

        private void DataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (ExcelWriter writer = new ExcelWriter(saveFileDialog1.FileName))
                    {
                        writer.WriteStartDocument();

                        // Write the worksheet contents
                        writer.WriteStartWorksheet("Учебные поручения");

                        //Write header row
                        writer.WriteStartRow();
                        writer.WriteExcelUnstyledCell("Id");
                        writer.WriteExcelUnstyledCell("Кафедра");
                        writer.WriteExcelUnstyledCell("Учебный план");
                        writer.WriteExcelUnstyledCell("Группа");
                        writer.WriteEndRow();

                        //write data
                        foreach (DataRow row in OrdersDs.Tables[0].Rows)
                        {
                            writer.WriteStartRow();
                            foreach (object o in row.ItemArray)
                            {
                                writer.WriteExcelAutoStyledCell(o);
                            }
                            writer.WriteEndRow();
                        }
                        // Close up the document
                        writer.WriteEndWorksheet();

                        writer.WriteStartWorksheet("Оценки");

                        //Write header row
                        writer.WriteStartRow();
                        writer.WriteExcelUnstyledCell("Id");
                        writer.WriteExcelUnstyledCell("Оценка");
                        writer.WriteExcelUnstyledCell("Студент");
                        writer.WriteExcelUnstyledCell("Учебный план");
                        writer.WriteEndRow();

                        //write data
                        foreach (DataRow row in MarksDs.Tables[0].Rows)
                        {
                            writer.WriteStartRow();
                            foreach (object o in row.ItemArray)
                            {
                                writer.WriteExcelAutoStyledCell(o);
                            }
                            writer.WriteEndRow();
                        }
                        // Close up the document
                        writer.WriteEndWorksheet();

                        writer.WriteStartWorksheet("Дипломы");

                        //Write header row
                        writer.WriteStartRow();
                        writer.WriteExcelUnstyledCell("Id");
                        writer.WriteExcelUnstyledCell("Номер диплома");
                        writer.WriteExcelUnstyledCell("Студент");
                        writer.WriteExcelUnstyledCell("Преподаватель");
                        writer.WriteEndRow();

                        //write data
                        foreach (DataRow row in DiplomsDs.Tables[0].Rows)
                        {
                            writer.WriteStartRow();
                            foreach (object o in row.ItemArray)
                            {
                                writer.WriteExcelAutoStyledCell(o);
                            }
                            writer.WriteEndRow();
                        }
                        // Close up the document
                        writer.WriteEndWorksheet();

                        writer.WriteEndDocument();
                        writer.Close();
                    }
                }
                catch (Exception myException)
                {
                    MessageBox.Show("Ошибка экспорта");
                }
            }
        }
    }

    public class ExcelWriter : IDisposable
    {
        private XmlWriter _writer;

        public enum CellStyle { General, Number, Currency, DateTime, ShortDate };

        public void WriteStartDocument()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
            _writer.WriteStartElement("ss", "Workbook", "urn:schemas-microsoft-com:office:spreadsheet");
            WriteExcelStyles();
        }

        public void WriteEndDocument()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteEndElement();
        }

        private void WriteExcelStyleElement(CellStyle style)
        {
            _writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
            _writer.WriteEndElement();
        }

        private void WriteExcelStyleElement(CellStyle style, string NumberFormat)
        {
            _writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");

            _writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
            _writer.WriteStartElement("NumberFormat", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("Format", "urn:schemas-microsoft-com:office:spreadsheet", NumberFormat);
            _writer.WriteEndElement();

            _writer.WriteEndElement();

        }

        private void WriteExcelStyles()
        {
            _writer.WriteStartElement("Styles", "urn:schemas-microsoft-com:office:spreadsheet");

            WriteExcelStyleElement(CellStyle.General);
            WriteExcelStyleElement(CellStyle.Number, "General Number");
            WriteExcelStyleElement(CellStyle.DateTime, "General Date");
            WriteExcelStyleElement(CellStyle.Currency, "Currency");
            WriteExcelStyleElement(CellStyle.ShortDate, "Short Date");

            _writer.WriteEndElement();
        }

        public void WriteStartWorksheet(string name)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteStartElement("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("Name", "urn:schemas-microsoft-com:office:spreadsheet", name);
            _writer.WriteStartElement("Table", "urn:schemas-microsoft-com:office:spreadsheet");
        }

        public void WriteEndWorksheet()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }

        public ExcelWriter(string outputFileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            _writer = XmlWriter.Create(outputFileName, settings);
        }

        public void Close()
        {
            if (_writer == null) throw new InvalidOperationException("Already closed.");

            _writer.Close();
            _writer = null;
        }

        public void WriteExcelColumnDefinition(int columnWidth)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteStartElement("Column", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteStartAttribute("Width", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteValue(columnWidth);
            _writer.WriteEndAttribute();
            _writer.WriteEndElement();
        }

        public void WriteExcelUnstyledCell(string value)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
            _writer.WriteValue(value);
            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }

        public void WriteStartRow()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteStartElement("Row", "urn:schemas-microsoft-com:office:spreadsheet");
        }

        public void WriteEndRow()
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteEndElement();
        }

        public void WriteExcelStyledCell(object value, CellStyle style)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            _writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
            _writer.WriteAttributeString("StyleID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
            _writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
            switch (style)
            {
                case CellStyle.General:
                    _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
                    break;
                case CellStyle.Number:
                case CellStyle.Currency:
                    _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "Number");
                    break;
                case CellStyle.ShortDate:
                case CellStyle.DateTime:
                    _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "DateTime");
                    break;
            }
            _writer.WriteValue(value);
            //  tag += String.Format("{1}\"><ss:Data ss:Type=\"DateTime\">{0:yyyy\\-MM\\-dd\\THH\\:mm\\:ss\\.fff}</ss:Data>", value,

            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }

        public void WriteExcelAutoStyledCell(object value)
        {
            if (_writer == null) throw new InvalidOperationException("Cannot write after closing.");

            //write the <ss:Cell> and <ss:Data> tags for something
            if (value is Int16 || value is Int32 || value is Int64 || value is SByte ||
                value is UInt16 || value is UInt32 || value is UInt64 || value is Byte)
            {
                WriteExcelStyledCell(value, CellStyle.Number);
            }
            else if (value is Single || value is Double || value is Decimal) //we'll assume it's a currency
            {
                WriteExcelStyledCell(value, CellStyle.Currency);
            }
            else if (value is DateTime)
            {
                //check if there's no time information and use the appropriate style
                WriteExcelStyledCell(value, ((DateTime)value).TimeOfDay.CompareTo(new TimeSpan(0, 0, 0, 0, 0)) == 0 ? CellStyle.ShortDate : CellStyle.DateTime);
            }
            else
            {
                WriteExcelStyledCell(value, CellStyle.General);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_writer == null)
                return;

            _writer.Close();
            _writer = null;
        }

        #endregion
    }
}


/* Авторизация +
 * Чтение из БД +
 * Запись в БД +
 * Подгрузка в боксы +
 * Сортировка +
 * Поиск +
 * Отчет при закрытии +
 */
