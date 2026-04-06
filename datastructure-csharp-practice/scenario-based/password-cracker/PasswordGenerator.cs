using System;

namespace PasswordCracker
{
    class PasswordGenerator : IPasswordOperation
    {
        private int length;                   // password length (encapsulated)
        private char[] chars = { 'a', 'b', 'c' };

        public PasswordGenerator(int length)
        {
            this.length = length;
        }

        public void Execute()
        {
            BuildPassword("", 0);
        }

        // Backtracking method to generate all combinations
        private void BuildPassword(string current, int index)
        {
            if (index == length)
            {
                Console.WriteLine(current);
                return;
            }

            foreach (char ch in chars)
            {
                BuildPassword(current + ch, index + 1);
            }
        }
    }
}
