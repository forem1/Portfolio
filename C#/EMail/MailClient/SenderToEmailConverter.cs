using MimeKit;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace MailClient
{
    public class SenderToEmailConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var sender = (InternetAddressList)value;
            var mailbox = sender.Mailboxes.FirstOrDefault();
            if (mailbox != null)
                return mailbox.Address;
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
