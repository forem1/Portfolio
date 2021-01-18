using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            int Shape = 0;
            int Size = 0;
            int Filling = 0;
            int SecondFilling = 10;
            int Topping = 0;
            Input_Set(ref Shape, ref Size, ref Filling, ref SecondFilling, ref Topping);

            //Console.WriteLine(Shape);
            Output_Set(ref Shape, ref Size, ref Filling, ref SecondFilling, ref Topping);

            Equal(ref Shape, ref Size, ref Filling, ref SecondFilling, ref Topping);

            Console.ReadKey();
        }

        static void Input_Set(ref int Shape, ref int Size, ref int Filling, ref int SecondFilling, ref int Topping)
        {
            Console.WriteLine("Здравствуйте. Эта программа расчитает стоимость заказа торта в нашей кондитерской. \r\n \r\nВведите форму торта: \r\n 1 - Круглая \r\n 2 - Квадратная");

            while (!int.TryParse(Console.ReadLine(), out Shape))
            {
                Console.WriteLine("Ошибка! Введите число.");
            }

            Console.WriteLine("\r\nВведите размер: \r\n 1 - Маленький \r\n 2 - Средний \r\n 3 - Большой");

            while (!int.TryParse(Console.ReadLine(), out Size))
            {
                Console.WriteLine("Ошибка! Введите число.");
            }

            Console.WriteLine("\r\nВведите тип начинки: \r\n 0 - Обычная(тесто) \r\n 1 - Клубника\r\n 2 - Шоколад\r\n 3 - Банан\r\n 4 - Сливки");

            while (!int.TryParse(Console.ReadLine(), out Filling))
            {
                Console.WriteLine("Ошибка! Введите число.");
            }

            Console.WriteLine("\r\nВам нужна дополнительная начинка: \r\n 0 - Нет \r\n 1 - Да");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Console.WriteLine("\r\nВведите тип второй начинки: \r\n 0 - Обычная(тесто) \r\n 1 - Клубника\r\n 2 - Шоколад\r\n 3 - Банан\r\n 4 - Сливки");

                while (!int.TryParse(Console.ReadLine(), out SecondFilling))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }

            Console.WriteLine("\r\nВведите топпинг: \r\n 0 - Без топпинга \r\n 1 - Белый шоколад\r\n 2 - Темный шоколад\r\n 3 - Молочный шоколад\r\n 4 - Фруктовая глазурь");

            while (!int.TryParse(Console.ReadLine(), out Topping))
            {
                Console.WriteLine("Ошибка! Введите число.");
            }
        }

        static void Output_Set(ref int Shape, ref int Size, ref int Filling, ref int SecondFilling, ref int Topping)
        {
            Console.Write("Вы выбрали ");
            switch (Shape)
            {
                case 1:
                    Console.Write("круглый");
                    break;
                case 2:
                    Console.Write("квадратный");
                    break;

                default:
                    Console.Write("круглый");
                    break;
            }
            Console.Write(" торт ");
            switch (Size)
            {
                case 1:
                    Console.Write("маленького");
                    break;
                case 2:
                    Console.Write("среднего");
                    break;
                case 3:
                    Console.Write("большого");
                    break;
                default:
                    Console.Write("большого");
                    break;
            }
            Console.Write(" размера, с начинкой из ");
            switch (Filling)
            {
                case 0:
                    Console.Write("теста");
                    break;
                case 1:
                    Console.Write("клубники");
                    break;
                case 2:
                    Console.Write("шоколада");
                    break;
                case 3:
                    Console.Write("банана");
                    break;
                case 4:
                    Console.Write("сливок");
                    break;
                default:
                    Console.Write("клубники");
                    break;
            }

            if (SecondFilling != 10)
            {
                Console.Write(" и начинкой из ");
                switch (SecondFilling)
                {
                    case 0:
                        Console.Write("теста");
                        break;
                    case 1:
                        Console.Write("клубники");
                        break;
                    case 2:
                        Console.Write("шоколада");
                        break;
                    case 3:
                        Console.Write("банана");
                        break;
                    case 4:
                        Console.Write("сливок");
                        break;
                    default:
                        Console.Write("сливок");
                        break;
                }
            }

            Console.Write(" и топпингом из ");
            switch (Topping)
            {
                case 0:
                    Console.Write("Воздуха");
                    break;
                case 1:
                    Console.Write("белого шоколада");
                    break;
                case 2:
                    Console.Write("темного шоколада");
                    break;
                case 3:
                    Console.Write("молочного шоколада");
                    break;
                case 4:
                    Console.Write("фруктовой глазури");
                    break;
                default:
                    Console.Write("фруктовой глазури");
                    break;
            }
        }

        static void Equal(ref int Shape, ref int Size, ref int Filling, ref int SecondFilling, ref int Topping)
        {
            int Equal = 0;
            int EqualFilling = 0;
            int EqualSecondFilling = 0;
            int EqualTopping = 0;
            int EqualSize = 0;
            Console.Write("\r\n\r\nРасчетная стоимость ");

            switch (Filling)
            {
                case 0:
                    EqualFilling = 0;
                    break;
                case 1:
                    EqualFilling = 300;
                    break;
                case 2:
                    EqualFilling = 100;
                    break;
                case 3:
                    EqualFilling = 50;
                    break;
                case 4:
                    EqualFilling = 200;
                    break;
                default:
                    EqualFilling = 300;
                    break;
            }

            if (SecondFilling != 10)
            {
                switch (SecondFilling)
                {
                    case 0:
                        EqualSecondFilling = 0;
                        break;
                    case 1:
                        EqualSecondFilling = 300;
                        break;
                    case 2:
                        EqualSecondFilling = 100;
                        break;
                    case 3:
                        EqualSecondFilling = 50;
                        break;
                    case 4:
                        EqualSecondFilling = 200;
                        break;
                    default:
                        EqualSecondFilling = 200;
                        break;
                }
            }

            switch (Topping)
            {
                case 0:
                    EqualTopping = 0;
                    break;
                case 1:
                    EqualTopping = 50;
                    break;
                case 2:
                    EqualTopping = 100;
                    break;
                case 3:
                    EqualTopping = 150;
                    break;
                case 4:
                    EqualTopping = 200;
                    break;
                default:
                    EqualTopping = 200;
                    break;
            }

            switch (Size)
            {
                case 1:
                    EqualSize = 1;
                    break;
                case 2:
                    EqualSize = 2;
                    break;
                case 3:
                    EqualSize = 3;
                    break;
                default:
                    EqualSize = 3;
                    break;
            }

            Equal = (EqualFilling * EqualSize) + (EqualSecondFilling * EqualSize) + (EqualTopping * EqualSize);

            Console.Write(Equal + " Рублей");
        }

        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("\nВы не выйдете! Not today.");
            args.Cancel = true;
        }

        
    }
}
