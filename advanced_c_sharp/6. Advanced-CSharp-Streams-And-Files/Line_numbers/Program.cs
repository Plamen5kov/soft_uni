using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("../../toRead.txt");
            var sw = new StreamWriter("../../toWrite.txt");

            var count = 0;
            while (true)
            {
                var line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }

                sw.WriteLine(count + line);
                sw.Flush();
                count++;
            }
        }
    }
}
