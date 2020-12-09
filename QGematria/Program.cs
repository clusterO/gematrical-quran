using System;
using System.Collections.Generic;
using System.IO;

namespace QGematria
{
    class Program
    {
        private static string GematricalQuran = "/home/c0/Projects/RiderProjects/QGematria/Quran/GematricalQuran.txt";
        private static string QuranTXT = "/home/c0/Projects/RiderProjects/QGematria/Quran/quran.txt";
        private static string GodelGematria = "/home/c0/Projects/RiderProjects/QGematria/Quran/GodelGematria.txt";
        private static Dictionary<char, int> GematricalValues = new Dictionary<char, int>
        {
            {'ا', 1},
            {'إ', 1},
            {'أ', 1},
            {'ٱ', 1},
            {'آ', 1},
            {'ء', 1},
            {'ب', 2},
            {'ت', 400},
            {'ث', 500},
            {'ج', 3},
            {'ح', 8},
            {'خ', 600},
            {'د', 4},
            {'ذ', 700},
            {'ر', 200},
            {'ز', 7},
            {'س', 60},
            {'ش', 300},
            {'ص', 90},
            {'ض', 800},
            {'ط', 9},
            {'ظ', 900},
            {'ع', 70},
            {'غ', 1000},
            {'ف', 80},
            {'ق', 100},
            {'ك', 20},
            {'ل', 30},
            {'م', 40},
            {'ن', 50},
            {'ه', 5},
            {'ة', 5},
            {'و', 6},
            {'ؤ', 1},
            {'ي', 10},
            {'ئ', 1},
            {'ى', 1},
            {'ّ', 0}
        };
        private static int[] Primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
        
        static void Main(string[] args)
        {
            using (TextReader Reader = File.OpenText(QuranTXT))
            {
                using (StreamWriter Writer = new StreamWriter(GematricalQuran))
                {
                    using (StreamWriter GWriter = new StreamWriter(GodelGematria))
                    {
                        string Line = String.Empty;
                        
                        while ((Line = Reader.ReadLine()) != null)
                        {
                            string NumericalLine = string.Empty;
                            string[] Words = Line.Split(' ');

                            foreach (string Word in Words)
                            {
                                int Sum = 0;
                                for (int i = 0; i < Word.Length; i++)
                                {
                                    // Add Special Cases
                                    if (GematricalValues.ContainsKey(Word[i]))
                                        Sum += GematricalValues[Word[i]];
                                }

                                NumericalLine += Sum + " ";
                            }
                            
                            Writer.WriteLine(NumericalLine);
                            GWriter.WriteLine(GNumberIt(NumericalLine));
                        }
                    }
                }
            }
        }

        private static string GNumberIt(string Sentence)
        {
            string[] Words = Sentence.Split(' ');
            string GSentence = string.Empty;
            
            foreach (string Word in Words)
            {
                int GWord = 0;
                for (int i = 0; i < Word.Length; i++)
                    GWord *= Primes[i]^Word[i];

                GSentence += GWord + " ";
            }

            return GSentence;
        }
    }
}