using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int A_int, B_int, H_int, R_int, D_int;
            Console.Write("Enter number K: ");
            int K_int = Convert.ToInt32(Console.ReadLine());

            if (K_int == 1) {

                Console.Write("Enter number A: ");
                A_int = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number B: ");
                B_int = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Equal is: " + A_int * B_int);

            }

            if (K_int == 2)
            {
                Console.Write("Enter number A: ");
                A_int = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number H: ");
                H_int = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Equal is: " + (A_int * H_int) / 2);
            }

            if (K_int == 3)
            {
                Console.Write("Enter number A: ");
                A_int = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number B: ");
                B_int = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number H: ");
                H_int = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Equal is: " + ((A_int + B_int) * H_int) / 2);
            }

            if (K_int == 4)
            {
                Console.Write("Enter radius: ");
                R_int = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Equal is: " + Math.PI * (R_int * R_int));


                Console.Write("Enter radius: ");
                R_int = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter diameter: ");
                D_int = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Equal is: " + (Math.PI * (R_int * R_int) * D_int) / 360);
            }
            Console.ReadKey();
        }
    }
}
