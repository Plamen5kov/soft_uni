using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_binary_file
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new FileStream("../../mk_icon.jpg", FileMode.Open);

            var data = new BinaryReader(fs).ReadBytes((int)fs.Length / 2);

            var targetFs = new FileStream("../../copy_icon.jpg", FileMode.OpenOrCreate);
            targetFs.Write(data, 0, (int)fs.Length / 2);
        }
    }
}
