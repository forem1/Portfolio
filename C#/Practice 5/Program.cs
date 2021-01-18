using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number N: ");
            int N_int = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number C1: ");
            int C1_int = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number C2: ");
            int C2_int = Convert.ToInt32(Console.ReadLine());

            String Output = "";

            for(int i = 1; i<= N_int; i++)
            {
                if(i % 2 == 0)
                {
                    Output = String.Concat(Output, C2_int);
                }
                else
                {
                    Output = String.Concat(Output, C1_int);
                }
            }

            Console.WriteLine(Output);
            Console.ReadKey();
        }
    }
}
