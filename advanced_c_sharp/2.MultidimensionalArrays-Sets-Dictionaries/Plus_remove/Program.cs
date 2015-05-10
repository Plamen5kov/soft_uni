using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plus_remove
{
    class Program
    {
        static List<List<string>> matrix;
        static List<List<string>> resultMatrix;
        static void Main(string[] args)
        {
            //test
            // ab**l5
            // bBb*555
            // absh*5
            // ttHHH
            // ttth
            // END

            //test
            // 888**t*
            // 8888ttt
            // 888ttt<<
            // *8*0t>>hi
            // END

            FillMatrix();
            MarkPlusSignes(matrix);
            PrintMatrix(resultMatrix);
        }

        private static void PrintMatrix(List<List<string>> matrix)
        {
            foreach (var item in matrix)
            {
                item.RemoveAll(x => x == "_");
                item.RemoveAll(x => x == " ");
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void MarkPlusSignes(List<List<string>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (row > 0 && row < matrix.Count - 1)
                {
                    for (int col = 0; col < matrix[row].Count; col++)
                    {
                        if (col > 0 && col < (matrix[row].Count - 1))
                        {
                            CheckAndMarkPlusses(matrix, row, col);
                        }
                    }
                }
            }
        }

        private static void CheckAndMarkPlusses(List<List<string>> matrix, int row, int col)
        {
            var currentSymbol = matrix[row][col].ToLower();
            var currentSymbolInResult = resultMatrix[row][col];
            var upper = matrix[row - 1][col].ToLower();
            var bottom = matrix[row + 1][col].ToLower();
            var left = matrix[row][col - 1].ToLower();
            var right = matrix[row][col + 1].ToLower();

            var markingSymbol = "_";

            //if valid plus
            if (upper == currentSymbol &&
                bottom == currentSymbol &&
                left == currentSymbol &&
                right == currentSymbol)
            {
                resultMatrix[row][col] = markingSymbol;
                resultMatrix[row - 1][col] = markingSymbol;
                resultMatrix[row + 1][col] = markingSymbol;
                resultMatrix[row][col - 1] = markingSymbol;
                resultMatrix[row][col + 1] = markingSymbol;
            }
        }

        private static void FillMatrix()
        {
            var list = new List<List<string>>();
            var max = 0;
            var count = 0;
            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "END")
                {
                    break;
                }

                count++;
                var tempList = new List<string>();
                foreach (var sym in input)
                {
                    tempList.Add(sym.ToString());              
                }
                list.Add(tempList);
                if (max < input.Length)
                {
                    max = input.Length;
                }
            }

            matrix = new List<List<string>>();
            resultMatrix = new List<List<string>>(); 

            for (int row = 0; row < count; row++)
            {
                var cr = new List<string>();
                var c = new List<string>();
                for (int col = 0; col < max; col++)
                {
                    cr.Add("_");
                    c.Add(" ");
                }
                resultMatrix.Add(c);
                matrix.Add(cr);
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    matrix[i][j] = list[i][j];
                    if(list[i][j] != "_")
                    {
                        resultMatrix[i][j] = list[i][j];
                    }
                }
            }
        }
    }
}
