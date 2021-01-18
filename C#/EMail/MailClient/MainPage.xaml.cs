using System;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;
using MimeKit;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace MailClient
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private UserData _user;
        private string _newTo;
        private string _newSubject;
        private string _newMessage;
        private ImapClient imap;
        private IMailFolder _selectedFolder;
        private Message _selectedMessage;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<IMailFolder> Folders { get; set; }
        public IMailFolder SelectedFolder
        {
            get => _selectedFolder;
            set
            {
                _selectedFolder = value;
                NotifyPropertyChanged();
                GetMessages();
            }
        }
        public List<Message> Messages { get; set; }
        public Message SelectedMessage
        {
            get => _selectedMessage;
            set
            {
                _selectedMessage = value;
                NotifyPropertyChanged();
                GetMessageText();
            }
        }
        public string MessageText { get; set; }

        public string NewTo { get => _newTo; set { _newTo = value; NotifyPropertyChanged(); } }
        public string NewSubject { get => _newSubject; set { _newSubject = value; NotifyPropertyChanged(); } }
        public string NewMessage { get => _newMessage; set { _newMessage = value; NotifyPropertyChanged(); } }
        public UserData User { get => _user; set { _user = value; NotifyPropertyChanged(); } }

        public MainPage()
        {
            this.InitializeComponent();
            imap = new ImapClient();
        }

        public async void GetFolders()
        {
            try
            {
                await imap.ConnectAsync("imap.gmail.com", 993, true);

                await imap.AuthenticateAsync(User.Login, User.Password);
                Folders = new List<IMailFolder>((await imap.GetFoldersAsync(new FolderNamespace('/', ""), false)).Where(o => o.Exists));
                NotifyPropertyChanged("Folders");
            }
            catch
            {

                try
                {
                    await imap.ConnectAsync("imap.yandex.ru", 993, true);

                    await imap.AuthenticateAsync(User.Login, User.Password);
                    Folders = new List<IMailFolder>((await imap.GetFoldersAsync(new FolderNamespace('/', ""), false)).Where(o => o.Exists));
                    NotifyPropertyChanged("Folders");
                }
                catch
                {
                    try
                    {
                        await imap.ConnectAsync("imap.mail.ru", 993, true);

                        await imap.AuthenticateAsync(User.Login, User.Password);
                        Folders = new List<IMailFolder>((await imap.GetFoldersAsync(new FolderNamespace('/', ""), false)).Where(o => o.Exists));
                        NotifyPropertyChanged("Folders");
                    }
                    catch (Exception error)
                    {
                        var dialog = new MessageDialog(error.Message, "Ошибка авторизации");
                        await dialog.ShowAsync();
                    }
                }
            }
        }

        public async void GetMessages()
        {
            if (SelectedFolder == null) return;
            try
            {
                await Task.Factory.StartNew(() =>
            {
                lock (imap.SyncRoot)
                {
                    SelectedFolder.Open(FolderAccess.ReadOnly);
                    Messages = new List<Message>(SelectedFolder.Fetch(0, -1, MessageSummaryItems.Envelope).Select(o => new Message() { Summary = o, html = "" }));
                }

            });
                NotifyPropertyChanged("Messages");
            }
            catch (Exception error)
            {
                var dialog = new MessageDialog(error.Message, "Ошибка авторизации");
                await dialog.ShowAsync();
            }
        }

        public async void GetMessageText()
        {
            if (SelectedFolder == null || SelectedMessage == null) return;

            try
            {
                lock (imap.SyncRoot)
                {
                    SelectedFolder.Open(FolderAccess.ReadOnly);
                    var info = SelectedFolder.GetMessage(SelectedMessage.Summary.Index);
                    var message = info.HtmlBody ?? info.TextBody;
                    SelectedMessage.html = message == null ? "" : message;

                }
                NotifyPropertyChanged("SelectedMessage");
                NotifyPropertyChanged("Messages");
            }
            catch (Exception error)
            {
                var dialog = new MessageDialog(error.Message, "Ошибка авторизации");
                await dialog.ShowAsync();
            }
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            string emailPattern = @"\A[a-z0-9!#$%&'*+\/=?^_‘{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_‘{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\z";
            NewMessage = "";
            NewSubject = "";
            NewTo = SelectedMessage?.Summary.Envelope.From.Mailboxes.FirstOrDefault()?.Address ?? "";
            var result = await NewMessageDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    NewMessage = NewMessage.Trim();
                    NewSubject = NewSubject.Trim();
                    NewTo = NewTo.Trim();
                    if (string.IsNullOrWhiteSpace(NewSubject) || string.IsNullOrWhiteSpace(NewMessage) || !Regex.IsMatch(NewTo, emailPattern, RegexOptions.Multiline)) return;

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(User.Fullname, User.Login));
                    message.To.Add(new MailboxAddress(NewTo));
                    message.Subject = NewSubject;

                    message.Body = new TextPart("plain")
                    {
                        Text = NewMessage
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);

                        client.Authenticate(User.Login, User.Password);

                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
                catch
                {
                    try
                    {
                        NewMessage = NewMessage.Trim();
                        NewSubject = NewSubject.Trim();
                        NewTo = NewTo.Trim();
                        if (string.IsNullOrWhiteSpace(NewSubject) || string.IsNullOrWhiteSpace(NewMessage) || !Regex.IsMatch(NewTo, emailPattern, RegexOptions.Multiline)) return;

                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress(User.Fullname, User.Login));
                        message.To.Add(new MailboxAddress(NewTo));
                        message.Subject = NewSubject;

                        message.Body = new TextPart("plain")
                        {
                            Text = NewMessage
                        };

                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.yandex.ru", 587, false);

                            client.Authenticate(User.Login, User.Password);

                            client.Send(message);
                            client.Disconnect(true);
                        }
                    }
                    catch
                    {
                        try
                        {
                            NewMessage = NewMessage.Trim();
                            NewSubject = NewSubject.Trim();
                            NewTo = NewTo.Trim();
                            if (string.IsNullOrWhiteSpace(NewSubject) || string.IsNullOrWhiteSpace(NewMessage) || !Regex.IsMatch(NewTo, emailPattern, RegexOptions.Multiline)) return;

                            var message = new MimeMessage();
                            message.From.Add(new MailboxAddress(User.Fullname, User.Login));
                            message.To.Add(new MailboxAddress(NewTo));
                            message.Subject = NewSubject;

                            message.Body = new TextPart("plain")
                            {
                                Text = NewMessage
                            };

                            using (var client = new SmtpClient())
                            {
                                client.Connect("smtp.mail.ru", 587, false);

                                client.Authenticate(User.Login, User.Password);

                                client.Send(message);
                                client.Disconnect(true);
                            }
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                User = (UserData)e.Parameter;
                GetFolders();
            }
            base.OnNavigatedTo(e);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
