using System;
using CleanseTool.Utils;

namespace CleanseTool.Services
{
    public class StringProcessor
    {
        public string CleanseAndInvert(string input)
        {
            if (!Validator.IsValid(input))
                return string.Empty;

            input = input.ToLower();
            string filtered = "";

            foreach (char c in input)
            {
                if ((int)c % 2 != 0)
                    filtered += c;
            }

            char[] arr = filtered.ToCharArray();
            Array.Reverse(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                    arr[i] = char.ToUpper(arr[i]);
            }

            return new string(arr);
        }
    }
}
