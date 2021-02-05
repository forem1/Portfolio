using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    public class User
    {
        public bool Add(string userId, string phone, string email, string sex, int passport)
        {
            if (userId.Length < 4)
            {
                throw new Exception("UserId должен быть больше 4 символов");
            }

            if (phone.Contains("a"))
            {
                throw new Exception("Телефон должен содержать только цифры");
            }

            if (!email.Contains("@"))
            {
                throw new Exception("Ошибка в email адресе");
            }
            
            if (!sex.Contains("male"))
            {
                throw new Exception("Ошибка в указании пола");
            }

            if (passport < 10)
            {
                throw new Exception("Ошибка в указании пасспорта");
            }

            return true;

        }
    }
}
