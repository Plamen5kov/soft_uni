using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_increasing_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //test 5 -1 10 20 3 4
            var input = Console.ReadLine().Split().ToArray().Select(int.Parse).ToList();

            var sequences = new Dictionary<int, List<int>>();

            var tempList = new List<int>();
            var result = new Dictionary<int, List<int>>();
            var lastBiggest = input[0];
            tempList.Add(lastBiggest);
            for (int i = 1; i < input.Count; i++)
            {
                var currentElement = input[i];
                if (currentElement < lastBiggest)
                {
                    result.Add(tempList.Count, new List<int>(tempList));
                    tempList.Clear();
                    lastBiggest = int.MinValue;
                    tempList.Add(currentElement);
                }
                else
                {
                    lastBiggest = currentElement;
                    tempList.Add(currentElement);
                }   
            }
            result.Add(tempList.Count, new List<int>(tempList));

            foreach (var item in result)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.Write("{0} ", item.Value[i]);
                }
                Console.WriteLine();
            }

            PrintLongest(result);
        }

        private static void PrintLongest(Dictionary<int, List<int>> result)
        {
            var biggestList = result.OrderByDescending(x => x.Key).First();
            Console.Write("Longest: ");
            foreach (var val in biggestList.Value)
            {
                Console.Write("{0} ", val);
            }
            Console.WriteLine();
        }
    }
}
