using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(",".ToCharArray()).ToList();

            var text = Console.ReadLine();

            var dictionary = new Dictionary<string, List<int>>();
            foreach (var banedWord in words)
            {
                var index = 0;
                dictionary.Add(banedWord.Trim(), new List<int>());
                while (true)
                {
                    index = text.IndexOf(banedWord.Trim(), index);
                    if(index == -1) 
                    {
                        break;
                    }
                    index++;
                    dictionary[banedWord.Trim()].Add(index);
                }
            }

            var sb = new StringBuilder(text);
            foreach (var bWord in dictionary)
            {
                foreach (var si in bWord.Value)
                {
                    var startIndex = si - 1;
                    for (int i = startIndex; i < startIndex + bWord.Key.Length; i++)
                    {
                        sb[i] = '*';
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
