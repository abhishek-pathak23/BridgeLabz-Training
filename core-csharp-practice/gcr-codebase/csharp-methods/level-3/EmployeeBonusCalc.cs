using System;

class EmployeeBonusCalc
{
    // Generate random salary and years of service
    public static void GenerateEmployeeData(double[,] data)
    {
        Random rand = new Random();
        for (int i = 0; i < data.GetLength(0); i++)
        {
            data[i, 0] = rand.Next(10000, 100000); // salary
            data[i, 1] = rand.Next(1, 20);         // years
        }
    }

    // Calculate bonus and new salary
    public static void CalculateBonus(double[,] data, double[,] result)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double bonus = data[i, 1] > 5 ? data[i, 0] * 0.05 : data[i, 0] * 0.02;
            result[i, 0] = data[i, 0];        // old salary
            result[i, 1] = bonus;             // bonus
            result[i, 2] = data[i, 0] + bonus; // new salary
        }
    }

    // Display table
    public static void DisplayBonus(double[,] result)
    {
        Console.WriteLine("OldSalary\tBonus\tNewSalary");
        for (int i = 0; i < result.GetLength(0); i++)
            Console.WriteLine($"{result[i, 0]}\t{result[i, 1]}\t{result[i, 2]}");
    }

    static void Main()
    {
        double[,] data = new double[10, 2]; // salary, years
        double[,] result = new double[10, 3]; // old, bonus, new

        GenerateEmployeeData(data);
        CalculateBonus(data, result);
        DisplayBonus(result);
    }
}
