using System;

class DivideChocolates
{
    public static void Main(string[] args)
    {
        // Input total chocolates and number of children
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        // Calculate chocolates per child and remaining chocolates
        int chocolatesPerChild = numberOfChocolates / numberOfChildren;
        int remainingChocolates = numberOfChocolates % numberOfChildren;

        // Display results
        Console.WriteLine(
            $"The number of chocolates each child gets is {chocolatesPerChild} and the number of remaining chocolates is {remainingChocolates}"
        );
    }
}
