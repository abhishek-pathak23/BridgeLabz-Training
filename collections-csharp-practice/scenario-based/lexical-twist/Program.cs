using System;

namespace LexicalTwist
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the first word");
                string word1 = Console.ReadLine();

                WordValidator.Validate(word1);

                Console.WriteLine("Enter the second word");
                string word2 = Console.ReadLine();

                WordValidator.Validate(word2);

                LexicalService service = new LexicalService();
                service.ProcessWords(word1, word2);
            }
            catch (InvalidWordException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error occurred");
            }
        }
    }
}
