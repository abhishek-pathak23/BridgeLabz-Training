using System; 
class AverageOfThreeNum
{
    static void Main() 
    {
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine()); // Read first number

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine()); // Read second number

        Console.Write("Enter third number: ");
        double num3 = Convert.ToDouble(Console.ReadLine()); // Read third number

        double average = (num1 + num2 + num3) / 3; // Calculate average

        Console.WriteLine("Average of three numbers = " + average); // Display result
    }
}
