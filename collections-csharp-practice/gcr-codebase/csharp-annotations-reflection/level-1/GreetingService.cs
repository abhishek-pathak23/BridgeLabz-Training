using System;

// Interface
public interface IGreeting
{
    void SayHello(string name);
}

// Real class
public class GreetingService : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine("Hello, " + name);
    }
}

// Manual proxy (no DispatchProxy, cross-platform)
public class LoggingGreetingProxy : IGreeting
{
    private readonly IGreeting target;

    public LoggingGreetingProxy(IGreeting real)
    {
        target = real;
    }

    public void SayHello(string name)
    {
        // Log method call
        Console.WriteLine("Calling Method: SayHello");

        // Call actual method
        target.SayHello(name);
    }
}

class Program
{
    static void Main()
    {
        IGreeting real = new GreetingService();
        IGreeting proxy = new LoggingGreetingProxy(real);

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        proxy.SayHello(name);
    }
}
