using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_of_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            // aaaaabbbbbcdddeeeedssaa

            var input = Console.ReadLine();

            var resultList = new List<char>();
            var prevSymbol = '\t'; //some random symbol
            var currentSymbol = input[0];

            for (int i = 1; i < input.Length - 1; i++)
            {
                currentSymbol = input[i];
                if ( currentSymbol != prevSymbol)
                {
                    resultList.Add(currentSymbol);
                    prevSymbol = currentSymbol;
                }
            }

            Console.WriteLine(string.Join("", resultList));
        }
    }
}
