using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences_of_equal_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            var tokens = new Dictionary<string, int>();

            foreach (string word in input)
            {
                if (!tokens.ContainsKey(word))
                {
                    tokens.Add(word, 1);
                    continue;
                }
                tokens[word]++;
            }

            foreach (string token in tokens.Keys)
            {
                for (int i = 0; i < tokens[token]; i++)
                {
                    Console.Write("{0} ", token);
                }
                Console.WriteLine();
            }
        }
    }
}
