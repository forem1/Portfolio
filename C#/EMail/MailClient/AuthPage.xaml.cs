using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MailClient.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MailClient
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AuthPage : Page
    {
        public AuthViewModel ViewModel { get; set; } = new AuthViewModel();

        public AuthPage()
        {
            this.InitializeComponent();
        }

        private async void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var isValid = await ViewModel.Validate();
            if (!isValid) return;
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(ViewModel.Data.Login, ViewModel.Data.Password);
                    client.Disconnect(true);
                }
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate(ViewModel.Data.Login, ViewModel.Data.Password);
                    client.Disconnect(true);
                }
                Frame.Navigate(typeof(MainPage), ViewModel.Data);
            } catch
            {
                try
                {
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.yandex.ru", 587, false);
                        client.Authenticate(ViewModel.Data.Login, ViewModel.Data.Password);
                        client.Disconnect(true);
                    }
                    using (var client = new ImapClient())
                    {
                        client.Connect("imap.yandex.ru", 993, true);
                        client.Authenticate(ViewModel.Data.Login, ViewModel.Data.Password);
                        client.Disconnect(true);
                    }
                    Frame.Navigate(typeof(MainPage), ViewModel.Data);
                }
                catch
                {
                    try
                    {
                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.mail.ru", 587, false);
                            client.Authenticate(ViewModel.Data.Login, ViewModel.Data.Password);
                            client.Disconnect(true);
                        }
                        using (var client = new ImapClient())
                        {
                            client.Connect("imap.mail.ru", 993, true);
                            client.Authenticate(ViewModel.Data.Login, ViewModel.Data.Password);
                            client.Disconnect(true);
                        }
                        Frame.Navigate(typeof(MainPage), ViewModel.Data);
                    }
                    catch (Exception error)
                    {
                        var dialog = new MessageDialog(error.Message, "Ошибка авторизации");
                        await dialog.ShowAsync();
                    }
                }
            }
        }
    }

}
