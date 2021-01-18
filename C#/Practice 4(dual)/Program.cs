using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4_dual_
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Console.ReadKey();
            Second(1234567890);
            Console.ReadKey();
            Console.WriteLine(Third(10, 15));
            Console.ReadKey();
            int x = 12;
            int y = 1;
            Fourth(ref x, y);
            Console.WriteLine(x);
            Console.ReadKey();
        }

        static void First()
        {
            Console.WriteLine("It's first output");
        }

        static void Second(int x)
        {
            Console.WriteLine(x);
        }

        static int Third(int x, int d)
        {
            int formula = ((x + d) * 5) / 2;
            return formula;
        }

        static void Fourth(ref int x, int y)
        {
            x = ((x + y) * 5) / 2;
        }
    }
}
