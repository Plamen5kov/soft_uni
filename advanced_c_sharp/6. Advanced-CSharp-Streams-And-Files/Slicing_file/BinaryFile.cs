using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicing_file
{
    public static class BinaryFile
    {
        static void Main(string[] args)
        {
            Slice("../../mk_icon.jpg", "../../parts", 4);
            Assemble("../../parts", "../../whole/result.jpg");
        }

        public static void Slice(string fileInputPath, string folderOutputPath, int outputFilesCount)
        {
            // Store the file in a byte array
            Byte[] byteSource = System.IO.File.ReadAllBytes(fileInputPath);

            FileInfo fiSource = new FileInfo(fileInputPath);

            int partSize = (int)Math.Ceiling((double)(fiSource.Length / outputFilesCount));

            // The offset at which to start reading from the source file
            int fileOffset = 0;

            // Stores the name of each file part
            string currPartPath;

            // The file stream that will hold each file part
            FileStream fsPart;

            // Loop through as many times we need to create the partial files
            for (int i = 0; i < outputFilesCount; i++)
            {
                // Store the path of the new part
                currPartPath = folderOutputPath + "\\" + fiSource.Name + "." + String.Format(@"{0:D4}", i) + ".part";

                // A filestream for the path
                if (!File.Exists(currPartPath))
                {
                    // Calculate the remaining size of the whole file
                    fsPart = new FileStream(currPartPath, FileMode.CreateNew);

                    // Set the new offset
                    fileOffset = i * partSize;

                    // Write the byte chunk to the part file
                    fsPart.Write(byteSource, fileOffset, partSize);

                    // Close the file stream
                    fsPart.Close();
                }
            }
        }

        public static void Assemble(string folderInputPath, string fileOutputPath)
        {
            // Needed to get all files in that directory
            DirectoryInfo diSource = new DirectoryInfo(folderInputPath);

            // Result file
            FileStream fsSource = new FileStream(fileOutputPath, FileMode.Append, FileAccess.Write);

            // Loop through all the files with the *.part extension in the folder
            foreach (FileInfo fiPart in diSource.GetFiles(@"*.part"))
            {
                Byte[] bytePart = System.IO.File.ReadAllBytes(fiPart.FullName);

                // Write the bytes to the reconstructed file appending to previous written data
                fsSource.Write(bytePart, 0, bytePart.Length);
            }

            fsSource.Close();
        }

    }
}
