using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extract_hyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a[^>]* href=(.+)( [A-z]+=)";
            var regex = new Regex(pattern);
            var resultList = new List<string>();

            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "END")
                {
                    break;
                }

                var matches = regex.Matches(input);
                for (int i = 0; i < matches.Count; i++)
                {
                    resultList.Add(matches[i].Groups[0].ToString());
                }
            }

            resultList.ForEach(Console.WriteLine);
        }
    }
}
