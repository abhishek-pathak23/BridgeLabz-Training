using System;

class SmallestNumCheck
{
    static void Main(String[] args)
    {
		//taking fist number as input from user
        Console.Write("Enter first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());
//taking second number as input from user
        Console.Write("Enter second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());
//taking third number as input from user
        Console.Write("Enter third number: ");
        int number3 = Convert.ToInt32(Console.ReadLine());
//chekcing the first nunmber is smallles or not
        Console.WriteLine($"Is the first number the smallest? {number1 < number2 && number1 < number3}");
    }
}
