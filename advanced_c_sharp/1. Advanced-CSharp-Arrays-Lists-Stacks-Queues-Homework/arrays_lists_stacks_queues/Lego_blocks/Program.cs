using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego_blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            //MAKE RECT
            // 2
            // 1 1 1 1 1 1
            // 2 1 1 3
            // 1 1
            // 2 2 2 3


            //PRINT NUM
            // 2
            // 1 1 1 1 1
            // 1 1 1
            // 1
            // 1 1 1 1 1

            var rows = int.Parse(Console.ReadLine());
            var list = new List<List<int>>();
            for (int i = 0; i < rows * 2; i++)
            {
                var line = Console.ReadLine().Trim().Split().ToArray().Select(int.Parse).ToList();
                list.Add(new List<int>(line));
            }

            var cols = list[0].Count + list[rows].Count;

            var itCanBeMade = CheckIfRectangularMatrixCanBeMade(list, rows, cols);
            if (itCanBeMade)
            {
                var result = MakeRectangularMatrix(list, rows);
                PrintRectMatrix(result);
            }
            else
            {
                PrintCountOfElements(list);
            }
        }

        private static void PrintRectMatrix(List<List<int>> result)
        {
            var sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.Append("[");
                sb.Append(string.Join(", ", item));
                sb.Append("]");
                Console.WriteLine(sb);
                sb.Clear();
            }
        }

        private static void PrintCountOfElements(List<List<int>> list)
        {
            var tempSum = 0;
            foreach (var item in list)
            {
                tempSum += item.Count;
            }

            Console.WriteLine("The total number of cells is: {0}", tempSum);
        }

        private static List<List<int>> MakeRectangularMatrix(List<List<int>> list, int rows)
        {
            var resultArr = new List<List<int>>();
            for (int i = 0; i < rows; i++)
            {
                var line = new List<int>();
                line.AddRange(list[i]);
                list[rows + i].Reverse();
                line.AddRange(list[rows + i]);

                resultArr.Add(line);
            }

            return resultArr;
        }

        private static bool CheckIfRectangularMatrixCanBeMade(List<List<int>> list, int rows, int cols)
        {
            for (int i = 1; i < rows; i++)
            {
                if ((list[i].Count + list[rows + i].Count) != cols)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
