using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1, start_int;
            for (start_int = -5; start_int <= 51; start_int++)
            {
                start_int = start_int + start_int;
                i++;
            }

            Console.Write("Среднее арифметическое: " + start_int/i);
            Console.ReadKey();
        }
    }
}
