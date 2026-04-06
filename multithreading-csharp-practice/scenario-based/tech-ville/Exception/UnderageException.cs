using System;

public class UnderageException : Exception
{
    public UnderageException(string message) : base(message) { }
}
