using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extract_emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var pattern = @"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+";
            var regex = new Regex(pattern);
            var reg = regex.Matches(input);

            for (int i = 0; i < reg.Count; i++)
            {
                Console.WriteLine(reg[i]);
            }
        }
    }
}
