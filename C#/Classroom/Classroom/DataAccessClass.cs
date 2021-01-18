using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.Security.Cryptography;
using System.Text;

namespace Classroom
{
    public static class DataAccessClass
    {
        static string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Journal.sqlite");
        public static void InitializeDatabase()
        {


            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS Users (id INTEGER PRIMARY KEY, login VARCHAR UNIQUE NOT NULL, password VARCHAR NOT NULL, userRole TEXT, userGroup TEXT);" + "CREATE TABLE IF NOT EXISTS Disciplines (id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Description TEXT, Active  INTEGER NOT NULL DEFAULT 1);" + "CREATE TABLE IF NOT EXISTS Marks (id INTEGER PRIMARY KEY, Student TEXT NOT NULL, Teacher TEXT NOT NULL, Discipline INTEGER NOT NULL, Mark INTEGER NOT NULL, Date DATE NOT NULL, Groups TEXT NOT NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static int ValidateUser(string login, string password)
        {

            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = $"SELECT * FROM Users WHERE login = '{login}' AND password = '{GetHash(password)}'";

                SqliteCommand command = new SqliteCommand(tableCommand, db);

                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString(3) == "Admin") return 0;
                    if (reader.GetString(3) == "Teacher") return 1;
                    if (reader.GetString(3) == "Student") return 2;
                }

                return -1;
            }

        }
        public static int AddUser(string login, string password, string role, string group)
        {

            if (login != "" && password != "")
            {
                using (SqliteConnection db =
                   new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"INSERT INTO users(login, password, userRole, userGroup) VALUES('{login}', '{GetHash(password)}', '{role}','{group}')";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static int ChangeUserData(int id, string login, string password, string role, string group)
        {
            if (id != -1)
            {
                using (SqliteConnection db = new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"UPDATE Users SET login = '{login}', password = '{password}', userRole = '{role}', userGroup = '{group}' WHERE id = {id}";

                    try
                    {
                     SqliteCommand command = new SqliteCommand(tableCommand, db);

                    command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public static int DeleteUser(int id)
        {
            if (id != -1)
            {
                using (SqliteConnection db = new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"DELETE FROM users WHERE id = {id}";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

//------------------------------------------------------------------------------------------

        public static int AddDiscipline(string name, string description)
        {

            if (name != "")
            {
                using (SqliteConnection db =
                   new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"INSERT INTO Disciplines(Name, Description) VALUES('{name}', '{description}')";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static int DeactivateDiscipline(int id)
        {
            if (id != -1)
            {
                using (SqliteConnection db = new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"UPDATE Disciplines SET Active = 0 WHERE id = {id}";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public static int ChangeDisciplineData(int id, string name, string description, int activate)
        {
            if (id != -1)
            {
                using (SqliteConnection db = new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"UPDATE Users SET Name = '{name}', Description = '{description}', Active = {activate} WHERE id = {id}";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        //-------------------------------------------------------------------------------------------------------------------

        public static int DeleteMark(int id)
        {
            if (id != -1)
            {
                using (SqliteConnection db = new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"DELETE FROM Marks WHERE id = {id}";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public static int AddMark(string student, string teacher, string discipline, int mark, string date, string group)
        {

            if (student != "" || teacher != "" || date != "")
            {
                using (SqliteConnection db =
                   new SqliteConnection($"Data Source ={dbpath}"))
                {
                    db.Open();

                    String tableCommand = $"INSERT INTO Marks(Student, Teacher, Discipline, Mark, Date, Groups) VALUES('{student}', '{teacher}', '{discipline}','{mark}','{date}','{group}');";

                    try
                    {
                        SqliteCommand command = new SqliteCommand(tableCommand, db);

                        command.ExecuteReader();
                    }
                    catch (SqliteException)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }


        public static ObservableCollection<Classroom.Discipline> GetDisciplines()
        {
            ObservableCollection<Classroom.Discipline> Disciplines = new ObservableCollection<Classroom.Discipline>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                string tableCommand = $"SELECT * FROM Disciplines";

                SqliteCommand command = new SqliteCommand(tableCommand, db);

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Disciplines.Add(new Classroom.Discipline(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                }
                return Disciplines;
            }

        }

        public static ObservableCollection<Classroom.User> GetUsers(string role)
        {
            ObservableCollection<Classroom.User> users = new ObservableCollection<Classroom.User>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "";
                if (role == "") tableCommand = $"SELECT * FROM Users";
                else tableCommand = $"SELECT * FROM Users WHERE userRole = '{role}'";

                SqliteCommand command = new SqliteCommand(tableCommand, db);

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new Classroom.User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }
                return users;
            }

        }

        public static ObservableCollection<Classroom.Mark> GetMarks(string student, string group)
        {
            
                ObservableCollection<Classroom.Mark> Marks = new ObservableCollection<Classroom.Mark>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "";

            if (student == "" && group == "") tableCommand = $"SELECT * FROM Marks";
            else if(group != "") tableCommand = $"SELECT * FROM Marks WHERE Groups = '{group}'";
                else tableCommand = $"SELECT * FROM Marks WHERE Student = '{student}'";

               SqliteCommand command = new SqliteCommand(tableCommand, db);

                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Marks.Add(new Classroom.Mark(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6)));
                }
                return Marks;
            }
        }

        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var temp = md5.ComputeHash(Encoding.UTF8.GetBytes(input)) + "1cg42g"; // находим хеш, добавляем соль и опять находим хеш
            var temps = MD5.Create();
            var hash = temps.ComputeHash(Encoding.UTF8.GetBytes(temp));


            return Convert.ToBase64String(hash);
        }
    }
}
