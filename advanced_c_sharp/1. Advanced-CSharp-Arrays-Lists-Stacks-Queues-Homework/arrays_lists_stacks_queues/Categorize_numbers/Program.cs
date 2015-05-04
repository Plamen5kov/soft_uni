using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorize_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().ToArray().Select(double.Parse).ToList();
            var wholeList = new List<int>();
            var fractList = new List<double>();

            foreach (var element in numbers)
            {
                var fractPart = element - Math.Truncate(element);
                if (fractPart > 0)
                {
                    fractList.Add(element);
                }
                else
                {
                    wholeList.Add((int)element);
                }
            }

            PrintFract(fractList);
            PrintWhole(wholeList);
        }

        private static void PrintWhole(List<int> wholeList)
        {
            Console.WriteLine("[ {0} ] -> \nmin: {1} \nmax: {2} \nsum: {3} \navg: {4:F2}",
                string.Join(", ", wholeList),
                wholeList.Min(),
                wholeList.Max(),
                wholeList.Sum(),
                wholeList.Average());
        }

        private static void PrintFract(List<double> fractList)
        {
            Console.WriteLine("[ {0} ] -> \nmin: {1:F2} \nmax: {2:F2} \nsum: {3:F2} \navg: {4:F2}", 
                string.Join(", ", fractList),
                fractList.Min(),
                fractList.Max(),
                fractList.Sum(),
                fractList.Average());
        }
    }
}
