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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace auth
{
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void ReturnRegButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            int rightOK = 0;
            DateTime thisDay = DateTime.Today;
            String Login = LoginReg.Text;
            String Password = PassReg.Password;
            String RePassword = RePassReg.Password;
            String Birthday = BirthdayReg.SelectedDate.ToString();
            String Email = EmailReg.Text;
            String Passport = PassportReg.Text;
            String SNILS = SNILSReg.Text;
            String Phone = PhoneReg.Text;


            String[] Date = thisDay.Subtract(Convert.ToDateTime(Birthday)).ToString().Split('.');

            if (Login.Length <= 0 || Password.Length <= 0 || RePassword.Length <= 0 || Birthday.Length <= 0 || Email.Length <= 0 || Passport.Length <= 0 || SNILS.Length <= 0 || Phone.Length <= 0) Popup("Ошибка регистрации", "Заполнены не все поля");
            else
            {
                if (Password != RePassword) Popup("Ошибка регистрации", "Пароли не совпадают");
                else rightOK++;
                if (!Regex.IsMatch(Password, @" ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}", RegexOptions.IgnoreCase)) Popup("Ошибка регистрации", "Пароль не соответствует условиям");
                else rightOK++;
                
                if (!Regex.IsMatch(Phone, @"^((\\+7-?)|8)?[0-9]{10}$", RegexOptions.IgnoreCase)) Popup("Ошибка регистрации", "Телефон не соответствует условиям");
                else rightOK++;
                if (!Regex.IsMatch(Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase)) Popup("Ошибка регистрации", "E-mail не соответствует условиям");
                else rightOK++;
                if (Passport.Length != 10) Popup("Ошибка регистрации", "Паспорт не соответствует условиям");
                else rightOK++;
                if (SNILS.Length != 11) Popup("Ошибка регистрации", "СНИЛС не соответствует условиям");
                else rightOK++;
            }
            if (rightOK == 7)
            {
                (sender as Button).IsEnabled = false;
                List<User> list = new List<User>();
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.CreateFileAsync("users.xml", CreationCollisionOption.OpenIfExists);
                User user = new User()
                {
                    UserLogin = Login,
                    UserPassword = Password
                };
                XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                Stream stream = await file.OpenStreamForReadAsync();
                try
                {
                    list = (List<User>)xml.Deserialize(stream);
                }
                catch
                {
                    list = new List<User>();
                }
                stream.Close();
                list.Add(user);
                stream = await file.OpenStreamForWriteAsync();
                xml.Serialize(stream, list);
                stream.Close();
                /*LoginReg.Text = "";
                PassReg.Password = "";
                RePassReg.Password = "";
                PhoneReg.Text = "";
                SNILSReg.Text = "";
                EmailReg.Text = "";
                PassportReg.Text = "";*/
                FolderBox.Text = folder.Path;
                (sender as Button).IsEnabled = true;
            }
        }

        void Popup(String text, String header)
        {
            MessageDialog messageDialog = new MessageDialog(header, text);
            _ = messageDialog.ShowAsync();
        }

        private void SNILS_TextChanged(object sender, TextChangedEventArgs e)
        {
            SNILSReg.Text = Regex.Replace(SNILSReg.Text, @"[^0-9+-,]+", "");
        }
        private void Passport_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassportReg.Text = Regex.Replace(PassportReg.Text, @"[^0-9+-,]+", "");
        }
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneReg.Text = Regex.Replace(PhoneReg.Text, @"[^0-9+-,]+", "");
        }
    }
}
