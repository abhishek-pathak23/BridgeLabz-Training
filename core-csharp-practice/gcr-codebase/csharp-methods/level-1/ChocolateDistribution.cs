using System;

class ChocolateDistribution
{
    // Calculates chocolates per child and leftovers
    public static int[] CalculateDistribution(int totalChocolates, int totalChildren)
    {
        int chocolatesPerChild = totalChocolates / totalChildren;
        int leftoverChocolates = totalChocolates % totalChildren;

        return new int[] { chocolatesPerChild, leftoverChocolates };
    }

    static void Main()
    {
        Console.Write("Enter total chocolates: ");
        int totalChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter total children: ");
        int totalChildren = Convert.ToInt32(Console.ReadLine());

        if (totalChildren <= 0)
        {
            Console.WriteLine("Number of children must be greater than zero.");
            return;
        }

        int[] distributionResult = CalculateDistribution(totalChocolates, totalChildren);

        Console.WriteLine("Each child gets: " + distributionResult[0]);
        Console.WriteLine("Remaining chocolates: " + distributionResult[1]);
    }
}
