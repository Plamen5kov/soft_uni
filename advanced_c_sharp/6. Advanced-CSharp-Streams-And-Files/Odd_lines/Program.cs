using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("../../test.txt");

            var count = 0;
            while (true)
            {
                var line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (count % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                count++;
            }
        }
    }
}
