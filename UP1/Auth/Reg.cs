using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Register(object sender, EventArgs e)
        {
            int rightOK = 0;
            String Login = textBox1.Text;
            String Password = textBox2.Text;
            String RePassword = textBox3.Text;
            String Name = textBox4.Text;
            String Passport = textBox5.Text;
            String Email = textBox7.Text;
            String Phone = textBox6.Text;

            if (Login.Length <= 0 || Passport.Length <= 0 || Name.Length <= 0 || Password.Length <= 0 || RePassword.Length <= 0 || Email.Length <= 0 || Phone.Length <= 0) MessageBox.Show("Ошибка! Заполнены не все поля");
            else
            {
                if (Password != RePassword) MessageBox.Show("Ошибка! Пароли не совпадают");
                else rightOK++;
                if (!Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$", RegexOptions.IgnoreCase)) MessageBox.Show("Ошибка! Пароль не соответствует условиям");
                else rightOK++;
                if (!Regex.IsMatch(Phone, @"^((\\+7-?)|8)?[0-9]{10}$", RegexOptions.IgnoreCase)) MessageBox.Show("Ошибка! Телефон не соответствует условиям");
                else rightOK++;
                if (Passport.Length != 10) MessageBox.Show("Ошибка! Серия и номер паспорта не соответствует условиям");
                else rightOK++;
                if (!Regex.IsMatch(Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase)) MessageBox.Show("Ошибка! Почта не соответствует условиям");
                else rightOK++;
            }
            if (rightOK == 5)
            {
                INIManager manager = new INIManager(Directory.GetCurrentDirectory() + "\\Users.ini");

                if (manager.GetPrivateString(Login, Password).Length != -1) {
                    manager.WritePrivateString(Login, "Password", Password);
                    manager.WritePrivateString(Login, "Name", Name);
                    manager.WritePrivateString(Login, "Passport", Passport);
                    manager.WritePrivateString(Login, "Email", Email);
                    manager.WritePrivateString(Login, "Phone", Phone);
                    Close();
                }
                else MessageBox.Show("Ошибка! Такой пользователь уже существует");
            }
        }
    }

    //Класс для чтения/записи INI-файлов
    public class INIManager
    {
        //Конструктор, принимающий путь к INI-файлу
        public INIManager(string aPath)
        {
            path = aPath;
        }

        //Конструктор без аргументов (путь к INI-файлу нужно будет задать отдельно)
        public INIManager() : this("") { }

        //Возвращает значение из INI-файла (по указанным секции и ключу) 
        public string GetPrivateString(string aSection, string aKey)
        {
            //Для получения значения
            StringBuilder buffer = new StringBuilder(SIZE);

            //Получить значение в buffer
            GetPrivateString(aSection, aKey, null, buffer, SIZE, path);

            //Вернуть полученное значение
            return buffer.ToString();
        }

        //Пишет значение в INI-файл (по указанным секции и ключу) 
        public void WritePrivateString(string aSection, string aKey, string aValue)
        {
            //Записать значение в INI-файл
            WritePrivateString(aSection, aKey, aValue, path);
        }

        //Возвращает или устанавливает путь к INI файлу
        public string Path { get { return path; } set { path = value; } }

        //Поля класса
        private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
        private string path = null; //Для хранения пути к INI-файлу

        //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

        //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateString(string section, string key, string str, string path);
    }

}
