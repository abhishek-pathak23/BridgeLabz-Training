using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LexicalTwist
{
    class WordUtils
    {
        public static bool IsReverse(string w1, string w2)
        {
            char[] arr = w1.ToCharArray();
            Array.Reverse(arr);
            return new string(arr).Equals(w2, StringComparison.OrdinalIgnoreCase);
        }

        public static string Reverse(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string ReplaceVowels(string word, char ch)
        {
            return Regex.Replace(word, "[aeiou]", ch.ToString());
        }

        public static int CountVowels(string word)
        {
            return word.Count(c => "AEIOU".Contains(c));
        }

        public static int CountConsonants(string word)
        {
            return word.Count(c => char.IsLetter(c) && !"AEIOU".Contains(c));
        }

        public static string FirstTwoUniqueVowels(string word)
        {
            return GetFirstTwo(word, "AEIOU");
        }

        public static string FirstTwoUniqueConsonants(string word)
        {
            return GetFirstTwo(word, "BCDFGHJKLMNPQRSTVWXYZ");
        }

        private static string GetFirstTwo(string word, string chars)
        {
            string result = "";
            foreach (char c in word)
            {
                if (chars.Contains(c) && !result.Contains(c))
                    result += c;

                if (result.Length == 2)
                    break;
            }
            return result;
        }
    }
}
