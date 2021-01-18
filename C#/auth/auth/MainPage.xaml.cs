using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using System.Xml.Serialization;
using Windows.UI.Popups;
using System.Text.RegularExpressions;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace auth
{
    [Serializable]
    public class User {
        public string UserLogin;
        public string UserPassword;
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            String Login = LoginLogin.Text;
            String Password = LoginPassword.Password;

            if (Login.Length <= 0 || Password.Length <= 0) Popup("Ошибка регистрации", "Заполнены не все поля");
            else
            {
                if (!Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}", RegexOptions.IgnoreCase)) Popup("Ошибка регистрации", "Пароль не соответствует условиям");
                else
                {
                    (sender as Button).IsEnabled = false;
                    List<User> list = new List<User>();
                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    StorageFile file = await folder.CreateFileAsync("users.xml", CreationCollisionOption.OpenIfExists);

                    XmlSerializer xml = new XmlSerializer(typeof(List<User>));

                    Stream stream = await file.OpenStreamForReadAsync();
                    list = (List<User>)xml.Deserialize(stream);
                    stream.Close();
                    //Popup("", list[0].UserLogin.ToString());
                    //Popup("", list[0].UserPassword.ToString());
                    LoginLogin.Text = "";
                    LoginPassword.Password = "";
                    (sender as Button).IsEnabled = true;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (Login == list[i].UserLogin.ToString() && Password == list[i].UserPassword.ToString())
                        {
                            Popup("Успех!", "Успех!");
                        }
                        else
                        {
                            Popup("Ошибка!", "Вы не вошли");
                        }
                    }
                }
            }
        }

        void Popup(String text, String header)
        {
            MessageDialog messageDialog = new MessageDialog(header, text);
            _ = messageDialog.ShowAsync();
        }
    }
}
