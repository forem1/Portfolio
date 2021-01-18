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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegBtn(object sender, EventArgs e)
        {
            Reg frm = new Reg();
            frm.Show();
        }

        private void LogBtn(object sender, EventArgs e)
        {
            INIManager manager = new INIManager(Directory.GetCurrentDirectory() + "\\Users.ini");
            string Login = textBox1.Text;
            string Password = textBox2.Text;

            if (Login.Length <= 0 || Password.Length <= 0) MessageBox.Show("Ошибка! Заполнены не все поля");
            else if (Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$", RegexOptions.IgnoreCase)) {
                if (manager.GetPrivateString(Login, "Password").Length != -1 && manager.GetPrivateString(Login, "Password") == Password) MessageBox.Show("Привет," + manager.GetPrivateString(Login, "Name") +" "+ manager.GetPrivateString(Login, "Surname"));
                else MessageBox.Show("Ошибка! Неправильный логин или пароль");
            }
            else MessageBox.Show("Ошибка! Пароль не соответствует условиям");
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            Change cng = new Change();
            cng.Show();
        }
    }
}
