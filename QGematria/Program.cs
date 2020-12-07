using System;
using System.Collections.Generic;
using System.IO;

namespace QGematria
{
    class Program
    {
        private static string GematricalQuran = "/home/c0/Projects/RiderProjects/QGematria/Quran/GematricalQuran.txt";
        private static string QuranTXT = "/home/c0/Projects/RiderProjects/QGematria/Quran/quran-simple-clean.txt";
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
        };
        static void Main(string[] args)
        {
            using (TextReader Reader = File.OpenText(QuranTXT))
            {
                string Line;
                using (StreamWriter Writer = new StreamWriter(GematricalQuran))
                {
                    while ((Line = Reader.ReadLine()) != null)
                    {
                        string NumericalLine = string.Empty;
                        string[] Words = Line.Split(' ');
                        foreach (string Word in Words)
                        {
                            int Sum = 0;
                            for (int i = 0; i < Word.Length; i++)
                                Sum += GematricalValues[Word[i]];

                            NumericalLine += Sum + " ";
                        }

                        Writer.WriteLine(NumericalLine);
                    }
                }
            }
        }
    }
}