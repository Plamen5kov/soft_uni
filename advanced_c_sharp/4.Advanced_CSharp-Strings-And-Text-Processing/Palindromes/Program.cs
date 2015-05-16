using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            // Hi,exe? ABBA! Hog fully a string. Bob

            var input = Console.ReadLine();
            var words = input.Split(",.!?; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var word in words)
            {
                var isPalindrom = CheckPalindrom(word);
                if (isPalindrom)
                {
                    Console.WriteLine(word);
                }
            }
        }

        private static bool CheckPalindrom(string word)
        {
            var isPalindrom = false;
            for (int start = 0, end = word.Length - 1; start <= end; start++, end--)
            {
                //if word is one letter
                if (end == -1)
                {
                    isPalindrom = true;
                    break;
                }

                if (word[start] != word[end])
                {
                    isPalindrom = false;
                    break;
                }

                isPalindrom = true;
            }

            return isPalindrom;
        }
    }
}
