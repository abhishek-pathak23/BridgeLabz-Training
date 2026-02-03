using System.Text.RegularExpressions;

namespace CleanseTool.Utils
{
    public static class Validator
    {
        public static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6)
                return false;

            return Regex.IsMatch(input, "^[A-Za-z]+$");
        }
    }
}
