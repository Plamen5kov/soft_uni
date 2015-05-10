using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixshuffling
{
    class Program
    {
        static string[,] matrix;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = Console.ReadLine();
                }
            }

            StartParsingCommands();

            //PrintMatrix(matrix);
        }

        private static void StartParsingCommands()
        {
            while (true)
            {
                var line = Console.ReadLine().Trim();
                if(line == "END") 
                {
                    break;
                }
                ParseCommandLine(line);
            }
        }

        private static void ParseCommandLine(string line)
        {
            var arguments = line.Split().ToArray().Reverse().Take(4).Reverse().Select(int.Parse).ToList();
            var x1 = arguments[0];
            var y1 = arguments[1];
            var x2 = arguments[2];
            var y2 = arguments[3];

            SwapInMatrix(x1, y1, x2, y2);
            PrintMatrix(matrix);
        }

        private static void SwapInMatrix(int x1, int y1, int x2, int y2)
        {
            try
            {
                var temp = matrix[x1, y1];
                matrix[x1, y1] = matrix[x2, y2];
                matrix[x2, y2] = temp;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(" {0}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
