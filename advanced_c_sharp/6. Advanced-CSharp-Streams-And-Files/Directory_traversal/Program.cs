using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new DirectoryInfo(".");

            var files = dirInfo.GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
