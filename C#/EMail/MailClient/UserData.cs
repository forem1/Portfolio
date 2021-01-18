using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MailClient
{
    public class UserData : INotifyPropertyChanged
    {
        private string _fullname;
        private string _login;
        private string _password;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Fullname { get => _fullname; set { _fullname = value; OnPropertyChanged(); } }
        public string Login { get => _login; set { _login = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
