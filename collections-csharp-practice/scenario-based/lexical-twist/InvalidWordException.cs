using System;

namespace LexicalTwist
{
    class InvalidWordException : Exception
    {
        public InvalidWordException(string message) : base(message)
        {
        }
    }
}
