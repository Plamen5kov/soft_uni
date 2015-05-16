using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Valid_usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var pattern = @"[\\\/\(\) ]([A-z][A-z0-9_]{3,25})[\\\/\(\) ]";
            var regex = new Regex(pattern);
            var result = regex.Matches(input);

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].Groups[1]);
            }
        }
    }
}
