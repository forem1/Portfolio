using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avia
{
    public partial class BillConfirm : Form
    {
        public BillConfirm(int FullCost)
        {
            InitializeComponent();

            BillingTotal_Label.Text = "Total amount: " + FullCost.ToString();
        }

        private void BillConfirm_Btn_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["BookingFlight"] as BookingFlight).ConfirmBill();
            this.Close();
        }

        private void BillCancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
