using System;

class FindAge
{
    public static void Main(string[] args)
    {
        // Create a string variable 'name' 
        string name = "Harry";

        // Create an int variable 'birthYear' 
        int birthYear = 2000;

        // Create an int variable 'currentYear' and assign value 2024
        int currentYear = 2024;

        // Calculating age 
        int age = currentYear - birthYear;

        // Display the result
        Console.WriteLine($"{name}'s age in {currentYear} is {age}");
    }
}
