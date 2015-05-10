using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var lettersDictionary = new Dictionary<char, int>();

            var input = Console.ReadLine();
            foreach (var symbol in input)
            {
                if (!lettersDictionary.ContainsKey(symbol))
                {
                    lettersDictionary.Add(symbol, 0);
                }
                lettersDictionary[symbol]++;
            }

            var sortedLettersDictionary = lettersDictionary.OrderBy(l => l.Key);
            foreach (var pair in sortedLettersDictionary)
            {
                Console.WriteLine("{0}: {1} times/s", pair.Key, pair.Value);
            }
        }
    }
}
