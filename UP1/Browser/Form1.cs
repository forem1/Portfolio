using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : Form
    {
        Dictionary<int, WebBrowser> pages = new Dictionary<int, WebBrowser>(); //Хранилище вкладок
        INIManager DownloadManager = new INIManager(Directory.GetCurrentDirectory() + "\\Downloads.ini"); //Загрузки
        INIManager HistoryManager = new INIManager(Directory.GetCurrentDirectory() + "\\History.ini"); //История
        String URL = "http://google.com"; //Адрес по умолчанию
        int DownloadsCount = 0; //id загрузки
        int HistoryCount = 0; //id истории

        public Form1()
        {
            InitializeComponent();

            while (DownloadManager.GetPrivateString(DownloadsCount.ToString(), "URL").Length != 0)
            {
                DownloadsCount++;
            }

            while (HistoryManager.GetPrivateString(HistoryCount.ToString(), "URL").Length != 0)
            {
                HistoryCount++;
            }
        }

        private void tabControl1_Selected(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == tabControl1.TabPages.Count - 1)
            {
                TabPage tabpage = new TabPage("New tab");

                WebBrowser webcontrol = new WebBrowser();
                webcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
                webcontrol.Navigate(URL); //ПоМЕТОЧка
                webcontrol.Navigating += WebDocumentNavigate;
                webcontrol.DocumentTitleChanged += WebDocumentTitleChanged;
                pages.Add(e.TabPageIndex, webcontrol);

                tabpage.Controls.Add(webcontrol);
                tabControl1.TabPages.Add(tabpage);

                try
                {
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
                catch { }

                tabControl1.TabPages.Add(new TabPage("+"));
                tabControl1.SelectTab(e.TabPageIndex);

               //ShowIterator<int, WebBrowser>(pages); //отладка
            }

            try
            {
                URLBox.Text = pages[tabControl1.SelectedIndex].Url.AbsoluteUri;
            }
            catch { }
        }

        private void WebDocumentNavigate(object sender, WebBrowserNavigatingEventArgs e)
        {
            HistoryManager.WritePrivateString(HistoryCount.ToString(), "URL", e.Url.AbsoluteUri);
            HistoryManager.WritePrivateString(HistoryCount.ToString(), "DATE", DateTime.Now.ToString());
            HistoryCount++;

            if (e.Url.Segments[e.Url.Segments.Length - 1].EndsWith(".pdf") || e.Url.Segments[e.Url.Segments.Length - 1].EndsWith(".png") || e.Url.Segments[e.Url.Segments.Length - 1].EndsWith(".jpeg") || e.Url.Segments[e.Url.Segments.Length - 1].EndsWith(".jpg"))
            {
                e.Cancel = true;
                string filepath = null;

                saveFileDialog1.FileName = e.Url.Segments[e.Url.Segments.Length - 1];
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = saveFileDialog1.FileName;
                    WebClient client = new WebClient();
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(e.Url, filepath);

                    DownloadManager.WritePrivateString(DownloadsCount.ToString(), "URL", e.Url.AbsoluteUri);
                    DownloadManager.WritePrivateString(DownloadsCount.ToString(), "PATH", filepath);
                    DownloadManager.WritePrivateString(DownloadsCount.ToString(), "DATE", DateTime.Now.ToString());
                    DownloadsCount++;
                }
            }
        } //Обрабатываем сохранение

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File downloaded");
        }

        private void WebDocumentTitleChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Text = (sender as WebBrowser).DocumentTitle; //меняет заголовок активной
        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
           pages.Remove(tabControl1.SelectedIndex);
           //ShowIterator<int, WebBrowser>(pages); //отладка

            //tabControl1.SelectedTab.Parent = null;

            Dictionary<int, WebBrowser> temppages = new Dictionary<int, WebBrowser>();
            int t = 0;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                try
                {
                    temppages.Add(t, pages[i]);
                    t++;
                }
                catch {}
            }
            pages.Clear();
            pages = temppages;

            //ShowIterator<int, WebBrowser>(pages); //отладка
            //ShowIterator<int, WebBrowser>(temppages); //отладка

            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        } //удаление вкладки двойным кликом. Не Работает удаление

        private void ReturnBtnClick(object sender, EventArgs e)
        {
            try
            {
                pages[tabControl1.SelectedIndex].GoBack();
            }
            catch { }
        } //назад

        private void FowardBtnClick(object sender, EventArgs e)
        {
            try
            {
                pages[tabControl1.SelectedIndex].GoForward();
            }
            catch { }
        } //вперед

        private void RefreshBtnClick(object sender, EventArgs e)
        {
            try
            { pages[tabControl1.SelectedIndex].Refresh(); }
            catch { }
        } //обновить

        private void GoToBtn_Click(object sender, EventArgs e)
        {
            String TempURL = URLBox.Text;
            Uri uriResult;

            if (TempURL.Length == 0) pages[tabControl1.SelectedIndex].Navigate(TempURL);
            else if (Uri.TryCreate(TempURL, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                try
                {
                    pages[tabControl1.SelectedIndex].Navigate(URLBox.Text);
                }
                catch { }
            else
                try
                {
                    pages[tabControl1.SelectedIndex].Navigate("https://www.google.com/search?newwindow=1&q=" + TempURL);
                }
                catch { }
        } //переход по URL

        void ShowIterator<K, V>(Dictionary<K, V> myList)
        {
            if (myList == null)
                return;

            string s = "";

            foreach (KeyValuePair<K, V> kvp in myList)
                s += string.Format("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value) + Environment.NewLine;

            MessageBox.Show(s);
        } //отладка Dictionary

        private void DownloadsBtn_Click(object sender, EventArgs e)
        {
            Downloads dwn = new Downloads();
            dwn.Show();
        } //Открываем Загрузки

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                pages[tabControl1.SelectedIndex].Navigate(URL);
            }
            catch { }
        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            History hst = new History();
            hst.Show();
        }
    }

    //Класс для чтения/записи INI-файлов
    public class INIManager
    {
        //Конструктор, принимающий путь к INI-файлу
        public INIManager(string aPath)
        {
            path = aPath;
        }

        //Конструктор без аргументов (путь к INI-файлу нужно будет задать отдельно)
        public INIManager() : this("") { }

        //Возвращает значение из INI-файла (по указанным секции и ключу) 
        public string GetPrivateString(string aSection, string aKey)
        {
            //Для получения значения
            StringBuilder buffer = new StringBuilder(SIZE);

            //Получить значение в buffer
            GetPrivateString(aSection, aKey, null, buffer, SIZE, path);

            //Вернуть полученное значение
            return buffer.ToString();
        }

        //Пишет значение в INI-файл (по указанным секции и ключу) 
        public void WritePrivateString(string aSection, string aKey, string aValue)
        {
            //Записать значение в INI-файл
            WritePrivateString(aSection, aKey, aValue, path);
        }

        //Возвращает или устанавливает путь к INI файлу
        public string Path { get { return path; } set { path = value; } }

        //Поля класса
        private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
        private string path = null; //Для хранения пути к INI-файлу

        //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

        //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateString(string section, string key, string str, string path);
    }
}
