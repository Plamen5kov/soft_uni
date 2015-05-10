using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_matrix_rotation
{
    class Program
    {
        static char[,] matrix;
        static char[,] resultMatrix;
        static int rows;
        static int cols;
        static void Main(string[] args)
        {
            //test
            // Rotate(180)
            // hello
            // softuni
            // exam
            // END

            //test
            // Rotate(270)
            // hello
            // softuni
            // exam
            // END

            //test
            // Rotate(720)
            // js
            // exam
            // END

            // test
            // Rotate(810)
            // js
            // exam
            // END

            var input = Console.ReadLine();
            var start = input.IndexOf('(') + 1;
            var end = input.LastIndexOf(')');
            var degreesAsString = input.Substring(start, end - start);
            var degrees = int.Parse(degreesAsString);
            var actualDegrees = degrees % 360;

            FillMatrix();
            rows = matrix.GetLength(0);
            cols = matrix.GetLength(1);

            RotateMatrix(actualDegrees);
        }

        private static void RotateMatrix(int actualDegrees)
        {
            if (actualDegrees == 0)
            {
                resultMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
                resultMatrix = matrix;
            }
            else if (actualDegrees == 90)
            {
                resultMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];
                Rotate90(resultMatrix);
            }
            else if (actualDegrees == 180)
            {
                resultMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
                Rotate180(resultMatrix);
            }
            else if (actualDegrees == 270)
            {
                resultMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];
                Rotate270(resultMatrix);
            }

            PrintMatrix(resultMatrix);
        }

        private static void Rotate270(char[,] resultMatrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    resultMatrix[cols - 1 - col, row] = matrix[row, col];
                }
            }
        }

        private static void Rotate180(char[,] resultMatrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    resultMatrix[rows - 1 - row, cols - 1 - col] = matrix[row, col];
                }
            }
        }

        private static void Rotate90(char[,] resultMatrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    resultMatrix[col, rows - 1 - row] = matrix[row, col];
                }
            }
        }

        private static void PrintMatrix(char[,] resultMatrix)
        {
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write("{0}", resultMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix()
        {
            var list = new List<List<char>>();
            var rows = 0;
            var cols = 0;
            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "END")
                {
                    break;
                }
                rows++;
                var tempList = new List<char>();
                foreach (var symbol in input)
                {
                    tempList.Add(symbol);

                }
                if (cols < tempList.Count)
                {
                    cols = tempList.Count;
                }
                list.Add(tempList);
            }

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = ' ';
                }
            }

            for (int row = 0; row < list.Count; row++)
            {
                for (int col = 0; col < list[row].Count; col++)
                {
                    matrix[row, col] = list[row][col];
                }
            }
        }
    }
}
