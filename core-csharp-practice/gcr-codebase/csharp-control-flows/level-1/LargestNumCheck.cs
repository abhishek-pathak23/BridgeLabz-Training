using System;

class LargestNumCheck
{
    static void Main(String[] args)
    {//taking fist number as input from user
        Console.Write("Enter first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());
//taking second number as input from user
        Console.Write("Enter second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());
//taking third number as input from user
        Console.Write("Enter third number: ");
        int number3= Convert.ToInt32(Console.ReadLine());
//cheking the largest number
        Console.WriteLine($"Is the first number the largest? {number1 > number2 && number1 > number3}");
        Console.WriteLine($"Is the second number the largest? {number2 > number1 && number2 > number3}");
        Console.WriteLine($"Is the third number the largest? {number3> number1 && number3 > number2}");
    }
}
