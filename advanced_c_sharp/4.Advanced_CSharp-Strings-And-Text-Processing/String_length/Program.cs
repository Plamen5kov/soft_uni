using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_length
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int i = 0;
            var sb = new StringBuilder();
            for (i = 0; i < input.Length; i++)
            {
                if (i >= 20)
                {
                    Console.WriteLine(sb.ToString());
                    break;
                }
                var currentSymbol = input[i];
                sb.Append(currentSymbol);
            }

            if (i < 19)
            {
                var count = 20 - i;
                for (int j = 0; j < count; j++)
                {
                    sb.Append("*");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
