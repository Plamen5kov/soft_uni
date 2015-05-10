using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fill_the_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;

            var matrix = FillMatrixTopToBottom(n);
            PrintMatrix(matrix);

            matrix = FillMatrixPatternB(n);
            PrintMatrix(matrix);
        }

        private static int[,] FillMatrixPatternB(int n)
        {
            var matrix = new int[n, n];
            var counter = 1;
            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = counter++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter++;
                    }
                }
            }
            return matrix;
        }

        private static int[,] FillMatrixTopToBottom(int n)
        {
            var matrix = new int[n, n];
            var counter = 1;
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter++;
                }
            }
            return matrix;
        }

        private static void PrintMatrix(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write("{0}", array[row, col].ToString().PadLeft(3, ' '));
                }
                Console.WriteLine();
            }
        }
    }
}
