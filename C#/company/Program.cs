using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace company
{
    class Program
    {
        static PrintDocument PD = new PrintDocument();
        static string result = "";

        static void Main(string[] args)
        {
            //int Role = Login();
            int Role = 0;

            int k, s = 0;
            int BuyCount = 1;
            int UserCount = 1;
            do
            {
                Console.Clear();
                Console.WriteLine(((s == 0) ? "==>" : " ") + "Склад");
                Console.WriteLine(((s == 1) ? "==>" : " ") + "Отдел кадров");
                Console.WriteLine(((s == 2) ? "==>" : " ") + "Бухгалтерия");
                Console.WriteLine(((s == 3) ? "==>" : " ") + "Касса");
                k = (int)Console.ReadKey().Key;
                if (k == 38) s--;
                if (k == 40) s++;
                if (s > 3) s = 0;
                if (s < 0) s = 3;
                else if (k == 13 && s == 0 && (Role == 3 || Role == 0)) //warehouse
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(((s == 0) ? "==>" : " ") + "Смотреть Склад");
                        Console.WriteLine(((s == 1) ? "==>" : " ") + "Добавить товар");
                        Console.WriteLine(((s == 2) ? "==>" : " ") + "Удалить товар");
                        k = (int)Console.ReadKey().Key;
                        if (k == 38) s--;
                        if (k == 40) s++;
                        if (s > 2) s = 0;
                        if (s < 0) s = 2;

                        else if (k == 13 && s == 0)
                        {
                            StreamReader reader;
                            try
                            {
                                FileStream file1 = new FileStream("C:\\Magazine\\warehouse\\" + Scan() + ".txt", FileMode.Open, FileAccess.ReadWrite);
                                reader = new StreamReader(file1);
                            }
                            catch
                            {
                                Console.WriteLine("Товар не найден");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ReadLine();
                        }
                        else if (k == 13 && s == 1)
                        {
                            StreamWriter wrt;
                            try
                            {
                                FileStream file1 = new FileStream("C:\\Magazine\\warehouse\\" + Scan() + ".txt", FileMode.CreateNew, FileAccess.ReadWrite);
                                wrt = new StreamWriter(file1);
                            }
                            catch
                            {
                                Console.WriteLine("Товар существует");
                                Console.ReadKey();
                                break;
                            }
                            string[] mass = new string[5];
                            string proovarka;
                            int i = 0, i2;
                            do
                            {
                                Console.WriteLine("Введите имя товара");
                                mass[0] = Console.ReadLine();
                                proovarka = mass[0];
                            } while ((proovarka == null) || (proovarka[0].ToString() == " ") || (proovarka.Length > 248));

                            do
                            {
                                i = 0;
                                Console.WriteLine("Кол-во товара:");
                                mass[1] = Console.ReadLine();
                                proovarka = mass[1];
                                if (!(int.TryParse(proovarka, out i2)))
                                {
                                    i = 2;
                                }
                            } while ((i == 2));

                            do
                            {
                                i = 0;
                                Console.WriteLine("Стоимость товара:");
                                mass[2] = Console.ReadLine();
                                proovarka = mass[2];
                                if (!(int.TryParse(proovarka, out i2)))
                                {
                                    i = 2;
                                }
                            } while ((i == 2));
                            wrt.WriteLine(mass[0] + "_" + mass[2] + "_" + mass[2] + "_" + mass[3]);
                            wrt.Close();
                            Console.ReadLine();
                            break;
                        }
                        else if (k == 13 && s == 2)
                        {
                            try
                            {
                                System.IO.File.Delete("C:\\Magazine\\warehouse\\" + Scan() + ".txt");
                                Console.WriteLine("Удалено");
                                Console.ReadKey();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Товар не найден");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                }
                else if (k == 13 && s == 1 && (Role == 1 || Role == 0)) //HR
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(((s == 0) ? "==>" : " ") + "Список сотрудников");
                        Console.WriteLine(((s == 1) ? "==>" : " ") + "Добавить сотрудника");
                        Console.WriteLine(((s == 2) ? "==>" : " ") + "Удалить сотрудника");
                        k = (int)Console.ReadKey().Key;
                        if (k == 38) s--;
                        if (k == 40) s++;
                        if (s > 2) s = 0;
                        if (s < 0) s = 2;

                        else if (k == 13 && s == 0)
                        {
                            Console.WriteLine("Ведите номер сотрудника");
                            int Count;
                            while (!int.TryParse(Console.ReadLine(), out Count))
                            {
                                Console.WriteLine("Введите число");
                            }
                            StreamReader reader;
                            try
                            {
                                FileStream file1 = new FileStream("C:\\Magazine\\Users\\" + Count + ".txt", FileMode.Open, FileAccess.ReadWrite);
                                reader = new StreamReader(file1);
                            }
                            catch
                            {
                                Console.WriteLine("Сотрудник не найден");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine(reader.ReadToEnd());
                            reader.Close();
                            Console.ReadLine();
                        }
                        else if (k == 13 && s == 1)
                        {
                            StreamWriter wrt;
                            try
                            {
                                FileStream file1 = new FileStream("C:\\Magazine\\Users\\" + UserCount + ".txt", FileMode.CreateNew, FileAccess.ReadWrite);
                                wrt = new StreamWriter(file1);
                            }
                            catch
                            {
                                Console.WriteLine("Сотрудник существует");
                                Console.ReadKey();
                                break;
                            }
                            string[] massUser = new string[13];


                            string NameTemp = "";
                            Console.WriteLine("Введите имя");
                            while (NameTemp == "")
                            {
                                NameTemp = Console.ReadLine().Replace(" ", "");
                            }
                            massUser[0] = NameTemp;

                            string SurnameTemp = "";
                            Console.WriteLine("Введите фамилию");
                            while (SurnameTemp == "")
                            {
                                SurnameTemp = Console.ReadLine().Replace(" ", "");
                            }
                            massUser[1] = SurnameTemp;

                            Console.WriteLine("Введите отчество");
                            massUser[2] = Console.ReadLine();

                            string AdressTemp = "";
                            Console.WriteLine("Введите адрес");
                            while (AdressTemp == "")
                            {
                                AdressTemp = Console.ReadLine().Replace(" ", "");
                            }
                            massUser[3] = AdressTemp;

                            int AgeTemp = 0;
                            Console.WriteLine("Введите возраст");
                            while (AgeTemp <= 0 || AgeTemp > 150)
                            {
                                while (!int.TryParse(Console.ReadLine(), out AgeTemp))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[4] = Convert.ToString(AgeTemp);

                            string BirthdayTemp = "";
                            Console.WriteLine("Введите дату рождения");
                            while (BirthdayTemp == "" || BirthdayTemp.Length < 8)
                            {
                                BirthdayTemp = Console.ReadLine().Replace(" ", "");
                            }
                            massUser[5] = BirthdayTemp;

                            int PassSerial = 0;
                            Console.WriteLine("Введите серию паспорта");
                            while (Math.Floor(Math.Log10(PassSerial) + 1) != 4 || PassSerial < 0)
                            {
                                while (!int.TryParse(Console.ReadLine(), out PassSerial))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[6] = Convert.ToString(PassSerial);

                            int PassNum = 0;
                            Console.WriteLine("Введите номер паспорта");
                            while (Math.Floor(Math.Log10(PassNum) + 1) != 6 || PassNum < 0)
                            {
                                while (!int.TryParse(Console.ReadLine(), out PassNum))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[7] = Convert.ToString(PassNum);

                            int EduNum = 0;
                            Console.WriteLine("Выберите образование \r\n1-Начальное\r\n2-Среднее\r\n3-Высшее");
                            while (3 < EduNum || EduNum < 1)
                            {
                                while (!int.TryParse(Console.ReadLine(), out EduNum))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            switch (EduNum)
                            {
                                case 1:
                                    massUser[8] = "Primary";
                                    break;
                                case 2:
                                    massUser[8] = "Secondary";
                                    break;
                                case 3:
                                    massUser[8] = "Higher";
                                    break;
                                default:
                                    Console.WriteLine("Неизвестное значение. Сохранение...");
                                    massUser[8] = "Unknown";
                                    break;
                            }

                            string EduEndTemp = "";
                            Console.WriteLine("Введите год окончания обучения");
                            while (BirthdayTemp == "" || BirthdayTemp.Length < 8)
                            {
                                EduEndTemp = Console.ReadLine().Replace(" ", "");
                            }
                            massUser[9] = EduEndTemp;

                            long TINTemp = 0;
                            Console.WriteLine("Введите ИНН");
                            while (Math.Floor(Math.Log10(TINTemp) + 1) != 12 || TINTemp < 0)
                            {
                                while (!long.TryParse(Console.ReadLine(), out TINTemp))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[10] = Convert.ToString(TINTemp);

                            long SNILSTemp = 0;
                            Console.WriteLine("Введите СНИЛС");
                            while (Math.Floor(Math.Log10(SNILSTemp) + 1) != 11 || SNILSTemp < 0)
                            {
                                while (!long.TryParse(Console.ReadLine(), out SNILSTemp))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[11] = Convert.ToString(SNILSTemp);

                            Console.WriteLine("Введите ставку");
                            double RateNum = 0;
                            while (RateNum <= 0 || RateNum > 2)
                            {
                                while (!double.TryParse(Console.ReadLine(), out RateNum))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[12] = Convert.ToString(RateNum);

                            Console.WriteLine("Введите оклад");
                            long SalaryNum = 0;
                            while (SalaryNum <= 0)
                            {
                                while (!long.TryParse(Console.ReadLine(), out SalaryNum))
                                {
                                    Console.WriteLine("Ошибка! Введите число.");
                                }
                            }
                            massUser[13] = Convert.ToString(SalaryNum);


                            wrt.WriteLine(massUser[0] + "_" + massUser[1] + "_" + massUser[2] + "_" + massUser[3] + "_" + massUser[4] + "_" + massUser[5] + "_" + massUser[6] + "_" + massUser[7] + "_" + massUser[8] + "_" + massUser[9] + "_" + massUser[10] + "_" + massUser[11] + "_" + massUser[12] + "_" + massUser[13]);
                            wrt.Close();
                            Console.ReadLine();
                        }
                        else if (k == 13 && s == 2)
                        {
                            Console.WriteLine("Ведите номер сотрудника");
                            int Count;
                            while (!int.TryParse(Console.ReadLine(), out Count))
                            {
                                Console.WriteLine("Введите число");
                            }

                            try
                            {
                                System.IO.File.Delete("C:\\Magazine\\Users\\" + Count + ".txt");
                                Console.WriteLine("Удалено");
                                Console.ReadKey();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Сотрудник не найден");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }

                }
                else if (k == 13 && s == 2 && (Role == 2 || Role == 0)) //Finances
                {
                    int temp = 0;
                    int tempI = 1;
                    Console.Clear();
                    while (temp == 0)
                    {
                        StreamReader reader;
                        try
                        {
                            FileStream file1 = new FileStream("C:\\Magazine\\Checks\\" + tempI + ".txt", FileMode.Open, FileAccess.ReadWrite);
                            reader = new StreamReader(file1);
                        }
                        catch
                        {
                            temp = 2;
                            break;
                        }
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        tempI++;
                    }
                    Console.ReadLine();
                }
                else if (k == 13 && s == 3 && (Role == 4 || Role == 0)) //Checkpoint
                {
                    while (true)
                    {
                        Console.Clear();
                        s = 0;
                        Console.WriteLine(((s == 0) ? "==>" : " ") + "Новая покупка");
                        k = (int)Console.ReadKey().Key;
                        if (k == 38) s--;
                        if (k == 40) s++;
                        if (s > 0) s = 0;
                        if (s < 0) s = 0;


                        else if (k == 13 && s == 0)
                        {
                            Console.Clear();
                            FileStream file1 = new FileStream("C:\\Magazine\\Checks\\" + BuyCount + ".txt", FileMode.Create, FileAccess.ReadWrite);
                            StreamWriter wrt1 = new StreamWriter(file1);
                            BuyCount++;
                            string[] price = new string[99];
                            string[] name = new string[99];
                            int countTovar = 0;
                            int FinalPrice = 0;

                            while (Console.ReadLine() != " ")
                            {
                                countTovar++;
                                StreamReader reader;
                                try
                                {
                                    FileStream file2 = new FileStream("C:\\Magazine\\warehouse\\9789785041057787.txt", FileMode.Open, FileAccess.ReadWrite);
                                    reader = new StreamReader(file2);
                                }
                                catch
                                {
                                    Console.WriteLine("Товар не найден");
                                    Console.ReadKey();
                                    break;
                                }

                                string[] product = reader.ReadToEnd().Split('_');
                                name[countTovar] = product[0];
                                price[countTovar] = product[2];

                                Console.WriteLine("Номер товара: " + countTovar);
                                Console.WriteLine("Наименование товара: " + product[0]);
                                Console.WriteLine("Цена товара: " + product[2]);
                                FinalPrice += Convert.ToInt32(product[2]);
                                Console.WriteLine("Итог: " + FinalPrice);

                                reader.Close();
                                Console.WriteLine("");

                            }

                            for (int temp = 1; temp <= countTovar; temp++)
                            {
                                wrt1.WriteLine(name[temp] + "_" + price[temp]);
                            }
                            wrt1.WriteLine(countTovar);
                            wrt1.WriteLine(FinalPrice);
                            wrt1.Close();
                            PrintCheck(name, price, countTovar, FinalPrice);
                            Console.ReadKey();
                        }
                    }
                }

            } while (true);
        }

        static int Login()
        {
            Console.WriteLine("Вставте ключ\r\n");

            SerialPort port;
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine(i.ToString() + "; " + ports[i].ToString());
            }

            port = new SerialPort();
            try
            {
                port.PortName = ports[3];  //1
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.None;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.ReadTimeout = 100000;
                port.WriteTimeout = 100000;
                port.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            while (!port.IsOpen)
            {

            }
            int Auth = Convert.ToInt32(port.ReadLine());
            port.Close();
            return Auth;
        }

        static void PrintCheck(string[] name, string[] price, int countTovar, int FinalPrice)
        {
            // задаем текст для печати
            result += "       Кассовый чек    \n";
            result += "\n";
            int i;
            for (i = 1; i <= countTovar; i++)
            {
                result += i + ") " + name[i] + "....." + price[i] + "\n";
            }
            result += "\n";
            result += "Товаров: " + countTovar + "\n";
            result += "Итог: " + FinalPrice + " руб.\n";

            // объект для печати
            PrintDocument printDocument = new PrintDocument();

            // обработчик события печати
            printDocument.PrintPage += PrintPageHandler;

            // диалог настройки печати
            PrintDialog printDialog = new PrintDialog();

            // установка объекта печати для его настройки
            printDialog.Document = printDocument;

            // если в диалоге было нажато ОК
            printDialog.Document.Print(); // печатаем

        }

        static long Scan()
        {
            Console.WriteLine("Подготовка к сканированию...\r\n");

            SerialPort port;
            string[] ports = SerialPort.GetPortNames();
            /*for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine(i.ToString() + "; " + ports[i].ToString());
            }*/

            port = new SerialPort();
            try
            {
                port.PortName = ports[3];  //1
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.None;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.ReadTimeout = 100000;
                port.WriteTimeout = 100000;
                port.Open();
                Console.WriteLine("Готов");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            while (!port.IsOpen)
            {

            }
            long Scan = Convert.ToInt64(port.ReadLine());
            port.Close();
            return Scan;
        }

        static void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // печать строки result
            e.Graphics.DrawString(result, new Font("Arial", 12), Brushes.Black, 0, 0);
        }
    }
}