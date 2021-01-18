using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email
{
    public partial class Form1 : Form
    {
        INIManager manager = new INIManager(Directory.GetCurrentDirectory() + "\\User.ini");
        public Form1()
        {
            InitializeComponent();
            EmailBox.Text = manager.GetPrivateString("User", "Login");
            PasswordBox.Text = manager.GetPrivateString("User", "Password");
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            String Email = EmailBox.Text;
            String Password = PasswordBox.Text;
            String To = ToBox.Text;
            String Subject = SubjectBox.Text;
            String Message = MessageBox.Text;

            if (Regex.IsMatch(Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase) && Password != "" && Regex.IsMatch(To, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase))
            {

                manager.WritePrivateString("User", "Login", Email);
                manager.WritePrivateString("User", "Password", Password);

                MailAddress from = new MailAddress(Email);
                MailAddress to = new MailAddress(To);
                MailMessage m = new MailMessage(from, to);

                if(Subject == "") m.Subject = "Без темы";
                else m.Subject = Subject;

                if (Message == "") m.Body = "Без сообщения";
                else m.Body = Message;

                SmtpClient smtp = new SmtpClient();
                try
                {
                    smtp = new SmtpClient("smtp.gmail.com", 587);
                }
                catch
                {
                    try
                    {
                        smtp = new SmtpClient("smtp.yandex.ru", 587);
                    }
                    catch
                    {
                        try
                        {
                            smtp = new SmtpClient("smtp.mail.ru", 587);
                        }
                        catch
                        {
                               label6.Text = "Не удалось подключиться к почтовому серверу";
                        }
                    }
                }
                
                smtp.Credentials = new NetworkCredential(Email, Password);
                smtp.EnableSsl = true;
                try {
                    smtp.Send(m);
                    label6.Text = "Отправлено";
                }
                catch {
                    label6.Text = "Ошибка отправки";
                }
                
            }
            else
            {
                label6.Text = "Заполнены не все поля или неправильно введен адрес";
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
