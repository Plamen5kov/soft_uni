using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Words_count
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("../../text.txt");
            var text = sr.ReadToEnd();
            sr = new StreamReader("../../words.txt");
            var words = new List<string>();
            while (true)
            {
                var word = sr.ReadLine();
                if (word == null)
                {
                    break;
                }

                words.Add(word.Trim());
            }

            var result = new Dictionary<string, int>();
            var sw = new StreamWriter("../../results.txt");
            foreach (string word in words)
            {
                var pattern = @"\b" + word + @"\b";
                var regex = new Regex(string.Format(pattern, word), RegexOptions.IgnoreCase);
                var matchCollection = regex.Matches(text);
                result.Add(word, matchCollection.Count);

                sw.WriteLine(string.Format("{0} = {1}", word, result[word]));
                sw.Flush();
            }


        }
    }
}
