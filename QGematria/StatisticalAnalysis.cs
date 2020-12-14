using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace QGematria
{
    public class StatisticalAnalysis
    {
        public static void AnalyzeFrequency()
        {
            string filePath = Data.GematricalQuran;

            if (!File.Exists(filePath))
            {
                Console.WriteLine("GematricalQuran.txt file does not exist.");
                return;
            }

            string text = File.ReadAllText(filePath);
            Dictionary<string, int> frequencyMap = CalculateWordFrequency(text);

            Console.WriteLine("Word Frequency Analysis:");
            foreach (var entry in frequencyMap)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        private static Dictionary<string, int> CalculateWordFrequency(string text)
        {
            string[] words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (frequencyMap.ContainsKey(word))
                {
                    frequencyMap[word]++;
                }
                else
                {
                    frequencyMap[word] = 1;
                }
            }

            return frequencyMap;
        }

        public static void CalculateWordLengthStats()
        {
            string filePath = Data.GematricalQuran;

            if (!File.Exists(filePath))
            {
                Console.WriteLine("GematricalQuran.txt file does not exist.");
                return;
            }

            string text = File.ReadAllText(filePath);
            List<int> wordLengths = GetWordLengths(text);

            Console.WriteLine("Word Length Statistics:");
            Console.WriteLine($"Total Words: {wordLengths.Count}");
            Console.WriteLine($"Minimum Length: {wordLengths.Min()}");
            Console.WriteLine($"Maximum Length: {wordLengths.Max()}");
            Console.WriteLine($"Average Length: {wordLengths.Average()}");
        }

        private static List<int> GetWordLengths(string text)
        {
            string[] words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> wordLengths = new List<int>();

            foreach (string word in words)
            {
                wordLengths.Add(word.Length);
            }

            return wordLengths;
        }
    }
}
