using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_in_мatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new string[,] {
                                    {"ha", "fifi", "ho", "hi"},
                                    {"fo", "ha", "hi", "xx"},
                                    {"xxx", "ho", "ha", "xx"},
                                    };
            var matrix1 = new string[,] {
                                    {"pp", "pp", "pp"},
                                    {"s", "qq", "s"},
                                    {"pp", "qq", "s"},
                                    };

            var test = new string[,] {
                                    {"a", "fifi", "ho", "hi"},
                                    {"a", "ha", "hi", "xx"},
                                    {"a", "ho", "ha", "xx"},
                                    };

            FindLongestSequence(test);
            FindLongestSequence(matrix);
            FindLongestSequence(matrix1);
        }

        private static void FindLongestSequence(string[,] matrix)
        {
            var count = 1;
            var maxCount = 0;
            var maxCountElement = string.Empty;
            var lastMax = string.Empty;

            //check horizontal
            maxCountElement = matrix[0, 0];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        count++;
                        lastMax = matrix[row, col];
                    }
                    else
                    {
                        if (maxCount < count)
                        {
                            maxCount = count;
                            maxCountElement = lastMax;
                        }
                    }
                }
            }


            count = 1;
            lastMax = string.Empty;
            //check vertical
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col])
                    {
                        count++;
                        lastMax = matrix[row, col];
                    }
                    else
                    {
                        if (maxCount < count)
                        {
                            maxCount = count;
                            maxCountElement = lastMax;
                            count = 1;
                        }
                    }
                }
            }

            count = 1;
            lastMax = string.Empty;
            //check diagonal
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    for (int col = c, row = r; (col < matrix.GetLength(1) - 1) && (row < matrix.GetLength(0) - 1); col++, row++)
                    {
                        if (matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            count++;
                            lastMax = matrix[row, col];
                        }
                        else
                        {
                            if (maxCount < count)
                            {
                                maxCount = count;
                                maxCountElement = lastMax;
                                count = 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                var separator = string.Empty;
                if(i != maxCount -1) 
                {
                    separator = ",";
                }
                Console.Write("{0}{1} ", maxCountElement, separator);
            }
            Console.WriteLine();
        }
    }
}
