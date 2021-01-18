using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Formula = 1;
            Console.Write("Enter n: ");
            int N_int = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter k: ");
            int K_int = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i<=K_int; i++)
            {
                Formula = Formula + ((-1) ^ i)*((N_int/(K_int+1)*(K_int+2)) ^ i);
            }

            Console.Write(Formula);
            Console.ReadKey();
        }
    }
}
