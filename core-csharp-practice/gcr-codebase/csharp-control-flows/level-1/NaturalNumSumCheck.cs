using System;

class NaturalNumSumCheck
{
    static void Main(String[] args)
    {
	//taking the number as input
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
    //checking if no is natural or not
        if (n > 0)
        {
		//calculating the sum using formula
            int sum = n * (n + 1) / 2;
            Console.WriteLine($"The sum of {n} natural numbers is {sum}");
        }
        else
        {
            Console.WriteLine($"The number {n} is not a natural number");
        }
    }
}
