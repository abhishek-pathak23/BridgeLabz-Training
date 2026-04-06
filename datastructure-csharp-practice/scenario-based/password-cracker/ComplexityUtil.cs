using System;

namespace PasswordCracker
{
    // Utility class for complexity information
    static class ComplexityUtil
    {
        public static void Show()
        {
            Console.WriteLine("\n--- Algorithm Complexity ---");

            // k = character set size, n = password length
            Console.WriteLine("k = size of character set");
            Console.WriteLine("n = length of password");

            Console.WriteLine("Time Complexity  : O(k^n)");
            Console.WriteLine("Space Complexity : O(n)");
        }
    }
}
