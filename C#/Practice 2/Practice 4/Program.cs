using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number D: ");
            int D_int = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number X: ");
            int X_int = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter type of function with arrows: ");
            ConsoleKeyInfo keypress;
            keypress = Console.ReadKey(); 

            switch (keypress.Key)
            {
                case ConsoleKey.LeftArrow:
                    Left(X_int, D_int);
                    break;

                case ConsoleKey.RightArrow:
                    Right(X_int, D_int);
                    break;

                case ConsoleKey.UpArrow:
                    Center(X_int, D_int);
                    break;

            }

            Console.ReadKey();
        }

        /*static int Left(int x, int d)
        {
            
            double formula = (2*Math.Sqrt(3));

            return formula;
        }
        static int Right(int x, int d)
        {

            double formula = (2 * Math.Sqrt(3));

            return formula;
        }
        static int Center(int x, int d)
        {

            double formula = (2 * Math.Sqrt(3));

            return formula;
        }*/

    }
}