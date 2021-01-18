using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string S: ");
            String S = Console.ReadLine();

            Console.Write("Enter string S0: ");
            String S0 = Console.ReadLine();

            int indexOfChar = S.IndexOf(S0);

        
               S = S.Remove(indexOfChar, S0.Length); //S.Length - S0.Length
           

            Console.WriteLine(S);
            Console.ReadKey();
        }
    }
}
