namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            FileInfo[] fileInfo = new DirectoryInfo(inputFolderPath).EnumerateFiles().ToArray();

            Dictionary<string, List<FileInfo>> filesByExt = new Dictionary<string, List<FileInfo>>();

            foreach (FileInfo file in fileInfo)
            {
                if (!filesByExt.ContainsKey(file.Extension))
                    filesByExt.Add(file.Extension, new List<FileInfo>());

                filesByExt[file.Extension].Add(file);
            }

            filesByExt = filesByExt
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            StringBuilder sb = new StringBuilder();

            foreach (var (fileExtension, files) in filesByExt)
            {
                var orderedFileCollection = files.OrderBy(x => x.Length);

                sb.AppendLine(fileExtension);

                foreach (FileInfo file in orderedFileCollection)
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
