using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace QGematria
{
    public class StatisticalAnalysis
    {
        public static Dictionary<string, int> AnalyzeFrequency(string path = null)
        {
            string filePath = path != null ? path : Data.GematricalQuran;
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Gematrical Quran file does not exist.");
                return new Dictionary<string, int>();
            }

            string text = File.ReadAllText(filePath);
            Dictionary<string, int> frequencyMap = CalculateWordFrequency(text);

            return frequencyMap;
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
                Console.WriteLine("Gematrical Quran file does not exist.");
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

        public static Dictionary<string, List<double>> AssignWordCoordinates(string path = null)
        {
            string filePath = path != null ? path : Data.GematricalQuran;
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Gematrical Quran file does not exist.");
                return new Dictionary<string, List<double>>();
            }

            string[] lines = File.ReadAllLines(filePath);
            Dictionary<string, List<double>> wordCoordinates = new Dictionary<string, List<double>>();

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];

                    if (!wordCoordinates.ContainsKey(word))
                    {
                        wordCoordinates[word] = new List<double>();
                    }

                    if (i > 0)
                    {
                        double distance = Math.Abs(Convert.ToDouble(words[i]) - Convert.ToDouble(words[i - 1]));
                        wordCoordinates[word].Add(distance);
                    }
                }
            }

            return wordCoordinates;
        }

        public static double CalculateCorrelation(string path = null)
        {
            string filePath = path != null ? path : Data.GematricalQuran;

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Gematrical Quran file does not exist.");
                return 0.0;
            }

            List<List<double>> data = ReadDataFromFile(filePath);

            if (data.Count < 2)
            {
                Console.WriteLine("Insufficient data to calculate correlation.");
                return 0.0;
            }

            List<double> data1 = data[0];
            List<double> data2 = data[1];

            if (data1.Count != data2.Count)
            {
                Console.WriteLine("The data sets must have the same length.");
                return 0.0;
            }

            List<Tuple<double, double>> combinedData = CombineData(data1, data2);

            StatisticalAnalysis analysis = new StatisticalAnalysis();
            double correlation = analysis.CalculateCorrelation(combinedData);

            return correlation;
        }
    }
}
