using System;

class FactorialFindForLoop
{
    static void Main(String[] args)
    {
//take number as input from user
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
//checking the number is greater than 0
        if (num > 0)
        {
            long fact = 1;
            int i = 1;
            for(i =1;i<= num;i++)
            {
                fact *= i;
            }

            Console.WriteLine($"Factorial is: {fact}");
        }
    }
}
