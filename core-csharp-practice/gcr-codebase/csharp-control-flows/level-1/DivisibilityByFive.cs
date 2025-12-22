using System;

class DivisibilityByFive
{
    static void Main(String[] args)
    {
	//take input value from user
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
//checking number is divisible by 5 or not
        
        Console.WriteLine($"Is the number {num} divisible by 5? {(num % 5) == 0}");
    }
}
