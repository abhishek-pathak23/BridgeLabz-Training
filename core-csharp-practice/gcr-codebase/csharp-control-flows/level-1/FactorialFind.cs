using System;

class FactorialFind
{
    static void Main(String[] args)
    {
//take number as input form user
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
//checking if the number is greater than 0
        if (num > 0)
        {
            long fact = 1;
            int i = 1;
            while (i <= num)
            {
                fact *= i;
                i++;
            }

            Console.WriteLine($"Factorial is: {fact}");
        }
    }
}
