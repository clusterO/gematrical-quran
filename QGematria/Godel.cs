using System;
using System.Text;

namespace QGematria
{
    public class Godel
    {
        public static string GNumberIt(string sentence, char separator)
        {
            string[] words = sentence.Split(' ');
            StringBuilder gSentence = new StringBuilder();

            foreach (string word in words)
            {
                double gWord = 1;

                for (int i = 0; i < word.Length; i++)
                {
                    if (Data.GodelValues.ContainsKey(word[i]))
                    {
                        gWord *= Math.Pow(Data.Primes[i], Data.GodelValues[word[i]]);
                    }
                }

                gSentence.Append($"{gWord}{separator} ");
            }

            return gSentence.ToString().Trim();
        }

        // Arithmetization A(155,555,155, m=m) -> true
        public static bool Arithmetization(string values, string variable)
        {
            string[] valueStrings = values.Split(',');
            int[] nums = Array.ConvertAll(valueStrings, int.Parse);

            // Perform the arithmetization calculation
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int exponent = nums[i];
                result = (int)Math.Pow(result, exponent);
            }

            int variableValue;
            if (Data.GodelValues.TryGetValue(variable, out variableValue))
            {
                return result == variableValue;
            }

            return false;
        }

        // Substitution S(l,m,n)
        public static string Substitution(string l, string m, string n)
        {
            string result = l;
            result = result.Replace(m, n);

            return result;
        }
    }
}


