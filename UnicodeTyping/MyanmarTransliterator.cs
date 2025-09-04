using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeTyping
{
    public class MyanmarTransliterator
    {
        private static readonly Dictionary<char, string> MyanmarToLatin = new Dictionary<char, string>
    {
        // Consonants
        {'က', "u"}, {'ခ', "c"}, {'ဂ', ":"}, {'ဃ', "C"},
        {'င', "i"}, {'စ', "p"}, {'ဆ', "q"}, {'ဇ', "Z"},
        {'ဈ', "Q"}, {'ဉ', "N"}, {'ည', "n"}, {'ဋ', "#"},
        {'ဌ', "X"}, {'ဍ', "!"}, {'ဎ', "~"}, {'ဏ', "P"},
        {'တ', "w"}, {'ထ', "x"}, {'ဒ', "K"}, {'ဓ', "L"},
        {'န', "e"}, {'ပ', "y"}, {'ဖ', "z"}, {'ဗ', "A"},
        {'ဘ', "b"}, {'မ', "r"}, {'ယ', "B"}, {'ရ', "&"},
        {'လ', "v"}, {'ဝ', "W"}, {'သ', "o"}, {'ဟ', "["},
        {'ဠ', "V"}, {'အ', "t"},
        
        // Independent vowels
        {'ဣ', "E"}, {'ဤ', "T"}, {'ဥ', "U"}, {'ဦ', "M"},
        {'ဧ', "{"}, {'ဩ', "]"}, {'ဪ', "}"},{'၏', "\\"},
        
        // Dependent vowels and diacritics
        {'ာ', "m"}, {'ါ', "g"}, {'ိ', "d"}, {'ီ', "D"},
        {'ု', "k"}, {'ူ', "l"}, {'ေ', "a"}, {'ဲ', "J"},
        {'ံ', "H"}, {'့', "h"}, {'း', ";"},{'ြ', "j"},{'ျ', "s"},
        {'ှ', "S"}, {'္', "F"},{'်', "f"},
        
        // Numbers
        {'၀', "0"}, {'၁', "1"}, {'၂', "2"}, {'၃', "3"},
        {'၄', "4"}, {'၅', "5"}, {'၆', "6"}, {'၇', "7"},
        {'၈', "8"}, {'၉', "9"},
        
        // Punctuation
        {'၊', ","}, {'။', "."}
    };

        public static string Transliterate(string myanmarText)
        {
            if (string.IsNullOrEmpty(myanmarText))
                return myanmarText;

            var result = new System.Text.StringBuilder();

            foreach (char c in myanmarText)
            {
                if (MyanmarToLatin.TryGetValue(c, out string latin))
                {
                    result.Append(latin);
                }
                else
                {
                    // Keep the character as-is if no mapping exists
                    result.Append(c);
                }
            }

            return result.ToString();
        }

    }
}
