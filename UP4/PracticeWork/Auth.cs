using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWork
{
    public partial class Auth : Form
    {
        private string baseName = "DB.db3";

        private SQLiteConnection connection = new SQLiteConnection();
        private SQLiteCommand cmd = new SQLiteCommand();
        private SQLiteDataReader ExecuteReader;

        public Auth()
        {
            InitializeComponent();

            if (!File.Exists(baseName))
            {
                SQLiteConnection.CreateFile(baseName);

                try
                {
                    connection = new SQLiteConnection("Data Source=" + baseName);
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText = @"CREATE TABLE [Users] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Login] TEXT NOT NULL,
                    [Password] TEXT NOT NULL
                    );
                    CREATE TABLE [TypeOfActivity] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name] TEXT NOT NULL
                    );
                    CREATE TABLE [FormOfControl] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name] TEXT NOT NULL
                    );
                    CREATE TABLE [CategoryOfTeacher] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name] TEXT NOT NULL
                    );
                    CREATE TABLE [Groups] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name] TEXT NOT NULL,
                    [Faculty] TEXT NOT NULL,
                    [Department] TEXT NOT NULL
                    );
                    CREATE TABLE [Students] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Initials] TEXT NOT NULL,
                    [Course] INTEGER NOT NULL,
                    [GroupId] INTENGER NOT NULL
                    );
                    CREATE TABLE [Teachers] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Initials] TEXT NOT NULL,
                    [CategoryId] INTENGER NOT NULL
                    );
                    CREATE TABLE [StudyPlans] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Name] TEXT NOT NULL,
                    [Course] INTENGER NOT NULL,
                    [Semester] TEXT NOT NULL,
                    [Hours] INTENGER NOT NULL,
                    [TeacherId] INTENGER NOT NULL,
                    [FormId] INTENGER NOT NULL,
                    [TypeId] INTENGER NOT NULL
                    );
                    CREATE TABLE [StudyOrders] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Department] TEXT NOT NULL,
                    [StudyPlanId] INTENGER NOT NULL,
                    [GroupId] INTENGER NOT NULL
                    );
                    CREATE TABLE [Marks] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Rating] Text NOT NULL,
                    [StudentId] INTENGER NOT NULL,
                    [StudyPlanId] INTENGER NOT NULL
                    );
                    CREATE TABLE [Diploms] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Number] INTEGER NOT NULL,
                    [StudentId] INTEGER NOT NULL,
                    [TeacherId] INTEGER NOT NULL
                    );";

                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();

                    DataForm DataFormForm = new DataForm();
                    DataFormForm.Show();
                }
            }
            else
            {
                DataForm DataFormForm = new DataForm();
                DataFormForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");

            if (regex.IsMatch(Password) && Login.Length >= 3)
            {
              

                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("SELECT * FROM Users WHERE Login='{0}'", Login), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read())
                    {
                        if (ExecuteReader["Password"].ToString() == Password)
                        {
                            MessageBox.Show("Добро пожаловать, " + Login + "!");
                            this.Hide();
                        }
                        else MessageBox.Show("Неправильный логин или пароль");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else MessageBox.Show("Пароль/логин не соответствует условиям");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            bool ok = true;

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}");

            if (regex.IsMatch(Password) && Login.Length >= 3)
            {
                connection = new SQLiteConnection("Data Source=" + baseName);
                try
                {
                    connection.Open();
                    cmd = new SQLiteCommand(String.Format("SELECT * FROM Users WHERE Login='{0}'", Login), connection);
                    ExecuteReader = cmd.ExecuteReader();
                    while (ExecuteReader.Read()) if (ExecuteReader["Id"].ToString().Length > 0) ok = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                connection = new SQLiteConnection("Data Source=" + baseName);
                if (ok)
                {
                    try
                    {
                        connection.Open();
                        cmd = new SQLiteCommand(String.Format("INSERT INTO Users (Login, Password) VALUES ('{0}','{1}')", Login, Password), connection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Упех!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else MessageBox.Show("Такой логин уже существует");
            }
            else MessageBox.Show("Пароль/логин не соответствует условиям");
        }
    }
}
