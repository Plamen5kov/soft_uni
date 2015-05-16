using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicode_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            foreach (var symbol in input)
            {
                var val = (int)symbol;
                string hexValue = val.ToString("X");
                Console.Write("\\u{0}", hexValue.PadLeft(4, '0'));
            }
            Console.WriteLine();
        }
    }
}
