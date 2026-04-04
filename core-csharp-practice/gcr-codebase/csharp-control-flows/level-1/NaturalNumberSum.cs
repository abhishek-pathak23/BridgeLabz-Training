using System;

class NaturalNumberSum
{
    static void Main()
    {
	//enter the number from user
        Console.Write("Enter a natural number: ");
        int n = Convert.ToInt32(Console.ReadLine());
//calculating the sum
        if (n > 0)
        {
            int sum = 0;
            int i = 1;

            while (i <= n)
            {
                sum += i;
                i++;
            }
//calculating the sum using formula
            int formulaSum = n * (n + 1) / 2;

            Console.WriteLine($"While loop sum: {sum}");
            Console.WriteLine($"Formula sum: {formulaSum}");
            Console.WriteLine(sum == formulaSum ? "Results are correct" : "Results mismatch");
        }
    }
}
