using MailKit;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace MailClient
{
    public class Message
    {
        public IMessageSummary Summary { get; set; }
        public string html { get; set; }
    }
}
