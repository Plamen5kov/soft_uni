using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset_sums // && sorted subset of sums
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().ToArray().Select(int.Parse).ToList();
            var count = input.Count;

            var sortedSubset = new List<List<int>>();
            var thereAreMatchingSubsets = false;
            var length = Math.Pow(2, count);

            for (int i = 0; i < length; i++)
            {
                var binRep = Convert.ToString(i, 2).PadLeft(count, '0');
                var tempSum = 0;
                var tempList = new List<int>();
                for (int j = 0; j < binRep.Length; j++)
                {
                    var bit = binRep[j];
                    if (bit == '1')
                    {
                        tempSum += input[j];
                        tempList.Add(input[j]);
                    }
                }

                if (tempSum == sum && tempSum != 0)
                {
                    thereAreMatchingSubsets = true;
                    sortedSubset.Add(new List<int>(tempList));
                }
            }

            var result = sortedSubset.OrderBy(x => x.Count).ThenBy(x => x[0]); ;

            if (!thereAreMatchingSubsets)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.Write(string.Join(" + ", item));
                    Console.WriteLine(" = {0}", sum);
                }
            }
        }
    }
}
