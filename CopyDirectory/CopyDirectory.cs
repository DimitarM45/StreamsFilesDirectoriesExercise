namespace CopyDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] initialDir = Directory.GetFiles(inputPath);

            if (Directory.Exists(outputPath)) Directory.Delete(outputPath);

            Directory.CreateDirectory(outputPath);

            foreach (string file in initialDir)
            {
                string newFilePath = Path.Combine(outputPath, Path.GetFileName(file));

                File.Copy(file, newFilePath);
            }
        }
    }
}
