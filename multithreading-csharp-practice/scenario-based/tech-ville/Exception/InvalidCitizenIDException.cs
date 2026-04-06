using System;

public class InvalidCitizenIDException : Exception
{
    public InvalidCitizenIDException(string message) : base(message) { }
}
