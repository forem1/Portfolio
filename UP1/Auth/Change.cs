using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }

        private void ChangePass_Click(object sender, EventArgs e)
        {
            int rightOK = 0;
            String Login = textBox1.Text;
            String Password = textBox4.Text;
            String RePassword = textBox5.Text;
            String Name = textBox2.Text;
            String Phone = textBox3.Text;

            if (Login.Length <= 0 || Name.Length <= 0 || Password.Length <= 0 || RePassword.Length <= 0 || Phone.Length <= 0) MessageBox.Show("Ошибка! Заполнены не все поля");
            else
            {
                if (Password != RePassword) MessageBox.Show("Ошибка! Пароли не совпадают");
                else rightOK++;
                if (!Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$", RegexOptions.IgnoreCase)) MessageBox.Show("Ошибка! Пароль не соответствует условиям");
                else rightOK++;
                if (!Regex.IsMatch(Phone, @"^((\\+7-?)|8)?[0-9]{10}$", RegexOptions.IgnoreCase)) MessageBox.Show("Ошибка! Телефон не соответствует условиям");
                else rightOK++;
            }

            if (rightOK == 3)
            {
                INIManager manager = new INIManager(Directory.GetCurrentDirectory() + "\\Users.ini");

                if (manager.GetPrivateString(Login, "Name") == Name && manager.GetPrivateString(Login, "Phone") == Phone)
                {
                    manager.WritePrivateString(Login, "Password", Password);
                    Close();
                }
                else MessageBox.Show("Ошибка! Данные введены неправильно. Пароль не был изменен.");
            }
        }
    }
}
