using System;

class ExceptionPropagate
{
    static void Method1()
    {
        int a = 10;
        int b = 0;
        int x = a / b; // Division by zero happens at runtime
    }

    static void Method2()
    {
        Method1();
    }

    static void Main()
    {
        try
        {
            Method2();
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }
}
