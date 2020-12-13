using System;
using System.Text;

namespace QGematria
{
    public class Jafr
    {
        public static string BigJafr(string sentence)
        {
            var numericalLine = new StringBuilder();
            var words = sentence.Split(' ');

            foreach (var word in words)
            {
                int sum = 0;
                foreach (var character in word)
                {
                    if (Data.GematricalValues.TryGetValue(character, out var value))
                    {
                        sum += value;
                    }
                }

                numericalLine.Append(sum).Append(' ');
            }

            return numericalLine.ToString().Trim();
        }


        public static string SmallJafr(string Sentence)
        {
            return String.Empty;
        }

        public static string JafrSequence(string sentence, char separator)
        {
            StringBuilder sequence = new StringBuilder();
            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                StringBuilder seq = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    if (Data.GematricalValues.ContainsKey(word[i]))
                    {
                        seq.Append(Data.GematricalValues[word[i]]);
                        if (i != word.Length - 1)
                        {
                            seq.Append(separator);
                        }
                    }
                }

                sequence.Append(seq.ToString()).Append(' ');
            }

            return sequence.ToString().Trim();
        }
    }
}