using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_arrays_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                                        .Split()
                                        .ToArray()
                                        .Select(int.Parse)
                                        .ToList();
            input.Sort((x, y) => x - y);
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
