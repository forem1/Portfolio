using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    class Program
    {
        static void Main(string[] args)
        {
            One();
            Two();
            Three();
            Four();

        }

        static void One()
        {
            int Output = 0;
            Console.Write("Enter number N: ");
            int N_int = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[N_int];

            for (int i = 0; i < N_int; i++)
            {
                Console.Write("Enter number: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i <= N_int; i++)
            {
                if (i % 2 == 0)
                {
                    if (nums[i] > Output) Output = nums[i];
                }
            }

            Console.WriteLine(Output);
        }

        static void Two()
        {
            Console.Write("Enter array size : ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            int[] mass = new int[N];
            int G = 0;
            int C = -1;
            for (int i = 0; i < mass.Length; i++) { mass[i] = Convert.ToInt32(Console.ReadLine()); }
            for (int i = 0; i < mass.Length; i++) {
                for (int j = 1; j < mass.Length; j++) {
                    if (mass[i] == mass[j]) {
                        if (G == 1) {
                            mass[j] = default(int);
                            C++;
                        }
                        G++;
                    }
                }
                G = 0;
            }
            Console.WriteLine(" ");
            int H = 0;
            int[] mass2 = new int[mass.Length - C];
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == 0) H++;
                else {
                    mass2[i - H] = mass[i];
                    Console.WriteLine(mass2[i - H]);
                }
            }

            Console.ReadKey();

        }

        static void Three()
        {
            int Output = 0;
            int plus = 0;
            Console.Write("Enter number N: ");
            int N_int = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[N_int];

            for (int i = 0; i <= N_int; i++)
            {
                Console.Write("Enter number: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            for(int i = 0; i <= N_int; i++)
            {
                if(nums[i] > 0)
                {
                    plus = 1;
                }

                if(plus == 1)
                {
                    Output = +nums[i];
                }

                Console.WriteLine(Output);
            }
        }

        static void Four()
        {
            Console.WriteLine("Enter N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] A = new int[N];
            int[] B = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine(" ");
            for (int i = 0; i < A.Length; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    B[i] += A[k];
                }
                Console.WriteLine(B[i]);
            }
        }
    }
}