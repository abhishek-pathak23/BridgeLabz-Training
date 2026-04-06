using System;

public class ServiceNotAvailableException : Exception
{
    public ServiceNotAvailableException(string message) : base(message) { }
}
