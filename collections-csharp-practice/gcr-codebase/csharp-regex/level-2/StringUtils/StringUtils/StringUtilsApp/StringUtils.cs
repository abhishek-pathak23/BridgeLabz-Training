using System;

namespace StringUtilsApp
{
    public class StringUtils
    {
        // Returns the reverse of a given string
        public string Reverse(string str)
        {
            if (str == null)
                return null;

            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        // Checks whether a string is a palindrome
        public bool IsPalindrome(string str)
        {
            if (str == null)
                return false;

            string reversed = Reverse(str);
            return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        // Converts a string to uppercase
        public string ToUpperCase(string str)
        {
            if (str == null)
                return null;

            return str.ToUpper();
        }
    }
}
