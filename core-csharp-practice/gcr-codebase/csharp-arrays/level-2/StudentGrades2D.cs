using System;

class StudentGrades2D
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        if (!int.TryParse(Console.ReadLine(), out int studentCount) || studentCount <= 0)
        {
            Console.WriteLine("Invalid input! Number of students must be positive.");
            return;
        }

        int[,] marks = new int[studentCount, 3]; // 0: Physics, 1: Chemistry, 2: Maths
        double[] percentages = new double[studentCount];
        string[] grades = new string[studentCount];

        for (int i = 0; i < studentCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string subject = j == 0 ? "Physics" : j == 1 ? "Chemistry" : "Maths";
                int mark;

                while (true)
                {
                    Console.Write($"Enter marks of student {i + 1} in {subject}: ");
                    if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0)
                    {
                        marks[i, j] = mark;
                        break;
                    }
                    Console.WriteLine("Marks must be a non-negative number!");
                }
            }

            // Calculate percentage
            percentages[i] = (marks[i, 0] + marks[i, 1] + marks[i, 2]) / 3.0;

            // Assign grade
            if (percentages[i] >= 90) grades[i] = "A";
            else if (percentages[i] >= 75) grades[i] = "B";
            else if (percentages[i] >= 50) grades[i] = "C";
            else grades[i] = "D";
        }

        // Display results
        Console.WriteLine("\nStudent\tPhysics\tChemistry\tMaths\tPercentage\tGrade");
        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine($"{i + 1}\t{marks[i, 0]}\t{marks[i, 1]}\t{marks[i, 2]}\t{percentages[i]:F2}\t\t{grades[i]}");
        }
    }
}
