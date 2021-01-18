using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string S: ");
            String S = Console.ReadLine();
            String NewString = "";

            for (int i = 1; i < S.Length; i = i + 2)
                NewString += S[i];

            int ind = S.Length % 2 == 0 ? S.Length - 2 : S.Length - 1;

            for (int i = ind; i >= 0; i = i - 2)
                NewString += S[i];

            Console.WriteLine(NewString);
            Console.ReadKey();
        }
    }
}
