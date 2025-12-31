using System;

class MathFnctions
{
    // Factorial
    public static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++) //loop to calculate factorial
            fact = fact * i;  //     fact = fact * i;

        return fact;
    }

    // Prime check
    public static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i < n; i++) //loop to check if number is prime
        {
            if (n % i == 0) //if number is divisible by any number other than 1 and itself, it is not prime
                return false;
        }
        return true;
    }

    // GCD
    public static int GCD(int a, int b)
    {
        while (a != b) //loop to find GCD
        {
            if (a > b) //if a is greater than b, we subtract b from a
                a = a - b; 
            else
                b = b - a; //if b is greater than a, we subtract a from b
        }
        return a;
    }

    // Fibonacci
    public static int Fibonacci(int n)
    {
        if (n == 0)
            return 0;

        int a = 0, b = 1, c = 0; //initializing variables a, b, c
        for (int i = 2; i <= n; i++) //loop to calculate fibonacci
        {
            c = a + b;
            a = b;
            b = c;
        }
        return b;
    }
}

class MathsApp
{
    static void Main()
    {
        Console.WriteLine("1. Factorial"); //chose the function
        Console.WriteLine("2. Prime");
        Console.WriteLine("3. GCD");
        Console.WriteLine("4. Fibonacci");

        Console.Write("Enter choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice) //switch case to call the function
        {
            case 1:
                Console.Write("Enter number: ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n < 0)
                    Console.WriteLine("Not possible");
                else 
                    Console.WriteLine("Factorial = " + MathFnctions.Factorial(n)); //we use mathFnctions bcz  all methods are static and  we need to use class name to call the method
                break;

            case 2:
                Console.Write("Enter number: ");
                int p = Convert.ToInt32(Console.ReadLine());
                if (MathFnctions.IsPrime(p))
                    Console.WriteLine("Prime Number");
                else
                    Console.WriteLine("Not Prime");
                break;

            case 3:
                Console.Write("Enter two numbers: ");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("GCD = " + MathFnctions.GCD(a, b));
                break;

            case 4:
                Console.Write("Enter number: ");
                int f = Convert.ToInt32(Console.ReadLine());
                if (f < 0)
                    Console.WriteLine("Not possible");
                else
                    Console.WriteLine("Fibonacci = " + MathFnctions.Fibonacci(f));
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}