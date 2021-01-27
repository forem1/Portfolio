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
    public partial class AmenitiesReport : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;
        private DataSet DS;
        private SqlDataAdapter da;
        private SqlDataReader ExecuteReader;

        public AmenitiesReport()
        {
            InitializeComponent();

            UpdateGrid();
        }

        public void UpdateGrid()
        {
            connection = new SqlConnection(conStr);
            try
            {
                connection.Open();

                DataSet DSAmenities = new DataSet();
                SqlDataAdapter DAAmenities = new SqlDataAdapter("SELECT DISTINCT Service AS 'Amenity', (SELECT COUNT(Service) FROM Amenities WHERE TicketID = ID AND CabinTypeID = 1) AS 'Economy', (SELECT COUNT(Service) FROM Amenities WHERE TicketID = ID AND CabinTypeID = 2) AS 'Business', (SELECT COUNT(Service) FROM Amenities WHERE TicketID = ID AND CabinTypeID = 3) AS 'First' FROM AmenitiesTickets INNER JOIN Amenities ON AmenitiesTickets.AmenityID = Amenities.ID INNER JOIN Tickets ON AmenitiesTickets.TicketID = Tickets.ID", connection);
                DAAmenities.Fill(DSAmenities);

                AmenitiesReportGrid_View.DataSource = DSAmenities.Tables[0];
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
