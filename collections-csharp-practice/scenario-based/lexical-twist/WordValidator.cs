namespace LexicalTwist
{
    class WordValidator
    {
        public static void Validate(string word)
        {
            if (word.Trim().Contains(" "))
                throw new InvalidWordException(word + " is an invalid word");
        }
    }
}
