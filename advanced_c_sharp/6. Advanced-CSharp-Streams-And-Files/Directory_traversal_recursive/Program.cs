using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_traversal_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var di = new DirectoryInfo(@"..\..\..\");

            TraverseDir(di, "");
        }

        private static void TraverseDir(DirectoryInfo di, string indent)
        {
            indent += "  ";
            Console.WriteLine("{0}-{1}", indent, di.Name);
            
            var dirs = di.GetDirectories();
            foreach (var dir in dirs)
            {
                TraverseDir(dir, indent);
            }

            indent += "\t    ";
            var files = di.GetFiles();
            foreach (var file in files)
            {
                Console.WriteLine("{0}{1}", indent, file.Name);
            }
        }
    }
}
