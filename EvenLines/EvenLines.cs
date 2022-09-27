namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Reflection.PortableExecutable;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int lineCount = 0;

                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null) break;

                    if (lineCount++ % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSymbols(line);
                        string reversedOrder = ReverseOrder(replacedSymbols);

                        sb.AppendLine(reversedOrder);
                    }

                    if (line == null) break;
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (char symbol in symbolsToReplace)
                line = line.Replace(symbol, '@');

            return line;
        }

        private static string ReverseOrder(string replacedSymbols)
        {
            string[] reversedLine = replacedSymbols.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            return string.Join(' ', reversedLine);
        }
    }
}
