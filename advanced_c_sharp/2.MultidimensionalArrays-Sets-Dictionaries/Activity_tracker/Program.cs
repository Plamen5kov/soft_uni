using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //tests
            // 5
            // 24/07/2014 Angel 4600
            // 24/07/2014 Pesho 3200
            // 25/07/2014 Angel 6500
            // 01/08/2014 Pesho 5600
            // 03/08/2014 Ivan 11400

            var userInfo = new Dictionary<int, Dictionary<string, int>>();

            var linesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesNumber; i++)
            {
                var lineToParse = Console.ReadLine().Split().ToArray();

                var date = lineToParse[0];
                var month = int.Parse(date.Split('/')[1]);
                var user = lineToParse[1];
                var miles = int.Parse(lineToParse[2]);

                if(!userInfo.ContainsKey(month))
                {
                    userInfo.Add(month, new Dictionary<string, int>());
                }

                if (!userInfo[month].ContainsKey(user))
                {
                    userInfo[month].Add(user, 0);
                }

                userInfo[month][user] += miles;
            }

            foreach (var userInf in userInfo)
            {
                var tempList = new List<string>();
                foreach (var pair in userInf.Value.OrderBy(x => x.Key))
                {
                    tempList.Add(string.Format("{0}({1})", pair.Key, pair.Value));
                }
                Console.WriteLine("{0}: {1}", userInf.Key, string.Join(", ", tempList));
            }
        }
    }
}
