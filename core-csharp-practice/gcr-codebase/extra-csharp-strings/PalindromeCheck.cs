using System;

class PalindromeCheck
{
    // Method checks palindrome using index comparison
    static bool IsPalindrome(string text)
    {
        int start = 0;
        int end = text.Length - 1;

        while (start < end)
        {
            if (text[start] != text[end])
                return false;
            start++;
            end--;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;                         // Taking input

        Console.WriteLine("Is Palindrome: " + IsPalindrome(input)); //Output
    } 
}
