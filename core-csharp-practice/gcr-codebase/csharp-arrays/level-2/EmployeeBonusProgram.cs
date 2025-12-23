using System;

class EmployeeBonusProgram
{
    static void Main()
    {
        int employeeCount = 10;
        double[] baseSalary = new double[employeeCount];
        double[] serviceYears = new double[employeeCount];
        double[] bonusAmount = new double[employeeCount];
        double[] updatedSalary = new double[employeeCount];

        double totalBaseSalary = 0;
        double totalBonusGiven = 0;
        double totalUpdatedSalary = 0;

        // Input: Collect salary and years of service for each employee
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"Enter the salary for employee #{i + 1}:");
            if (!double.TryParse(Console.ReadLine(), out double salary) || salary < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
                i--; // Repeat this iteration
                continue;
            }
            baseSalary[i] = salary;

            Console.WriteLine($"Enter the years of service for employee #{i + 1}:");
            if (!double.TryParse(Console.ReadLine(), out double years) || years < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
                i--; // Repeat this iteration
                continue;
            }
            serviceYears[i] = years;
        }

        // Processing: Calculate bonus and updated salary
        for (int i = 0; i < employeeCount; i++)
        {
            bonusAmount[i] = (serviceYears[i] > 5) ? baseSalary[i] * 0.05 : baseSalary[i] * 0.02;
            updatedSalary[i] = baseSalary[i] + bonusAmount[i];

            totalBaseSalary += baseSalary[i];
            totalBonusGiven += bonusAmount[i];
            totalUpdatedSalary += updatedSalary[i];
        }

        // Output: Display results in a tabular format
        Console.WriteLine("\nEmployee\tBase Salary\tBonus\t\tUpdated Salary");
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"{i + 1}\t\t{baseSalary[i]:F2}\t\t{bonusAmount[i]:F2}\t\t{updatedSalary[i]:F2}");
        }

        Console.WriteLine($"\nTotal Base Salary: {totalBaseSalary:F2}");
        Console.WriteLine($"Total Bonus: {totalBonusGiven:F2}");
        Console.WriteLine($"Total Updated Salary: {totalUpdatedSalary:F2}");
    }
}
