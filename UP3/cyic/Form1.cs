using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace cyic
{
    public partial class Form1 : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=practice;Persist Security Info=True;User ID=sa;Password=12345";
        public int selectTab = 0;

        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        public Form1()
        {
            InitializeComponent();
            GridFill(selectTab);
        }

        private void GridFill(int SelectedTab)
        {
            selectTab = SelectedTab;
            switch (SelectedTab)
            {
                case 0:
                    da = new SqlDataAdapter("SELECT * FROM Inventory", connection);
                    break;
                case 1:
                    da = new SqlDataAdapter("SELECT * FROM Recipes", connection);
                    break;
                case 2:
                    da = new SqlDataAdapter("SELECT * FROM Status", connection);
                    break;
                case 3:
                    da = new SqlDataAdapter("SELECT * FROM TypeOfStorage", connection);
                    break;
                case 4:
                    da = new SqlDataAdapter("SELECT * FROM TypeOfWork", connection);
                    break;
                case 5:
                    da = new SqlDataAdapter("SELECT * FROM Works", connection);
                    break;
                case 6:
                    da = new SqlDataAdapter("SELECT * FROM Users", connection);
                    break;
            }

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                switch (SelectedTab)
                {
                    case 0:
                        DataSet dsStorage = new DataSet();
                        SqlDataAdapter daStorage = new SqlDataAdapter("SELECT * FROM TypeOfStorage", connection);
                        daStorage.Fill(dsStorage);
                        InventoryStorage.DataSource = dsStorage.Tables[0];
                        InventoryStorage.DisplayMember = "Name";
                        InventoryStorage.ValueMember = "Name";
                        break;
                    case 1:
                        DataSet dsWork = new DataSet();
                        SqlDataAdapter daWork = new SqlDataAdapter("SELECT * FROM Works", connection);
                        daWork.Fill(dsWork);
                        ReceiptNumber.DataSource = dsWork.Tables[0];
                        ReceiptNumber.DisplayMember = "id";
                        ReceiptNumber.ValueMember = "id";
                        break;
                    case 5:
                        DataSet dsType = new DataSet();
                        SqlDataAdapter daType = new SqlDataAdapter("SELECT * FROM TypeOfWork", connection);
                        daType.Fill(dsType);
                        WorkType.DataSource = dsType.Tables[0];
                        WorkType.DisplayMember = "Name";
                        WorkType.ValueMember = "Name";

                        DataSet dsStatus = new DataSet();
                        SqlDataAdapter daStatus = new SqlDataAdapter("SELECT * FROM Status", connection);
                        daStatus.Fill(dsStatus);
                        WorkStatus.DataSource = dsStatus.Tables[0];
                        WorkStatus.DisplayMember = "Name";
                        WorkStatus.ValueMember = "Name";

                        DataSet dsInventory = new DataSet();
                        SqlDataAdapter daInventory = new SqlDataAdapter("SELECT * FROM Inventory", connection);
                        daInventory.Fill(dsInventory);
                        WorkInventory.DataSource = dsInventory.Tables[0];
                        WorkInventory.DisplayMember = "Name";
                        WorkInventory.ValueMember = "Name";
                        break;
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

        //---------------------------------Status--------------------------------------
        private void AddStatus_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);


            if (StatusName.Text.Length > 0 && StatusName.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO Status (Name) VALUES ('{0}')", StatusName.Text), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void DeleteStatus_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Status WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }

        private void UpdateStatus_Click(object sender, EventArgs e)
        {
            if (StatusName.Text.Length > 0 && StatusName.Text.Length <= 50)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Status SET Name='{0}' WHERE ID={1}", StatusName.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }
        //---------------------------------Status--------------------------------------

        //---------------------------------TypeOfStorage--------------------------------------
        private void AddStorage_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);

            if (StorageName.Text.Length > 0 && StorageName.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO TypeOfStorage (Name) VALUES ('{0}')", StorageName.Text), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void DeleteStorage_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM TypeOfStorage WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }

        private void UpdateStorage_Click(object sender, EventArgs e)
        {
            if (StorageName.Text.Length > 0 && StorageName.Text.Length <= 50)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE TypeOfStorage SET Name='{0}' WHERE ID={1}", StorageName.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }
        //---------------------------------TypeOfStorage--------------------------------------

        //---------------------------------TypeOfWork--------------------------------------
        private void AddType_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);

            if (TypeName.Text.Length > 0 && TypeName.Text.Length <= 50)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO TypeOfWork (Name) VALUES ('{0}')", TypeName.Text), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void DeleteType_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM TypeOfWork WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }

        private void UpdateType_Click(object sender, EventArgs e)
        {
            if (TypeName.Text.Length > 0 && TypeName.Text.Length <= 50)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE TypeOfWork SET Name='{0}' WHERE ID={1}", TypeName.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }
        //---------------------------------TypeOfWork--------------------------------------

        //---------------------------------Inventory--------------------------------------
        private void AddInventory_Click(object sender, EventArgs e)
        {
            if ((InventoryName.Text.Length > 0 && InventoryName.Text.Length <= 50) && InventoryQuantity.Value >= 0 && InventoryCost.Value >= 0)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO Inventory (Name, Quantity, Cost, StorageType) VALUES ('{0}', '{1}', '{2}', '{3}')", InventoryName.Text, InventoryQuantity.Value, InventoryCost.Value, InventoryStorage.SelectedValue), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void DeleteInventory_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Inventory WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }

        private void UpdateInventory_Click(object sender, EventArgs e)
        {
            if ((InventoryName.Text.Length > 0 && InventoryName.Text.Length <= 50) && InventoryQuantity.Value >= 0 && InventoryCost.Value >= 0)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Inventory SET Name='{0}', Quantity='{1}', Cost='{2}', StorageType='{3}' WHERE ID={4}", InventoryName.Text, InventoryQuantity.Value, InventoryCost.Value, InventoryStorage.SelectedValue, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }
        //---------------------------------Inventory--------------------------------------

        //---------------------------------Works--------------------------------------
        private void AddWork_Click(object sender, EventArgs e)
        {
            if ((WorkName.Text.Length > 0 && WorkName.Text.Length <= 50) && WorkTask.Text.Length > 0)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO Works (Name, Task, TypeOfWork, Status, Inventory) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", WorkName.Text, WorkTask.Text, WorkType.SelectedValue, WorkStatus.SelectedValue, WorkInventory.SelectedValue), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void DeleteWork_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Works WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }

        private void UpdateWork_Click(object sender, EventArgs e)
        {
            if ((WorkName.Text.Length > 0 && WorkName.Text.Length <= 50) && WorkTask.Text.Length > 0)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Works SET Name='{0}', Task='{1}', TypeOfWork='{2}', Status='{3}', Inventory='{4}' WHERE ID={5}", WorkName.Text, WorkTask.Text, WorkType.SelectedValue, WorkStatus.SelectedValue, WorkInventory.SelectedValue, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }
        //---------------------------------Works--------------------------------------

        //---------------------------------Receipts--------------------------------------
        private void AddReceipt_Click(object sender, EventArgs e)
        {
            if (ReceiptCost.Value >= 0 && ReceiptNumber.SelectedIndex > -1 && ReceiptDate.Value <= DateTime.Now)
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("INSERT INTO Recipes (Date, Cost, WorkId) VALUES ('{0}', '{1}', '{2}')", ReceiptDate.Value.ToShortDateString(), ReceiptCost.Value, ReceiptNumber.SelectedValue), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }

        private void DeleteReceipt_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Recipes WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }
        //---------------------------------Recepts--------------------------------------

        //---------------------------------Users--------------------------------------
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                cmd = new SqlCommand(String.Format("DELETE FROM Users WHERE ID={0}", dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
            GridFill(selectTab);
        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {
            if (UserLogin.Text.Length > 0 && UserLogin.Text.Length <= 50)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("UPDATE Users SET login='{0}' WHERE ID={1}", UserLogin.Text, dataGridView1.SelectedRows[0].Cells[0].Value), connection);
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
                GridFill(selectTab);
            }
            else MessageBox.Show("Проверьте правильность заполнения полей");
        }
        //---------------------------------Users--------------------------------------

        //---------------------------------Auth--------------------------------------
        private void UserReg_Click(object sender, EventArgs e)
        {
            string Login = UserLogBox.Text;
            string Password = UserPassBox.Text;
            string SecurePass = "";
            bool ok = true;

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");

            if (regex.IsMatch(Password) && Login.Length >= 3)
            {

                byte[] hash = Encoding.ASCII.GetBytes(Password);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hashenc = md5.ComputeHash(hash);
                string halfresult = "";
                foreach (var b in hashenc)
                {
                    halfresult += b.ToString("x2");
                }

                byte[] hashRev = Encoding.ASCII.GetBytes(Reverce(halfresult+"hY$T37@84#hJF!2"));
                MD5 md5Rev = new MD5CryptoServiceProvider();
                byte[] hashencRev = md5Rev.ComputeHash(hashRev);
                foreach (var b in hashencRev)
                {
                    SecurePass += b.ToString("x2");
                }

                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("SELECT * FROM Users WHERE login='{0}'", Login), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read()) if (ExecuteReader["id"].ToString().Length > 0) ok = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                connection = new SqlConnection(conStr);
                if (ok)
                {
                    try
                    {
                        connection.Open();
                        cmd = new SqlCommand(String.Format("INSERT INTO Users (login, password) VALUES ('{0}','{1}')", Login, SecurePass), connection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Упех!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                    GridFill(selectTab);
                }
                else MessageBox.Show("Такой логин уже существует");
            }
            else MessageBox.Show("Пароль/логин не соответствует условиям");
        }

        private void UserLog_Click(object sender, EventArgs e)
        {
            string Login = UserLogBox.Text;
            string Password = UserPassBox.Text;
            string SecurePass = "";

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");

            if (regex.IsMatch(Password) && Login.Length >= 3)
            {
                byte[] hash = Encoding.ASCII.GetBytes(Password);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hashenc = md5.ComputeHash(hash);
                string halfresult = "";
                foreach (var b in hashenc)
                {
                    halfresult += b.ToString("x2");
                }

                byte[] hashRev = Encoding.ASCII.GetBytes(Reverce(halfresult + "hY$T37@84#hJF!2"));
                MD5 md5Rev = new MD5CryptoServiceProvider();
                byte[] hashencRev = md5Rev.ComputeHash(hashRev);
                foreach (var b in hashencRev)
                {
                    SecurePass += b.ToString("x2");
                }

                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("SELECT * FROM Users WHERE login='{0}'", Login), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read())
                    {
                        if (ExecuteReader["password"].ToString() == SecurePass) MessageBox.Show("Добро пожаловать, " + Login + "!");
                        else MessageBox.Show("Неправильный логин или пароль");
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
            else MessageBox.Show("Пароль/логин не соответствует условиям");
        }
        //---------------------------------Auth--------------------------------------

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //MessageBox.Show(e.TabPageIndex.ToString());
            GridFill(e.TabPageIndex);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (selectTab)
                {
                    case 0:
                        InventoryName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        InventoryQuantity.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                        InventoryCost.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                        InventoryStorage.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        break;
                    case 1:
                        ReceiptDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        ReceiptCost.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                        ReceiptNumber.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        break;
                    case 2:
                        StatusName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case 3:
                        StorageName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case 4:
                        TypeName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case 5:
                        WorkName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        WorkTask.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        WorkType.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        WorkStatus.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        WorkInventory.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        break;
                    case 6:
                        UserLogin.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                }
            }
            catch { }
        }

        public static string Reverce(string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());
        }

        private void ExportExel_Click(object sender, EventArgs e)
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
                        writer.WriteStartWorksheet("Чек");

                        //Write header row
                        writer.WriteStartRow();
                        writer.WriteExcelUnstyledCell("Id");
                        writer.WriteExcelUnstyledCell("Дата");
                        writer.WriteExcelUnstyledCell("Стоимость");
                        writer.WriteExcelUnstyledCell("Номер заказа");
                        writer.WriteEndRow();

                        //write data
                        foreach (DataRow row in ds.Tables[0].Rows)
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

                        GridFill(5);
                        writer.WriteStartWorksheet("Заказы");

                        //Write header row
                        writer.WriteStartRow();
                        writer.WriteExcelUnstyledCell("Id");
                        writer.WriteExcelUnstyledCell("Название");
                        writer.WriteExcelUnstyledCell("ТЗ");
                        writer.WriteExcelUnstyledCell("Тип работ");
                        writer.WriteExcelUnstyledCell("Статус");
                        writer.WriteExcelUnstyledCell("Инвентарь");
                        writer.WriteEndRow();

                        //write data
                        foreach (DataRow row in ds.Tables[0].Rows)
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
                        GridFill(1);
                    }
                }
                catch (Exception myException)
                {

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
/* Инвентарь +
 * Чеки + 
 * Статус + 
 * Хранение + 
 * Тип работы +
 * Заказы + 
 * Пользователи +
 * Авторизация +
 * Экспорт +
 */
