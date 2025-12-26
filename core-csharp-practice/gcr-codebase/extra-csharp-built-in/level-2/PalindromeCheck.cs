using System;

class PalindromeCheck
{
    // Checks palindrome using two pointers
    static bool IsPalindrome(string text)
    {
        int left = 0;
        int right = text.Length - 1;

        while (left < right)                            // Checking the condition
        {
            if (text[left] != text[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;

        Console.WriteLine(IsPalindrome(input) ? "Palindrome" : "Not a Palindrome"); //Final Result
    }
}
