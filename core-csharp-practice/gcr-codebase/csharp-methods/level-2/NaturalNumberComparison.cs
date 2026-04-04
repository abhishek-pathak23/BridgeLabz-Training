using System;

class NaturalNumberComparison
{
    // Recursive sum
    public static int RecursiveSum(int n)
    {
        if (n == 0) return 0;
        return n + RecursiveSum(n - 1);
    }

    // Formula sum
    public static int FormulaSum(int n)
    {
        return n * (n + 1) / 2;
    }

    static void Main()
    {
        Console.Write("Enter a natural number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n <= 0) return;

        int recursiveResult = RecursiveSum(n); // recursive calculation
        int formulaResult = FormulaSum(n);     // formula calculation

        Console.WriteLine("Recursive Sum: " + recursiveResult);
        Console.WriteLine("Formula Sum: " + formulaResult);
        Console.WriteLine("Results Match: " + (recursiveResult == formulaResult));
    }
}
