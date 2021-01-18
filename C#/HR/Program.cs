using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace HR
{

    class Program
    {
        public struct Worker
        {
            public string Name;
            public string Surname;
            public string Patronymic;
            public string Adress;
            public int Age;
            public string Birthday;
            public int SerialPassport;
            public int NumberPassport;
            public string Education;
            public string EducationEndYear;
            public long TIN;
            public long SNILS;
            public double Rate;
            public long Salary;
            public int Children;
            public struct WorkerChildren
            {
                public string Name;
                public int Age;
                public int SerialPassport;
                public int NumberPassport;
            }
        }


        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            string Pass = "ghe52u4f6";
            //string PassKey = "88289";
            int action;
            int LastWorkerNumber = 0;

            //Security(Pass);

            Console.WriteLine("\r\nДобро пожаловать в программу учета сотрудников!");
            while (true)
            {
                Console.WriteLine("\r\nВыберите действие: \r\n 0 - список сотрудников \r\n 1 - Добавить сотрудника \r\n 2 - Удалить сотрудника \r\n 3 - Инфо о сотруднике");
                while (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }

                switch (action)
                {
                    case 0:
                        AllWorker();
                        break;
                    case 1:
                        AddWorker(ref LastWorkerNumber);
                        break;
                    case 2:
                        DelWorker();
                        break;
                    case 3:
                        InfoWorker();
                        break;
                }
            }
        }

        static void Security(string Pass)
        {
            Console.WriteLine("Вставте ключ\r\n");
            /*for(int i = 0; i<=3; i++)
            {
                if (Console.ReadLine() != Pass)
                {
                    Console.WriteLine("Неправильный пароль. Осталось " + (3 - i) + " попытки");
                    Try++;
                }
                else break;
            }
            if (Try > 0)
            {
                Console.WriteLine("Вы исчерпали все попытки. Выход из программы.");
            }*/

            //----------------------------------------------------------------------------

            SerialPort port;
            string[] ports = SerialPort.GetPortNames();
            /*for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine(i.ToString() + "; " + ports[i].ToString());
            }*/

            port = new SerialPort();
            try
            {
                port.PortName = ports[1];  //1
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
            port.Write("1");
            port.Close();
            Console.Write("Введите код с ключа: ");

            string GetPass = Console.ReadLine();

            if (GetPass != Pass)
            {
                Console.WriteLine("Неправильный ключ. Выход из программы.");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }
        static void AllWorker()
        {
            int CountWorker = 0;
            double SumSalary = 0;

            Console.WriteLine("Список сотрудников");
            //List<Worker> AllWorkerList = new List<Worker>();

            for (int i = 0; i < AllWorkerList.Count; i++)
            {
                CountWorker++;
                Console.WriteLine("Номер сотрудника: " + i + " - " + AllWorkerList[i].Name + " " + AllWorkerList[i].Surname + " " + AllWorkerList[i].Patronymic + "; Адрес: " + AllWorkerList[i].Adress + "; Возраст: " + AllWorkerList[i].Age + "; Дата рождения: " + AllWorkerList[i].Birthday + "; Серия паспорта: " + AllWorkerList[i].SerialPassport + "; Номер паспорта: " + AllWorkerList[i].NumberPassport + "; Образование: " + AllWorkerList[i].Education + "; Год окончания обучения: " + AllWorkerList[i].EducationEndYear + "; ИНН: " + AllWorkerList[i].TIN + "; СНИЛС: " + AllWorkerList[i].SNILS + "; Ставка: " + AllWorkerList[i].Rate + "; Оклад: " + AllWorkerList[i].Salary);
                if (AllWorkerList[i].Children >= 1) {
                    Console.WriteLine("Номер ребенка сотрудника: " + 0 + " - " + WorkerChildrenList[0].Name + "; Возраст: " + WorkerChildrenList[0].Age + "; Серия паспорта: " + WorkerChildrenList[0].SerialPassport + "; Номер паспорта: " + WorkerChildrenList[0].NumberPassport);
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                SumSalary += AllWorkerList[i].Rate * AllWorkerList[i].Salary;
            }

            Console.WriteLine("Всего сотрудников: " + CountWorker);
            if (CountWorker > 0) Console.WriteLine("Средняя зарплата: " + (SumSalary / CountWorker));
        }

        static List<Worker> AllWorkerList = new List<Worker>();
        static List<Worker.WorkerChildren> WorkerChildrenList = new List<Worker.WorkerChildren>();

        static void AddWorker(ref int LastWorkerNumber)
        {
            Console.WriteLine("Добавление нового сотрудника");

            Worker WorkerNumber = new Worker();

            string NameTemp = "";
            Console.WriteLine("Введите имя");
            while(NameTemp == "")
            {
                NameTemp = Console.ReadLine().Replace(" ", "");
            }
            WorkerNumber.Name = NameTemp;

            string SurnameTemp = "";
            Console.WriteLine("Введите фамилию");
            while (SurnameTemp == "")
            {
                SurnameTemp = Console.ReadLine().Replace(" ", "");
            }
            WorkerNumber.Surname = SurnameTemp;

            Console.WriteLine("Введите отчество");
            WorkerNumber.Patronymic = Console.ReadLine();

            string AdressTemp = "";
            Console.WriteLine("Введите адрес");
            while (AdressTemp == "")
            {
                AdressTemp = Console.ReadLine().Replace(" ", "");
            }
            WorkerNumber.Adress = AdressTemp;

            int AgeTemp = 0;
            Console.WriteLine("Введите возраст");
            while (AgeTemp <= 0 || AgeTemp > 150)
            {
                while (!int.TryParse(Console.ReadLine(), out AgeTemp))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.Age = AgeTemp;

            string BirthdayTemp = "";
            Console.WriteLine("Введите дату рождения");
            while (BirthdayTemp == "" || BirthdayTemp.Length < 8)
            {
                BirthdayTemp = Console.ReadLine().Replace(" ", "");
            }
            WorkerNumber.Birthday = BirthdayTemp;

            int PassSerial = 0;
            Console.WriteLine("Введите серию паспорта");
            while (Math.Floor(Math.Log10(PassSerial) + 1) != 4 || PassSerial < 0)
            {
                while (!int.TryParse(Console.ReadLine(), out PassSerial))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.SerialPassport = PassSerial;

            int PassNum = 0;
            Console.WriteLine("Введите номер паспорта");
            while(Math.Floor(Math.Log10(PassNum) + 1) != 6 || PassNum < 0)
            {
                while (!int.TryParse(Console.ReadLine(), out PassNum))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.NumberPassport = PassNum;

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
                        WorkerNumber.Education = "Primary";
                        break;
                    case 2:
                        WorkerNumber.Education = "Secondary";
                        break;
                    case 3:
                        WorkerNumber.Education = "Higher";
                        break;
                    default:
                    Console.WriteLine("Неизвестное значение. Сохранение...");
                        WorkerNumber.Education = "Unknown";
                        break;
                }

            string EduEndTemp = "";
            Console.WriteLine("Введите год окончания обучения");
            while (BirthdayTemp == "" || BirthdayTemp.Length < 8)
            {
                EduEndTemp = Console.ReadLine().Replace(" ", "");
            }
            WorkerNumber.EducationEndYear = EduEndTemp;

            long TINTemp = 0;
            Console.WriteLine("Введите ИНН");
            while (Math.Floor(Math.Log10(TINTemp) + 1) != 12 || TINTemp < 0)
            {
                while (!long.TryParse(Console.ReadLine(), out TINTemp))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.TIN = TINTemp;

            long SNILSTemp = 0;
            Console.WriteLine("Введите СНИЛС");
            while (Math.Floor(Math.Log10(SNILSTemp) + 1) != 11 || SNILSTemp < 0)
            {
                while (!long.TryParse(Console.ReadLine(), out SNILSTemp))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.SNILS = SNILSTemp;

            Console.WriteLine("Введите ставку");
            double RateNum = 0;
            while(RateNum <= 0 || RateNum > 2)
            {
                while (!double.TryParse(Console.ReadLine(), out RateNum))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.Rate = RateNum;

            Console.WriteLine("Введите оклад");
            long SalaryNum = 0;
            while(SalaryNum <= 0)
            {
                while (!long.TryParse(Console.ReadLine(), out SalaryNum))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
            WorkerNumber.Salary = SalaryNum;

            int CountChildren = -1;
            Console.WriteLine("Введите количество детей");
            while (CountChildren < 0)
            {
                while (!int.TryParse(Console.ReadLine(), out CountChildren))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }

            WorkerNumber.Children = CountChildren;

            if (WorkerNumber.Children >= 1)
            {
                for (int i = 0; i < CountChildren; i++)
                {
                    Worker.WorkerChildren WorkerChildrenNumber = new Worker.WorkerChildren();

                    Console.WriteLine("Введите имя ребенка");
                    WorkerChildrenNumber.Name = Console.ReadLine();

                    Console.WriteLine("Введите возраст ребенка");
                    int ChildAge = 0;
                    while (!int.TryParse(Console.ReadLine(), out ChildAge))
                    {
                        Console.WriteLine("Ошибка! Введите число.");
                    }
                    WorkerChildrenNumber.Age = ChildAge;

                    if (ChildAge >= 14)
                    {
                        Console.WriteLine("Введите серию паспорта ребенка");
                        while (!int.TryParse(Console.ReadLine(), out WorkerChildrenNumber.SerialPassport))
                        {
                            Console.WriteLine("Ошибка! Введите число.");
                        }

                        Console.WriteLine("Введите номер паспорта ребенка");
                        while (!int.TryParse(Console.ReadLine(), out WorkerChildrenNumber.NumberPassport))
                        {
                            Console.WriteLine("Ошибка! Введите число.");
                        }
                    }

                    WorkerChildrenList.Add(WorkerChildrenNumber);
                }
            }

            AllWorkerList.Add(WorkerNumber);

            Console.WriteLine("Новый сотрудник успешно добавлен!");
        }

        static void DelWorker()
        {
            Console.WriteLine("Удаление сотрудника \r\n Введите номер сотрудника");
            string delWorker = Console.ReadLine();
            int TempDelWorker = 0;

            if (!int.TryParse(delWorker, out TempDelWorker))
            {
                Console.WriteLine("Ошибка! Введите число.");
            }

            if (TempDelWorker < 0 || TempDelWorker > AllWorkerList.Count)
            {
                Console.WriteLine("Сотрудника не существует!");
            }
            else
            {
                Console.WriteLine("Удаление сотрудника под номером " + TempDelWorker);
                AllWorkerList.RemoveAt(TempDelWorker);

                Console.WriteLine("Сотрудник успешно удален");
            }
        }

        static void InfoWorker()
        {
            Console.WriteLine("Информация о сотруднике \r\n Введите номер сотрудника");

            string infoWorker = Console.ReadLine();
            int i = 0;
            if (!int.TryParse(infoWorker, out i))
            {
                Console.WriteLine("Ошибка! Введите число.");
            }
            //i = i - 1;
            if (i < 0 || i >= AllWorkerList.Count)
            {
                Console.WriteLine("Сотрудника не существует!");
            }
            else
            {
                Console.WriteLine("Номер сотрудника: " + i + " - " + AllWorkerList[i].Name + " " + AllWorkerList[i].Surname + " " + AllWorkerList[i].Patronymic + "; Адрес: " + AllWorkerList[i].Adress + "; Возраст: " + AllWorkerList[i].Age + "; Дата рождения: " + AllWorkerList[i].Birthday + "; Серия паспорта: " + AllWorkerList[i].SerialPassport + "; Номер паспорта: " + AllWorkerList[i].NumberPassport + "; Образование: " + AllWorkerList[i].Education + "; Год окончания обучения: " + AllWorkerList[i].EducationEndYear + "; ИНН: " + AllWorkerList[i].TIN + "; СНИЛС: " + AllWorkerList[i].SNILS + "; Ставка: " + AllWorkerList[i].Rate + "; Оклад: " + AllWorkerList[i].Salary);
                //Console.WriteLine("Номер ребенка сотрудника: " + 0 + " - " + WorkerChildrenList[0].Name + "; Возраст: " + WorkerChildrenList[0].Age + "; Серия паспорта: " + WorkerChildrenList[0].SerialPassport + "; Номер паспорта: " + WorkerChildrenList[0].NumberPassport);
            }
        }

        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("\nВы не выйдете! Not today.");
            args.Cancel = true;
        }
    }
}
