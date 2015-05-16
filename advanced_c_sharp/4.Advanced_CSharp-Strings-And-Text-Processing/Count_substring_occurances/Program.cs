using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_substring_occurances
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var word = Console.ReadLine();

            var index = 0;
            var count = 0;
            while (true)
            {
                index = input.IndexOf(word, index);
                if (index == -1)
                {
                    break;
                }
                index++;
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
