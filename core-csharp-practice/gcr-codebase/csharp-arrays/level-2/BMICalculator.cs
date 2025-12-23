using System;

class BMICalculator
{
    static void Main()
    {
        Console.Write("Enter number of persons: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid input! Number of persons must be positive.");
            return;
        }

        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
        {
            // Input weight
            while (true)
            {
                Console.Write($"Enter weight (kg) of person {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double w) && w > 0)
                {
                    weight[i] = w;
                    break;
                }
                Console.WriteLine("Weight must be a positive number!");
            }

            // Input height
            while (true)
            {
                Console.Write($"Enter height (m) of person {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double h) && h > 0)
                {
                    height[i] = h;
                    break;
                }
                Console.WriteLine("Height must be a positive number!");
            }

            // Calculate BMI
            bmi[i] = weight[i] / (height[i] * height[i]);

            // Determine weight status
            if (bmi[i] < 18.5) status[i] = "Underweight";
            else if (bmi[i] < 25) status[i] = "Normal weight";
            else if (bmi[i] < 30) status[i] = "Overweight";
            else status[i] = "Obese";
        }

        // Display results
        Console.WriteLine("\nPerson\tWeight(kg)\tHeight(m)\tBMI\tStatus");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i + 1}\t{weight[i]:F2}\t\t{height[i]:F2}\t\t{bmi[i]:F2}\t{status[i]}");
        }
    }
}
