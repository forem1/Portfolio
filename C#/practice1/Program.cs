using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a_int, d_int, c_int, FirstEqual, SecondEqual;
            Console.WriteLine("Enter a: ");
            a_int = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter d: ");
            d_int = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter c: ");
            c_int = Convert.ToDouble(Console.ReadLine());

            FirstEqual = 2*c_int-d_int/23;

            SecondEqual = Math.Log10(1-a_int/4);

            Console.Write("Equal is: " + FirstEqual/SecondEqual);
            Console.ReadKey();
        }
    }
}