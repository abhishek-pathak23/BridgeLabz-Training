using System;

namespace PasswordCracker
{
    class PasswordMatcher : IPasswordOperation
    {
        private string secret;              // stored password
        private bool isMatched = false;
        private char[] chars = { 'a', 'b', 'c' };

        public PasswordMatcher(string secret)
        {
            this.secret = secret;
        }

        public void Execute()
        {
            Check("", 0);

            if (!isMatched)
                Console.WriteLine("Password not found");
        }

        // Backtracking method with early stopping
        private void Check(string attempt, int index)
        {
            if (isMatched) return;

            if (index == secret.Length)
            {
                Console.WriteLine("Trying: " + attempt);

                if (attempt == secret)
                {
                    Console.WriteLine("Password matched!");
                    isMatched = true;
                }
                return;
            }

            foreach (char ch in chars)
            {
                Check(attempt + ch, index + 1);
            }
        }
    }
}
