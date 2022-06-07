using System.Windows;
using System.Windows.Media;

namespace PlatformDesktop
{
    /// <summary>
    /// Логика взаимодействия для MasterLink.xaml
    /// </summary>
    public partial class MasterLinkManual : Window
    {
        public int GPIO1Value = 0;
        public int GPIO2Value = 0;
        public int GPIO3Value = 0;
        public int GPIO4Value = 0;
        public MasterLinkManual()
        {
            InitializeComponent();
        }


        public bool Gpio1ButtonState = false;
        public bool Gpio2ButtonState = false;
        public bool Gpio3ButtonState = false;
        public bool Gpio4ButtonState = false;

        private void Gpio1Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Gpio1ButtonState)
            {
                GPIO1Value = 1;
                Gpio1Btn.Background = Brushes.Green;
                Gpio1ButtonState = true;
            }
            else
            {
                GPIO1Value = 0;
                Gpio1Btn.Background = Brushes.Gray;
                Gpio1ButtonState = false;
            }
        }
        private void Gpio2Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Gpio2ButtonState)
            {
                GPIO2Value = 1;
                Gpio2Btn.Background = Brushes.Green;
                Gpio2ButtonState = true;
            }
            else
            {
                GPIO2Value = 0;
                Gpio2Btn.Background = Brushes.Gray;
                Gpio2ButtonState = false;
            }
        }

        private void Gpio3Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Gpio3ButtonState)
            {
                GPIO3Value = 1;
                Gpio3Btn.Background = Brushes.Green;
                Gpio3ButtonState = true;
            }
            else
            {
                GPIO3Value = 0;
                Gpio3Btn.Background = Brushes.Gray;
                Gpio3ButtonState = false;
            }
        }

        private void Gpio4Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Gpio4ButtonState)
            {
                GPIO4Value = 1;
                Gpio4Btn.Background = Brushes.Green;
                Gpio4ButtonState = true;
            }
            else
            {
                GPIO4Value = 0;
                Gpio4Btn.Background = Brushes.Gray;
                Gpio4ButtonState = false;
            }
        }
    }
}
