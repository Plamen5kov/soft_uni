using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_digit_of_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write an integer...");
            var number = int.Parse(Console.ReadLine());

            var lastNumber = GetLastNumber(number);
            var lastNumberAsString = GetNumberAsString(lastNumber);

            Console.WriteLine("The last number is: {0}", lastNumberAsString);
        }

        public static int GetLastNumber(int number)
        {
            return number % 10;
        }

        public static string GetNumberAsString(int number)
        {
            if(number < 10) {
                switch (number)
                {
                    case 1: return "one"; 
                    case 2: return "two"; 
                    case 3: return "tree";
                    case 4: return "four";
                    case 5: return "five";
                    case 6: return "six";
                    case 7: return "seven";
                    case 8: return "eight";
                    case 9: return "nine";
                    default:
                        break;
                }
            }

            return null;
        }
    }
}
