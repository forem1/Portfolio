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
    public partial class Downloads : Form
    {
        INIManager DownloadManager = new INIManager(Directory.GetCurrentDirectory() + "\\Downloads.ini");
        int DownloadsCount = 0;

        public Downloads()
        {
            InitializeComponent();

            while (DownloadManager.GetPrivateString(DownloadsCount.ToString(), "URL").Length != 0)
            {
                Console.WriteLine(DownloadsCount);

                ListViewItem item = new ListViewItem(DownloadManager.GetPrivateString(DownloadsCount.ToString(), "PATH"));
                item.SubItems.Add(DownloadManager.GetPrivateString(DownloadsCount.ToString(), "URL"));
                item.SubItems.Add(DownloadManager.GetPrivateString(DownloadsCount.ToString(), "DATE"));
                listView2.Items.Add(item);
                DownloadsCount++;
            }
        }
    }
}
