using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int A_int, B_int, H_int, R_int, D_int;
            Console.Write("Enter month: ");
            int M_int = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter day: ");
            int D_int = Convert.ToInt32(Console.ReadLine());


            switch (M_int)
            {
                case 1:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Января");
                    }
                    else
                    {
                        Console.Write("1 Февраля");
                    }
                    break;
                case 2:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Февраля");
                    }
                    else
                    {
                        Console.Write("1 Марта");
                    }
                    break;
                case 3:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Марта");
                    }
                    else
                    {
                        Console.Write("1 Апреля");
                    }
                    break;
                case 4:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Апреля");
                    }
                    else
                    {
                        Console.Write("1 Мая");
                    }
                    break;
                case 5:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Мая");
                    }
                    else
                    {
                        Console.Write("1 Июня");
                    }
                    break;
                case 6:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Июня");
                    }
                    else
                    {
                        Console.Write("1 Июля");
                    }
                    break;
                case 7:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Июля");
                    }
                    else
                    {
                        Console.Write("1 Августа");
                    }
                    break;
                case 8:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Августа");
                    }
                    else
                    {
                        Console.Write("1 Сентября");
                    }
                    break;
                case 9:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Сентября");
                    }
                    else
                    {
                        Console.Write("1 Октября");
                    }
                    break;
                case 10:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Октября");
                    }
                    else
                    {
                        Console.Write("1 Ноября");
                    }
                    break;
                case 11:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Ноября");
                    }
                    else
                    {
                        Console.Write("1 Декабря");
                    }
                    break;
                case 12:
                    if (D_int < 31)
                    {
                        D_int++;
                        Console.Write(D_int + " Декабря");
                    }
                    else
                    {
                        Console.Write("1 Января");
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}
