using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuck_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersToRead = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Trim().Split().ToArray().Select(int.Parse).ToList();

            for (int a = 0; a < numbersToRead; a++)
            {
                for (int b = 0; b < numbersToRead; b++)
                {
                    for (int c = 0; c < numbersToRead; c++)
                    {
                        for (int d = 0; d < numbersToRead; d++)
                        {
                            if (input[a] != input[b] && input[a] != input[c] && input[a] != input[d] &&
                                input[b] != input[c] && input[b] != input[d] &&
                                input[c] != input[d])
                            {
                                TryToMakeStuckNumber("" + input[a], "" + input[b], "" + input[c], "" + input[d]);
                            }
                        }
                    }
                }
            }
        }

        private static void TryToMakeStuckNumber(string p1, string p2, string p3, string p4)
        {
            var firstNum = new StringBuilder(p1);
            firstNum.Append(p2);

            var secondNum = new StringBuilder(p3);
            secondNum.Append(p4);

            if (firstNum.ToString() == secondNum.ToString())
            {
                Console.WriteLine("{0}|{1}=={2}|{3}", p1, p2, p3, p4);
            }
        }
    }
}
