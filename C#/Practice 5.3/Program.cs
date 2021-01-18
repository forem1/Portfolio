using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string S: ");
            String S = Console.ReadLine();
            String NewString = "";
            string[] words = S.Split(new char[] { ' ' });

            foreach (string W in words)
            {
                
                String wchar = Convert.ToString(W[0]);
                NewString += W.Replace(wchar, ".");
                NewString += " ";
            }

            Console.WriteLine(NewString);
            Console.ReadKey();
        }
    }
}
