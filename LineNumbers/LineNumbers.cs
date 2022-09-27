namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            string[] alteredLines = new string[lines.Length];

            int lineCounter = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = 0;
                int punctuationCount = 0;

                foreach (char symbol in lines[i])
                {
                    if (char.IsLetter(symbol)) lettersCount++;

                    else if (char.IsPunctuation(symbol)) punctuationCount++;
                }

                alteredLines[i] = $"Line {lineCounter++}: {lines[i]} ({lettersCount})({punctuationCount})"; 
            }

            File.WriteAllLines(outputFilePath, alteredLines);
        }
    }
}
