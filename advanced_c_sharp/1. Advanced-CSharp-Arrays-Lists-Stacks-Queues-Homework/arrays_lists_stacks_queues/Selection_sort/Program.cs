using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray().Select(int.Parse).ToList();

            for (int i = 0; i < input.Count; i++)
            {
                var minSoFar = input[i];
                var minIndexSoFar = i;
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[j] < minSoFar)
                    {
                        minSoFar = input[j];
                        minIndexSoFar = j;
                    }
                }
                SwapMinimumWithCurrentElement(i, minIndexSoFar, input);
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static void SwapMinimumWithCurrentElement(int minSoFar, int current, IList<int> input)
        {
            var temp = input[minSoFar];
            input[minSoFar] = input[current];
            input[current] = temp;
        }
    }
}
