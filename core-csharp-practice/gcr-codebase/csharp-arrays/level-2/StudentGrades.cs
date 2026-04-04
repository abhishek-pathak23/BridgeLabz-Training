using System;

class StudentGrades
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        if (!int.TryParse(Console.ReadLine(), out int studentCount) || studentCount <= 0)
        {
            Console.WriteLine("Invalid input! Number of students must be positive.");
            return;
        }

        int[] physicsMarks = new int[studentCount];
        int[] chemistryMarks = new int[studentCount];
        int[] mathsMarks = new int[studentCount];
        double[] percentages = new double[studentCount];
        string[] grades = new string[studentCount];

        for (int i = 0; i < studentCount; i++)
        {
            int mark;

            // Physics marks
            while (true)
            {
                Console.Write($"Enter marks of student {i + 1} in Physics: ");
                if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0)
                {
                    physicsMarks[i] = mark;
                    break;
                }
                Console.WriteLine("Marks must be a non-negative number!");
            }

            // Chemistry marks
            while (true)
            {
                Console.Write($"Enter marks of student {i + 1} in Chemistry: ");
                if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0)
                {
                    chemistryMarks[i] = mark;
                    break;
                }
                Console.WriteLine("Marks must be a non-negative number!");
            }

            // Maths marks
            while (true)
            {
                Console.Write($"Enter marks of student {i + 1} in Maths: ");
                if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0)
                {
                    mathsMarks[i] = mark;
                    break;
                }
                Console.WriteLine("Marks must be a non-negative number!");
            }

            // Calculate percentage
            percentages[i] = (physicsMarks[i] + chemistryMarks[i] + mathsMarks[i]) / 3.0;

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
            Console.WriteLine($"{i + 1}\t{physicsMarks[i]}\t{chemistryMarks[i]}\t{mathsMarks[i]}\t{percentages[i]:F2}\t\t{grades[i]}");
        }
    }
}
