using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Таблица_истинности
{
    class Program
    {
        static public void SetCursorPosition()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Инверсия - !");
            Console.WriteLine("Конъюнкция - &");
            Console.WriteLine("Дизъюнкция - |");
            Console.WriteLine("Импликация - >");
            Console.WriteLine("Эквивалентность - =");
            Console.WriteLine();
            Truth.TruthTable Table1 = new Truth.TruthTable();
            
            Start:
            string N1 = Console.ReadLine();
            int Counter = 0;
            if (N1.Length == 0)
            {
                SetCursorPosition();
                goto Start;
            }
            while (Counter != N1.Length)
            {
                if ("!".Contains(N1[Counter]))
                {
                    Counter++;
                    if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(N1[Counter]))
                    {
                        Counter++;
                        if (Counter == N1.Length) break;
                        if ("|&>=".Contains(N1[Counter]))
                        {
                            Counter++;
                            if (Counter == N1.Length)
                            {
                                SetCursorPosition();
                                goto Start;
                            }
                        }
                        else
                        {
                            SetCursorPosition();
                            goto Start;
                        }
                    }
                    else
                    {
                        SetCursorPosition();
                        goto Start;
                    }
                }
                else
                {
                    if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(N1[Counter]))
                    {
                        Counter++;
                        if (Counter == N1.Length) break;
                        if ("|&>=".Contains(N1[Counter]))
                        {
                            Counter++;
                            if (Counter == N1.Length)
                            {
                                SetCursorPosition();
                                goto Start;
                            }
                        }
                        else
                        {
                            SetCursorPosition();
                            goto Start;
                        }
                    }
                    else
                    {
                        SetCursorPosition();
                        goto Start;
                    }
                }
            }
            Table1.FindElementAmount(N1);
            Table1.FillingElements();
            Table1.Main();
            Table1.Output();
            Console.ReadKey();
        }
    }
}
