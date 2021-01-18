using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MailClient.ViewModels
{

    public class AuthViewModel
    {
        public UserData Data { get; set; }

        public AuthViewModel()
        {
            Data = new UserData();
        }

        public async Task<bool> Validate()
        {
            string emailPattern = @"\A[a-z0-9!#$%&'*+\/=?^_‘{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_‘{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\z";
            if (string.IsNullOrWhiteSpace(Data.Login) || string.IsNullOrWhiteSpace(Data.Password))
            {
                var dialog = new MessageDialog("Введите электронный адрес и пароль", "Ошибка авторизации");
                await dialog.ShowAsync();
                return false;
            }
            if (!Regex.IsMatch(Data.Login, emailPattern, RegexOptions.Multiline))
            {
                var dialog = new MessageDialog("Неверный формат электронного адреса", "Ошибка авторизации");
                await dialog.ShowAsync();
                return false;
            }
            return true;
        }
    }
}
