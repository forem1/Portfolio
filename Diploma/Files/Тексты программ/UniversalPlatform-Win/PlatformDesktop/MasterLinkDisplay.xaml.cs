using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO.Ports;

namespace PlatformDesktop
{
    /// <summary>
    /// Логика взаимодействия для Dsip.xaml
    /// </summary>
    public partial class MasterLinkDisplay : Window
    {
        SerialPort sp = new SerialPort();

        String ticker = "";
        int row1 = 0;
        int row2 = 0;
        int row3 = 0;
        int row4 = 0;
        int row5 = 0;
        int row6 = 0;
        int row7 = 0;
        int row8 = 0;
        public MasterLinkDisplay(SerialPort serialPort)
        {
            sp = serialPort;
            InitializeComponent();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            Ticker.Text = "";
            ticker = "";

            String temp = (sender as CheckBox).Name;

            switch(temp.Split('_')[0].Replace("check", ""))
            {
                case "1":
                    if((sender as CheckBox).IsChecked == true) row1 += Convert.ToInt32(temp.Split('_')[1]);
                    else row1 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "2":
                    if ((sender as CheckBox).IsChecked == true) row2 += Convert.ToInt32(temp.Split('_')[1]);
                    else row2 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "3":
                    if ((sender as CheckBox).IsChecked == true) row3 += Convert.ToInt32(temp.Split('_')[1]);
                    else row3 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "4":
                    if ((sender as CheckBox).IsChecked == true) row4 += Convert.ToInt32(temp.Split('_')[1]);
                    else row4 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "5":
                    if ((sender as CheckBox).IsChecked == true) row5 += Convert.ToInt32(temp.Split('_')[1]);
                    else row5 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "6":
                    if ((sender as CheckBox).IsChecked == true) row6 += Convert.ToInt32(temp.Split('_')[1]);
                    else row6 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "7":
                    if ((sender as CheckBox).IsChecked == true) row7 += Convert.ToInt32(temp.Split('_')[1]);
                    else row7 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
                case "8":
                    if ((sender as CheckBox).IsChecked == true) row8 += Convert.ToInt32(temp.Split('_')[1]);
                    else row8 -= Convert.ToInt32(temp.Split('_')[1]);
                    break;
            }

            sendCommand();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ticker = Ticker.Text;
            
            sendCommand();

        }
        private void sendCommand()
        {
            String sendString = "*:" + ticker + "," + row1.ToString() + "," + row2.ToString() + "," + row3.ToString() + "," + row4.ToString() + "," + row5.ToString() + "," + row6.ToString() + "," + row7.ToString() + "," + row8.ToString() + ";\r\n" ;
            sp.WriteLine(sendString);
            Debug.WriteLine(sendString);
        }
    }
}
