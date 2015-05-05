using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//same as subset of sums ... try all combinations
namespace Pythagorean_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersLength = int.Parse(Console.ReadLine());
            var numbersList = new List<int>();

            for (int i = 0; i < numbersLength; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                numbersList.Add(currentNumber);
            }

            var length = Math.Pow(2, numbersLength);

            var allCombinations = new List<List<int>>();
            for (int i = 0; i < length; i++)
            {
                var binRep = Convert.ToString(i, 2).PadLeft(numbersLength, '0');
                var tempList = new List<int>();
                for (int j = 0; j < binRep.Length; j++)
                {
                    var bit = binRep[j];
                    if (bit == '1')
                    {
                        tempList.Add(numbersList[j]);
                    }
                }
                if (tempList.Count == 3)
                {
                    allCombinations.Add(tempList);
                }
            }

            var foundSolution = false;
            foreach (var item in allCombinations)
            {
                item.Sort();
                var a = item[0];
                var b = item[1];
                var c = item[2];

                if ((a * a + b * b) == c * c)
                {
                    foundSolution = true;
                    Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);
                }
            }

            if (!foundSolution)
            {
                Console.WriteLine("No");
            }
        }
    }
}
