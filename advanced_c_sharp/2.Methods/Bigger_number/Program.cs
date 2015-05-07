using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigger_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input two numbers on two separate lines...");
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());

            Console.WriteLine("The bigger number is: {0}", GetMax(first, second));
        }

        private static int GetMax(int first, int second) {
            return first > second ? first : second;
        }
    }
}
