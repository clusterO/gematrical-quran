using System;

namespace QGematria
{
    public class Jafr
    {
        public static string BigJafr(string Sentence)
        {
            string NumericalLine = string.Empty;
            string[] Words = Sentence.Split(' ');

            foreach (string Word in Words)
            {
                int Sum = 0;
                for (int i = 0; i < Word.Length; i++)
                {
                    if (Data.GematricalValues.ContainsKey(Word[i]))
                        Sum += Data.GematricalValues[Word[i]];
                }

                NumericalLine += Sum + " ";
            }

            return NumericalLine.Trim();
        }
        public static string SmallJafr(string Sentence)
        {
            return String.Empty;
        }
        public static string JafrSequence(string Sentence, char Separator)
        {
            string Sequence = string.Empty;
            string[] Words = Sentence.Split(' ');

            foreach (string Word in Words)
            {
                string Seq = string.Empty;
                for (int i = 0; i < Word.Length; i++)
                {
                    if (Data.GematricalValues.ContainsKey(Word[i]))
                        if (i == Word.Length - 1)
                            Seq += $"{Data.GematricalValues[Word[i]]} ";
                        else
                            Seq += $"{Data.GematricalValues[Word[i]]}{Separator}";
                }

                Sequence += Seq;
            }

            return Sequence.Trim();
        }
    }
}