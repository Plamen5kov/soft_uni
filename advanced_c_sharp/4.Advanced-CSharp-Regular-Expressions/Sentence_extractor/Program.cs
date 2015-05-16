using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sentence_extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordmatch = Console.ReadLine().Trim();
            var input = Console.ReadLine();
            var pattern = @"[A-Z].+?\s" + wordmatch + @"\s.+?[!.?]";

            var regex = new Regex(pattern);
            var result = regex.Matches(input);

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
