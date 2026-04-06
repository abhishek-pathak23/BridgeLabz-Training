using System;

public class InvalidZoneException : Exception
{
    public InvalidZoneException(string message) : base(message) { }
}
