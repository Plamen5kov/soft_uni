using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Replace_a_tag
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            var a = @"
<ul>
    <li>
    <a href=http://softuni.bg>SoftUni</a>
    </li>
</ul>


";

            var sb = ReadInput();

            //IDictionary<string, string> map = new Dictionary<string, string>()
            //{
            //{"<a","[url"},
            //{"</a>","[/url]"},
            //{"([<a].+?)>", "1"},
            //};

            string input = sb.ToString();
            
            //var regex = new Regex(String.Join("|", map.Keys));
            //var result = regex.Replace(input, m => map[m.Value]);


            string pattern = "(<a)(.+?)(>)(.*)(</a>)";
            string replacement = "[URL $2] $4 [/URL]";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);

            Console.WriteLine("Original String: {0}", input);
            Console.WriteLine("Replacement String: {0}", result);      
            
        }

private static StringBuilder ReadInput()
{
            var sb = new StringBuilder();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "")
                {
                    break;
                }

                sb.Append(line);
            }
return sb;
}
    }
}
