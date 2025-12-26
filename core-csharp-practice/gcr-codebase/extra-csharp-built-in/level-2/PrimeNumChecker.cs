using System;

class PrimeNumChecker
{
    // Checks if number is prime
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;   

        for (int i = 2; i <= number / 2; i++)       // looping and checking the condition
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine()!);

        Console.WriteLine(IsPrime(num) ? "Prime Number" : "Not a Prime Number");      //output
    }
}
