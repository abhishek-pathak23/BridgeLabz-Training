using System;

public class DuplicateCitizenException : Exception
{
    public DuplicateCitizenException(string message) : base(message) { }
}
