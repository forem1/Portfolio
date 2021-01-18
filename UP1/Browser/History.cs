using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class History : Form
    {
        INIManager HistoryManager = new INIManager(Directory.GetCurrentDirectory() + "\\History.ini");
        int HistoryCount = 0;

        public History()
        {
            InitializeComponent();

            while (HistoryManager.GetPrivateString(HistoryCount.ToString(), "URL").Length != 0)
            {
                Console.WriteLine(HistoryManager);

                ListViewItem item = new ListViewItem(HistoryManager.GetPrivateString(HistoryCount.ToString(), "URL"));
                item.SubItems.Add(HistoryManager.GetPrivateString(HistoryCount.ToString(), "DATE"));
                listView1.Items.Add(item);
                HistoryCount++;
            }
        }
    }
}
