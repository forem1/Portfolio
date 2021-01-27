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
    public partial class BookingFlight : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;

        private string FromPass = "";
        private string ToPass = "";
        private int CabinPass = 1;
        private bool ReturningPass = false;
        private int OutboundCostPass = 0;
        private int ReturnCostPass = 0;
        private string ScheduleOutboundID = "";
        private string ScheduleReturnID = "";
        private int UserID = 0;

        public BookingFlight(string From, string To, int Cabin, string OutboundDate, string ReturnDate, string OutboundNumber, string ReturnNumber, bool Returning, int OutboundCost, int ReturnCost, string SchID, string ReturnSchID, int UID)
        {
            InitializeComponent();

            FromPass = From;
            ToPass = To;
            CabinPass = Cabin;
            OutboundCostPass = OutboundCost;
            ReturnCostPass = ReturnCost;
            ScheduleOutboundID = SchID;
            ScheduleReturnID = ReturnSchID;
            UserID = UID;

        connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSCountry = new DataSet();
                SqlDataAdapter DACountry = new SqlDataAdapter("SELECT * FROM Countries", connection);
                DACountry.Fill(DSCountry);

                BookingPassengerPassportCountry_Combobox.DataSource = DSCountry.Tables[0];
                BookingPassengerPassportCountry_Combobox.DisplayMember = "Name";
                BookingPassengerPassportCountry_Combobox.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            string CabinType = "";
            switch(Cabin)
            {
                case 1:
                    CabinType = "Economy";
                    break;
                case 2:
                    CabinType = "Business";
                    break;
                case 3:
                    CabinType = "First Class";
                    break;
            }

            BookingOutboundFrom_Label.Text = "From: "+From;
            BookingOutboundTo_Label.Text = "To: "+To;
            BookingOutboundCabin_Label.Text = "Cabin Type: "+CabinType;
            BookingOutboundDate_Label.Text = "Date: "+OutboundDate;
            BookingOutboundFlight_Label.Text = "Flight number: "+OutboundNumber;

            if(Returning && ReturnDate.Length > 0)
            {
                ReturningPass = true;

                BookingReturnFrom_Label.Text = "From: " + To;
                BookingReturnTo_Label.Text = "To: " + From;
                BookingReturnCabin_Label.Text = "Cabin Type: " + CabinType;
                BookingReturnDate_Label.Text = "Date: " + ReturnDate;
                BookingReturnFlight_Label.Text = "Flight number: "+ ReturnNumber;
            }
        }

        private void BookingCancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookingPassengerAdd_Btn_Click(object sender, EventArgs e)
        {
            if (BookingPassengerFirstname_Box.Text.Length > 0 && BookingPassengerLastname_Box.Text.Length > 0 && BookingPassengerPassportNum_Box.Text.Length > 0 && BookingPassengerPhone_Box.Text.Length > 0)
            {
                BookingPassengersGrid_View.Rows.Add(BookingPassengerFirstname_Box.Text, BookingPassengerLastname_Box.Text, BookingPassengerBirthdate_Picker.Value.ToShortDateString(), BookingPassengerPassportNum_Box.Text, BookingPassengerPassportCountry_Combobox.SelectedValue.ToString(), BookingPassengerPhone_Box.Text, ScheduleOutboundID, FromPass+ToPass);
                if(ReturningPass) BookingPassengersGrid_View.Rows.Add(BookingPassengerFirstname_Box.Text, BookingPassengerLastname_Box.Text, BookingPassengerBirthdate_Picker.Value.ToShortDateString(), BookingPassengerPassportNum_Box.Text, BookingPassengerPassportCountry_Combobox.SelectedValue.ToString(), BookingPassengerPhone_Box.Text, ScheduleReturnID, ToPass + FromPass);
            }
            else MessageBox.Show("Fill all fields");
        }

        private void BookingRemovePassenger_Btn_Click(object sender, EventArgs e)
        {
            if (BookingPassengersGrid_View.CurrentRow != null)
            {
                BookingPassengersGrid_View.Rows.Remove(BookingPassengersGrid_View.CurrentRow);
            }
        }

        private void BookingConfirm_Btn_Click(object sender, EventArgs e)
        {
            int FullCost = 0;

            if (ReturningPass) FullCost = (BookingPassengersGrid_View.Rows.Count / 2 * OutboundCostPass) + (BookingPassengersGrid_View.Rows.Count / 2 * ReturnCostPass);
            else FullCost = BookingPassengersGrid_View.Rows.Count / 2 * OutboundCostPass;

            BillConfirm BillConfirmForm = new BillConfirm(FullCost);
            BillConfirmForm.Show();
        }

        public void ConfirmBill()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                foreach (DataGridViewRow Row in BookingPassengersGrid_View.Rows)
                {
                    cmd = new SqlCommand(String.Format("INSERT INTO Tickets (UserID, ScheduleID, CabinTypeID, Firstname, Lastname, Email, Phone, PassportNumber, PassportCountryID, BookingReference, Confirmed) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}', '{9}', '{10}')", UserID, Row.Cells[6].Value.ToString(), CabinPass, Row.Cells[0].Value.ToString(), Row.Cells[1].Value.ToString(), null, Row.Cells[5].Value.ToString(), Row.Cells[3].Value.ToString(), Row.Cells[4].Value.ToString(), Row.Cells[7].Value.ToString(), "True"), connection);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Success");
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
    }
}
