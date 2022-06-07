using System;
using System.Windows;
using System.IO.Ports;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PlatformDesktop
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        SerialPort sp = new SerialPort();
        public SettingsWindow(SerialPort ps)
        {
            InitializeComponent();
            sp = ps;
            
        }
        private string _pcFromArd = "%:s,0,s,10,1,0,0,0,1;";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sp.WriteLine(TextWrite.Text + "\n");
            
        }
        public void AddData(string data) 
        {
            RText.Document.Blocks.Add(new Paragraph(new Run(data)));
            RText.ScrollToEnd();
        }
       

        
    }
}
