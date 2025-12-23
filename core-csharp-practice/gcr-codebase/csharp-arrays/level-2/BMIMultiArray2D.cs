using System;

class BMIMultiArray2D
{
    static void Main()
    {
        Console.Write("Enter number of persons: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid input! Number of persons must be positive.");
            return;
        }

        double[,] personData = new double[n, 3]; // 0: weight, 1: height, 2: BMI
        string[] weightStatus = new string[n];

        for (int i = 0; i < n; i++)
        {
            double w, h;

            // Input weight
            while (true)
            {
                Console.Write($"Enter weight (kg) of person {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out w) && w > 0)
                    break;
                Console.WriteLine("Weight must be a positive number!");
            }

            // Input height
            while (true)
            {
                Console.Write($"Enter height (m) of person {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out h) && h > 0)
                    break;
                Console.WriteLine("Height must be a positive number!");
            }

            // Store weight and height
            personData[i, 0] = w;
            personData[i, 1] = h;

            // Calculate BMI
            personData[i, 2] = w / (h * h);

            // Determine weight status
            double bmi = personData[i, 2];
            if (bmi < 18.5) weightStatus[i] = "Underweight";
            else if (bmi < 25) weightStatus[i] = "Normal weight";
            else if (bmi < 30) weightStatus[i] = "Overweight";
            else weightStatus[i] = "Obese";
        }

        // Display results
        Console.WriteLine("\nPerson\tWeight(kg)\tHeight(m)\tBMI\tStatus");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i + 1}\t{personData[i, 0]:F2}\t\t{personData[i, 1]:F2}\t\t{personData[i, 2]:F2}\t{weightStatus[i]}");
        }
    }
}
