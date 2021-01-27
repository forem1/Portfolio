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
    public partial class AmenitiesPurchase : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataReader ExecuteReader;

        private int TicketID = 0;

        public AmenitiesPurchase()
        {
            InitializeComponent();

            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                cmd = new SqlCommand(String.Format("SELECT Service, convert(int, floor(Price)) AS Cost FROM Amenities"), connection);
                ExecuteReader = cmd.ExecuteReader();
                int TempAmenityCounter = 1;
                while (ExecuteReader.Read())
                {
                    switch (TempAmenityCounter)
                    {
                        case 1:
                            Amenities1_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 2:
                            Amenities2_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 3:
                            Amenities3_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 4:
                            Amenities4_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 5:
                            Amenities5_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 6:
                            Amenities6_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 7:
                            Amenities7_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 8:
                            Amenities8_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 9:
                            Amenities9_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 10:
                            Amenities10_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 11:
                            Amenities11_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                        case 12:
                            Amenities12_Check.Text = ExecuteReader["Service"] + " (" + ExecuteReader["Cost"] + ")";
                            break;
                    }
                    TempAmenityCounter++;
                }
                ExecuteReader.Close();

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

        private void AmenitiesExit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AmenitiesOK_Btn_Click(object sender, EventArgs e)
        {
            if (AmenitiesReference_Box.Text.Length > 0)
            {
                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    DataSet DSTick = new DataSet();
                    SqlDataAdapter DATick = new SqlDataAdapter(string.Format("SELECT * FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID WHERE BookingReference = '{0}' AND Date < '{1}'", AmenitiesReference_Box.Text, DateTime.Now.AddDays(-1).ToString("yyyyMMdd")), connection); //Изменить дату
                    DATick.Fill(DSTick);

                    AmenitiesFlight_ComboBox.DataSource = DSTick.Tables[0];
                    AmenitiesFlight_ComboBox.DisplayMember = "Firstname";
                    AmenitiesFlight_ComboBox.ValueMember = "ID";
                    //AmenitiesFlight_ComboBox.Items.Add(ExecuteReader["FlightNumber"]+", "+ExecuteReader["BookingReference"] + ", " + ExecuteReader["Date"] + ", " + ExecuteReader["Time"], ExecuteReader["Time"]);

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
            else MessageBox.Show("Enter reference code!");
        }



        private void AmenitiesShow_Btn_Click(object sender, EventArgs e)
        {
            Amenities1_Check.Visible = false; Amenities2_Check.Visible = false; Amenities3_Check.Visible = false; Amenities4_Check.Visible = false; Amenities5_Check.Visible = false; Amenities6_Check.Visible = false; Amenities7_Check.Visible = false; Amenities8_Check.Visible = false; Amenities9_Check.Visible = false; Amenities10_Check.Visible = false; Amenities11_Check.Visible = false; Amenities12_Check.Visible = false;
            Amenities1_Check.Checked = false; Amenities2_Check.Checked = false; Amenities3_Check.Checked = false; Amenities4_Check.Checked = false; Amenities5_Check.Checked = false; Amenities6_Check.Checked = false; Amenities7_Check.Checked = false; Amenities8_Check.Checked = false; Amenities9_Check.Checked = false; Amenities10_Check.Checked = false; Amenities11_Check.Checked = false; Amenities12_Check.Checked = false;

            string CabinTypeID = "";
            if (AmenitiesFlight_ComboBox.SelectedValue.ToString().Length > 0)
            {
                TicketID = Convert.ToInt32(AmenitiesFlight_ComboBox.SelectedValue);

                connection = new SqlConnection(conStr);
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(String.Format("SELECT * FROM Tickets INNER JOIN CabinTypes ON Tickets.CabinTypeID = CabinTypes.ID WHERE Tickets.ID={0}", AmenitiesFlight_ComboBox.SelectedValue.ToString()), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read())
                    {
                        AmenitiesFlightName_Label.Text = "Full name: " + ExecuteReader["Firstname"] + " " + ExecuteReader["Lastname"];
                        AmenitiesFlightCabin_Label.Text = "Your cabin class is: " + ExecuteReader["Name"];
                        AmenitiesFlightPassport_Label.Text = "Passport number: " + ExecuteReader["PassportNumber"];
                        CabinTypeID = ExecuteReader["CabinTypeID"].ToString();
                    }
                    ExecuteReader.Close();

                    cmd = new SqlCommand(String.Format("SELECT * FROM AmenitiesCabinType WHERE CabinTypeID={0}", CabinTypeID), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read())
                    {
                        switch(ExecuteReader["AmenityID"])
                        {
                            case 1:
                                Amenities1_Check.Visible = true;
                                break;
                            case 2:
                                Amenities2_Check.Visible = true;
                                break;
                            case 3:
                                Amenities3_Check.Visible = true;
                                break;
                            case 4:
                                Amenities4_Check.Visible = true;
                                break;
                            case 5:
                                Amenities5_Check.Visible = true;
                                break;
                            case 6:
                                Amenities6_Check.Visible = true;
                                break;
                            case 7:
                                Amenities7_Check.Visible = true;
                                break;
                            case 8:
                                Amenities8_Check.Visible = true;
                                break;
                            case 9:
                                Amenities9_Check.Visible = true;
                                break;
                            case 10:
                                Amenities10_Check.Visible = true;
                                break;
                            case 11:
                                Amenities11_Check.Visible = true;
                                break;
                            case 12:
                                Amenities12_Check.Visible = true;
                                break;
                        }
                    }
                    ExecuteReader.Close();

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
        }

        public int FullCost = 0;

        private void Amenities_Check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox СheckBoxSelected = (CheckBox)sender;
            int TempValue = 0;

            if (СheckBoxSelected.Checked == true)
            {
                int.TryParse(string.Join("", СheckBoxSelected.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue);
                FullCost += TempValue;
    }
            else
            {
                int.TryParse(string.Join("", СheckBoxSelected.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue);
                FullCost -= TempValue;
            }

            AmenitiesSelected_Label.Text = "Items selected: " + FullCost;
            AmenitiesDuty_Label.Text = "Duties and taxes: " + FullCost*0.05;
            AmenitiesFull_Label.Text = "Total payable: " + (FullCost+FullCost * 0.05);
        }

        private void AmenitiesSave_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                int TempValue = 0;

                if (Amenities1_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities1_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities1_Check.Text.Remove(8, Amenities1_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities2_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities2_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities2_Check.Text.Remove(8, Amenities2_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities3_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities3_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities3_Check.Text.Remove(8, Amenities3_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities4_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities4_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities4_Check.Text.Remove(8, Amenities4_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities5_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities5_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities5_Check.Text.Remove(8, Amenities5_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities6_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities6_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities6_Check.Text.Remove(8, Amenities6_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities7_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities7_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities7_Check.Text.Remove(8, Amenities7_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities8_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities8_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities8_Check.Text.Remove(8, Amenities8_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities9_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities9_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities9_Check.Text.Remove(8, Amenities9_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities10_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities10_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities10_Check.Text.Remove(8, Amenities10_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities11_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities11_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities11_Check.Text.Remove(8, Amenities11_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                if (Amenities12_Check.Checked) {
                    TempValue = 0; int.TryParse(string.Join("", Amenities12_Check.Text.Remove(0, 9).Where(c => char.IsDigit(c))), out TempValue); cmd = new SqlCommand(String.Format("INSERT INTO AmenitiesTickets (AmenityID, TicketID, Price) VALUES ((SELECT ID FROM Amenities WHERE Service LIKE '%' + '{0}' + '%'), '{1}', '{2}')", Amenities11_Check.Text.Remove(8, Amenities12_Check.Text.Length - 8), TicketID, TempValue), connection); cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Success!");
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
    }
}

/* переписать получение уникальных кодов. рандом и проверка по бд на уникальность
 *
 * 
 */
