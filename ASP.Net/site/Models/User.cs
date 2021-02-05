using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Введите правильный Email")]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Поле {0} должно содержать буквы, цифры и быть не менее 8 символов")]
        [Display(Name = "Пароль")]
        public string Password { set; get; }

    }
}
