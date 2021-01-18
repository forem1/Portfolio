using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Classroom
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class register : Page
    {
        public register()
        {
            this.InitializeComponent();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            String Login = LoginReg.Text;
            String Password = PasswordReg.Password;
            String Key = KeyReg.Password;
            String role = null;
            String group = "";

            if (Login.Length <= 0 || Password.Length <= 0) Popup("Ошибка регистрации", "Заполнены не все поля");
            else
            {
                (sender as Button).IsEnabled = false;
                
                switch (Key)
                {
                    case "12345":
                        role = "Teacher";
                        break;
                    case "67890":
                        role = "Admin";
                        break;
                    default:
                        role = "Student";
                        break;
                }

                DataAccessClass.AddUser(Login, Password, role, group); // добавить шифрование

                Frame.Navigate(typeof(MainPage));
            }
        }

        void Popup(String text, String header)
        {
            MessageDialog messageDialog = new MessageDialog(header, text);
            _ = messageDialog.ShowAsync();
        }
    }
}
