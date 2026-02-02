using System;

namespace LexicalTwist
{
    class LexicalService
    {
        public void ProcessWords(string word1, string word2)
        {
            if (WordUtils.IsReverse(word1, word2))
            {
                string result = WordUtils.Reverse(word1).ToLower();
                result = WordUtils.ReplaceVowels(result, '@');
                Console.WriteLine(result);
            }
            else
            {
                string combined = (word1 + word2).ToUpper();

                int vowels = WordUtils.CountVowels(combined);
                int consonants = WordUtils.CountConsonants(combined);

                if (vowels > consonants)
                    Console.WriteLine(WordUtils.FirstTwoUniqueVowels(combined));
                else if (consonants > vowels)
                    Console.WriteLine(WordUtils.FirstTwoUniqueConsonants(combined));
                else
                    Console.WriteLine("Vowels and consonants are equal");
            }
        }
    }
}
