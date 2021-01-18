using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using System.Text;
using System.Security.Cryptography;
using Windows.Storage;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Notifications;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Classroom
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            DataAccessClass.InitializeDatabase();
            this.InitializeComponent();
            gg.Text = ApplicationData.Current.LocalFolder.Path;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(register));
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(Admin));
            //Frame.Navigate(typeof(Student));
            //Frame.Navigate(typeof(Teacher));
            String Login = LoginL.Text;
            String Password = PasswordL.Password;

            if (Login.Length <= 0 || Password.Length <= 0) Popup("Ошибка авторизации", "Заполнены не все поля");
            else
            {
                (sender as Button).IsEnabled = false;

                switch (DataAccessClass.ValidateUser(Login, Password))
                {
                    case 0:
                        this.Frame.Navigate(typeof(Admin), null, new DrillInNavigationTransitionInfo());
                        break;
                    case 1:
                        Frame.Navigate(typeof(Teacher), LoginL.Text, new DrillInNavigationTransitionInfo());
                        break;
                    case 2:
                        Frame.Navigate(typeof(Student), LoginL.Text, new DrillInNavigationTransitionInfo());
                        break;
                    default:
                        Popup("Ошибка авторизации", "Ошибка входа");
                        (sender as Button).IsEnabled = true;
                        break;
                }

            }
        }

        static public void Popup(String text, String header)
        {
            MessageDialog messageDialog = new MessageDialog(header, text);
            _ = messageDialog.ShowAsync();
        }
    }
}

/*
*/
