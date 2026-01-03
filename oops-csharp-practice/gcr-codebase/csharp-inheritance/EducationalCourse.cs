using System;

// Base class Course
class Course
{
    // Name of the course
    public string CourseName;

    // Duration of the course in months
    public int Duration;
}

// Derived class OnlineCourse inherits from Course
class OnlineCourse : Course
{
    // Platform where the course is hosted (e.g., Udemy, Coursera)
    public string Platform;

    // Indicates whether the course is recorded or live
    public bool IsRecorded;
}

// Derived class PaidOnlineCourse inherits from OnlineCourse
class PaidOnlineCourse : OnlineCourse
{
    // Course fee
    public double Fee;

    // Discount amount on the course
    public double Discount;
}

// Main class
class EducationalCourse
{
    static void Main()
    {
        // Create object of PaidOnlineCourse class
        PaidOnlineCourse c = new PaidOnlineCourse();

        // Take course name input from user
        Console.Write("Enter Course Name: ");
        c.CourseName = Console.ReadLine();

        // Take course duration input from user
        Console.Write("Enter Duration (months): ");
        c.Duration = int.Parse(Console.ReadLine());

        // Take platform name input from user
        Console.Write("Enter Platform: ");
        c.Platform = Console.ReadLine();

        // Take recorded status input from user
        Console.Write("Is Recorded (true/false): ");
        c.IsRecorded = bool.Parse(Console.ReadLine());

        // Take course fee input from user
        Console.Write("Enter Fee: ");
        c.Fee = double.Parse(Console.ReadLine());

        // Take discount input from user
        Console.Write("Enter Discount: ");
        c.Discount = double.Parse(Console.ReadLine());

        // Calculate and display final fee
        Console.WriteLine($"Final Fee: {c.Fee - c.Discount}");
    }
}
