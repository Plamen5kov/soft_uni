using Slicing_file;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipping_sliced_files
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFile.Slice("../../mk_icon.jpg", "../../parts", 5);
            var di = new DirectoryInfo(@"..\..\parts");
            Compress(di);
            Decompress(di, new DirectoryInfo(@"..\..\whole"));
        }

        public static void Compress(DirectoryInfo directorySelected)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);

                            }
                        }
                    }

                }
            }
        }

        public static void Decompress(DirectoryInfo di, DirectoryInfo fileOutput)
        {
            var files = di.EnumerateFiles("*.gz");
            foreach (var fileInfo in files)
            {
                DecompressFile(fileInfo);
            }

            BinaryFile.Assemble(di.FullName, fileOutput.FullName + "\\copy.jpg");

        }

        private static void DecompressFile(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }
    }
}
