using System; 

class SimpleInterest
{
    static void Main()   // Entry point of the program
    {
        Console.Write("Enter Principal amount: ");
        double principal = Convert.ToDouble(Console.ReadLine()); // Read principal

        Console.Write("Enter Rate of interest (in %): ");
        double rate = Convert.ToDouble(Console.ReadLine()); // Read rate

        Console.Write("Enter Time (in years): ");
        double time = Convert.ToDouble(Console.ReadLine()); // Read time

        double simpleInterest = (principal * rate * time) / 100; // Simple Interest formula

        Console.WriteLine("Simple Interest = " + simpleInterest); // Display result
    }
}
