using System;
using System.IO;

namespace QGematria
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = Data.QuranTXT;
            string outputFile = Data.GematricalQuran;
            string godelOutputFile = Data.GodelGematria;

            ProcessTextFile(inputFile, outputFile, godelOutputFile);

            Console.WriteLine("Processing complete.");
        }

        static void ProcessTextFile(string inputFile, string outputFile, string godelOutputFile)
        {
            using (var reader = File.OpenText(inputFile))
            using (var writer = new StreamWriter(outputFile))
            using (var godelWriter = new StreamWriter(godelOutputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string sentence = Jafr.BigJafr(line);
                    string godelNumber = Godel.GNumberIt(line, ',');

                    writer.WriteLine(sentence);
                    godelWriter.WriteLine(godelNumber);
                }
            }
        }
    }
}
