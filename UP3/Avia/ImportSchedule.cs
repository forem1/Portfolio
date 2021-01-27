using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avia
{
    public partial class ImportSchedule : Form
    {
        public String conStr = "Data Source=ANDREYNOTE\\FOREMDB;Initial Catalog=session;Persist Security Info=True;User ID=sa;Password=12345";
        private SqlConnection connection;
        private SqlCommand cmd;

        public ImportSchedule()
        {
            InitializeComponent();
        }

        private void ImportScheduleImport_Btn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "schedule Files|*.csv";
            dialog.Title = "Select schedule files";
            if (dialog.ShowDialog() == DialogResult.OK) {
                if (dialog.FileName != null)
                {
                    ImportSchedulePath_Box.Text = dialog.FileName;

                    using (TextFieldParser parser = new TextFieldParser(dialog.FileName))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            string[] fields = parser.ReadFields();
                            foreach (string field in fields)
                            {
                                MessageBox.Show(field);
                            }
                        }
                    }
                }
            }
        }
    }
}
