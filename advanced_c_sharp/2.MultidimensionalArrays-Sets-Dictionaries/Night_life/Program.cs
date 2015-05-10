using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Night_life
{
    class Program
    {
        static void Main(string[] args)
        {
            //test 
            // Sofia;Biad;Preslava
            // Pernik;Stadion na mira;Vinkel
            // New York;Statue of Liberty;Krisko
            // Oslo;everywhere;Behemoth
            // Pernik;Letishteto;RoYaL
            // Pernik;Stadion na mira;Bankin
            // Pernik;Stadion na mira;Vinkel
            // END

            //cities saved as is
            //venues saved alphabetically
            //performers are unique and saved alphabetically

            var nightLifeInfo = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            var separator = ';';
            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "END")
                {
                    break;
                }
                var arguments = input.Split(separator).ToArray();
                var city = arguments[0].Trim();
                var venue = arguments[1].Trim();
                var artist = arguments[2].Trim();
                AddInfo(city, venue, artist, nightLifeInfo);
            }

            PrintInfo(nightLifeInfo);
        }

        private static void PrintInfo(Dictionary<string, Dictionary<string, HashSet<string>>> nightLifeInfo)
        {
            var sb = new StringBuilder();
            foreach (var cityInfo in nightLifeInfo)
            {
                sb.AppendLine(cityInfo.Key);
                foreach (var venue in cityInfo.Value.OrderBy(x => x.Key))
                {
                    sb.AppendFormat("->{0}: {1}\n", venue.Key, string.Join(", ", venue.Value.OrderBy(x => x)));
                }
            }

            Console.WriteLine(sb);
        }

        private static void AddInfo(string city, string venue, string artist, Dictionary<string, Dictionary<string, HashSet<string>>> nightLifeInfo)
        {
            if (!nightLifeInfo.ContainsKey(city))
            {
                var venues = new Dictionary<string, HashSet<string>>();
                nightLifeInfo.Add(city, venues);
            }

            if (!nightLifeInfo[city].ContainsKey(venue))
            {
                nightLifeInfo[city].Add(venue, new HashSet<string>());
            }
            
            nightLifeInfo[city][venue].Add(artist);
        }
    }
}
