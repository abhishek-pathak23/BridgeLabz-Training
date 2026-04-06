using System;

class Course
{
    // Instance variables
    public string courseName;
    public int duration; // in weeks
    public double fee;

    // Class variable shared by all courses
    public static string instituteName;

    // Constructor
    public Course(string name, int dur, double f)
    {
        courseName = name;
        duration = dur;
        fee = f;
    }

    // Instance method to display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {courseName}, Duration: {duration} weeks, Fee: {fee}, Institute: {instituteName}");
    }

    // Class method to update institute name for all courses
    public static void UpdateInstituteName(string name)
    {
        instituteName = name;
    }
}

class ProgramCourseManage
{
    static void Main()
    {
        Console.Write("Enter Institute Name: ");
        string institute = Console.ReadLine();
        Course.UpdateInstituteName(institute);

        Console.Write("How many courses do you want to add? ");
        int n = Convert.ToInt32(Console.ReadLine());
        Course[] courses = new Course[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Course {i + 1}:");
            Console.Write("Course Name: "); string name = Console.ReadLine();
            Console.Write("Duration (weeks): "); int dur = Convert.ToInt32(Console.ReadLine());
            Console.Write("Fee: "); double fee = Convert.ToDouble(Console.ReadLine());

            courses[i] = new Course(name, dur, fee);
        }

        Console.WriteLine("\n--- Courses ---");
        foreach (var c in courses)
        {
            c.DisplayCourseDetails();
        }
    }
}
