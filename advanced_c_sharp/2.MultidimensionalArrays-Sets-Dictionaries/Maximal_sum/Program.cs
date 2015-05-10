using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_sum
{
    class Program
    {
        static int[,] currentSquareCheck;
        static void Main(string[] args)
        {
            var rowsCols = Console.ReadLine().Split().ToArray().Select(int.Parse).ToList();
            var rows = rowsCols[0];
            var cols = rowsCols[1];

            var matrix = new int[rows + 1, cols + 1];

            FillMatrix(matrix, rows, cols);

            FindMaxSum(matrix, rows, cols);

            //PrintMatrix(matrix);
        }

        private static void FindMaxSum(int[,] matrix, int rows, int cols)
        {
            var sizeOfPattern = 3;
            var margin = sizeOfPattern / 2;
            var tempResult = 0;
            var lastSum = 0;
            var lastMatrix = new int[sizeOfPattern, sizeOfPattern];
            for (int row = margin; row <= (rows - margin); row++)
            {
                for (int col = margin; col <= (cols - margin); col++)
                {
                    tempResult = CalculateCurrentMatrixByPattern(matrix, sizeOfPattern, row, col);
                    if (tempResult > lastSum)
                    {
                        lastSum = tempResult;
                        lastMatrix = currentSquareCheck;
                    }
                }
            }

            Console.WriteLine("Sum: {0}", lastSum);
            PrintMatrix(lastMatrix);
        }

        private static int CalculateCurrentMatrixByPattern(int[,] matrix, int sizeOfPattern, int row, int col)
        {
            var margin = sizeOfPattern / 2;
            var currentSum = 0;
            currentSquareCheck = new int[sizeOfPattern, sizeOfPattern];

            for (int r = (row - margin), rr = 0; r <= (row + margin); r++, rr++)
            {
                for (int c = (col - margin), cc = 0; c <= (col + margin); c++, cc++)
                {
                    currentSquareCheck[rr, cc] = matrix[r, c];
                    currentSum += matrix[r, c];
                }
            }

            return currentSum;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int[,] matrix, int rows, int cols)
        {
            for (int row = 0; row <= rows; row++)
            {
                var line = Console.ReadLine().Split().ToArray().Select(int.Parse).ToList();
                for (int col = 0; col <= cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}
