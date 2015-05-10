using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static Dictionary<string, List<string>> names;
        static void Main(string[] args)
        {
            names = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "search")
                {
                    input = Console.ReadLine();
                    var searchResult = SearchForName(input);
                    Console.WriteLine(searchResult);
                }
                else
                {
                    SaveContactToDictionary(input);
                }
            }
        }

        private static void SaveContactToDictionary(string input)
        {
            var arguments = input.Split('-').ToArray();
            var name = arguments[0].Trim();
            var number = arguments[1].Trim();
            if (!names.ContainsKey(name))
            {
                names.Add(name, new List<string>());
            }
            names[name].Add(number);
        }

        private static string SearchForName(string input)
        {
            var name = input.Trim();
            var sb = new StringBuilder();
            if (names.ContainsKey(name))
            {
                foreach (var number in names[name])
                {
                    sb.Append(name);
                    sb.Append(" -> ");
                    sb.Append(number);
                    sb.AppendLine();
                }
            }
            else
            {
                sb.AppendFormat("Contact {0} does not exist.", name);
            }

            return sb.ToString();
        }
    }
}
