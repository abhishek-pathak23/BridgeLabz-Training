using System;

public class InvalidFlightException : Exception
{
	public InvalidFlightException(string message) : base(message)
	{
	}
}
