using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Will reverse any 64 bit long number you put in...");
            var input = double.Parse(Console.ReadLine());
            double reversedNumber = GetReversedNumber(input);
            Console.WriteLine(reversedNumber);
        }

        private static double GetReversedNumber(double input)
        {
            var numAsString = input.ToString();
            var wholePart = string.Empty;
            var fractPart = string.Empty;
            if(numAsString.IndexOf('.') != -1)
            {
                var wholeFractional = numAsString.Split('.');
                wholePart = wholeFractional[0];
                fractPart = wholeFractional[1];
                var reversedWholePart = string.Join("", wholePart.Reverse());
                var reversedFractPart = string.Join("", fractPart.Reverse());

                var newNumber = reversedFractPart + "." + reversedWholePart;
                var newNumberAsDouble = double.Parse(newNumber);
                return newNumberAsDouble;
            }

            var newReversedNum = string.Join("", numAsString.Reverse());
            var newReversedNumAsDouble = double.Parse(newReversedNum + "");
            return newReversedNumAsDouble;
        }
    }
}
