using System.Collections.Generic;

namespace QGematria
{
    public class Data
    {
        public static string GematricalQuran { get; } = "./Quran/GematricalQuran.txt";
        public static string QuranTXT { get; } = "./Quran/quran-clean.txt";
        public static string GodelGematria { get; } = "./Quran/GodelGematria.txt";

        public static Dictionary<char, int> GematricalValues { get; } = new Dictionary<char, int>
        {
            { 'ا', 1 },
            { 'إ', 1 },
            { 'أ', 1 },
            { 'ٱ', 1 },
            { 'آ', 1 }, // 2
            { 'ب', 2 },
            { 'ت', 400 },
            { 'ث', 500 },
            { 'ج', 3 },
            { 'ح', 8 },
            { 'خ', 600 },
            { 'د', 4 },
            { 'ذ', 700 },
            { 'ر', 200 },
            { 'ز', 7 },
            { 'س', 60 },
            { 'ش', 300 },
            { 'ص', 90 },
            { 'ض', 800 },
            { 'ط', 9 },
            { 'ظ', 900 },
            { 'ع', 70 },
            { 'غ', 1000 },
            { 'ف', 80 },
            { 'ق', 100 },
            { 'ك', 20 },
            { 'ل', 30 },
            { 'م', 40 },
            { 'ن', 50 },
            { 'ه', 5 },
            { 'ة', 5 }, // 400 // 203
            { 'و', 6 },
            { 'ؤ', 6 }, // 1
            { 'ي', 10 },
            { 'ى', 10 }, // 1
            { 'ئ', 10 }, // 1
            { 'ء', 0 }, // 1 // 70
            { 'ّ', 0 } // * 2
        };

        public static Dictionary<char, int> GodelValues { get; } = new Dictionary<char, int>
        {
            { 'ا', 1 },
            { 'إ', 1 },
            { 'أ', 1 },
            { 'ٱ', 1 },
            { 'آ', 1 },
            { 'ء', 1 },
            { 'ب', 2 },
            { 'ت', 3 },
            { 'ث', 4 },
            { 'ج', 5 },
            { 'ح', 6 },
            { 'خ', 7 },
            { 'د', 8 },
            { 'ذ', 9 },
            { 'ر', 10 },
            { 'ز', 11 },
            { 'س', 12 },
            { 'ش', 13 },
            { 'ص', 14 },
            { 'ض', 15 },
            { 'ط', 16 },
            { 'ظ', 17 },
            { 'ع', 18 },
            { 'غ', 19 },
            { 'ف', 20 },
            { 'ق', 21 },
            { 'ك', 22 },
            { 'ل', 21 },
            { 'م', 24 },
            { 'ن', 25 },
            { 'ه', 26 },
            { 'ة', 26 },
            { 'و', 27 },
            { 'ؤ', 27 },
            { 'ي', 28 },
            { 'ى', 28 },
            { 'ئ', 28 },
        };

        public static int[] Primes { get; } =
            {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

        public static Dictionary<string, char[]> EmoWord { get; } = new Dictionary<string, char[]>
        {
            {"نار", new [] {'ا','ه','ط','م','ف','ش','ذ'}},
            {"ماء", new [] {'غ','خ','ر','ع','ل','ح','د'}},
            {"تراب", new [] {'ض','ت','ص','ن','ي','و','ب'}},
            {"هواء", new [] {'ظ','ث','ق','س','ك','ز','ج'}}
        };

        public static Dictionary<string, char[]> LogicWord { get; } = new Dictionary<string, char[]>
        {
            {"قضية شرطية", new [] {'⇒', '→', '⊃'}},
            {"قضية تكافؤية", new [] {'⇔', '≡', '↔'}},
            {"نفي", new [] {'¬', '˜', '!'}},
            {"و", new [] {'∧', '·', '&'}},
            {"او", new [] {'∨', '+', '∥'}},
            {"xor", new [] {'⊕', '⊻'}},
            {"tautology", new [] {'⊤', 'T', '1'}},
            {"contradiction", new [] {'⊥', 'F', '0'}}, 
            {"there exists", new [] {'∃'}},
            {"provable", new [] {'⊢'}},
            {"entails", new [] {'⊨'}},
            // {"for all", new [] {'∀', '()'}},
            // {"there exists exactly one", new [] {'∃!'}},
            // {"definition", new [] {'≔', '≡', ':⇔'}},
            // {"precedence grouping", new [] {'( )'}},

        };
    }
}
