using System;

class Student
{
    // Can be accessed from anywhere
    public int rollNumber;

    // Can be accessed only in this class and its child classes
    protected string name;

    // Can be accessed only inside this class
    private double cgpa;

    // Constructor to initialize roll number and name
    public Student(int roll, string studentName)
    {
        rollNumber = roll;
        name = studentName;
    }

    // Method to assign CGPA
    public void SetCGPA(double value)
    {
        cgpa = value;
    }

    // Method to return CGPA
    public double GetCGPA()
    {
        return cgpa;
    }
}

// Child class
class PostgraduateStudent : Student
{
    // Calling parent constructor using base keyword
    public PostgraduateStudent(int roll, string studentName)
        : base(roll, studentName)
    {
    }

    // Display student details
    public void DisplayDetails()
    {
        Console.WriteLine("\nStudent Details");
        Console.WriteLine("Roll Number : " + rollNumber);
        Console.WriteLine("Name        : " + name); // protected member
    }
}

class UniversityManagement
{
    static void Main()
    {
        // Taking input from user
        Console.Write("Enter Roll Number: ");
        int roll = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter CGPA: ");
        double cgpa = double.Parse(Console.ReadLine());

        // Creating object of child class
        PostgraduateStudent student = new PostgraduateStudent(roll, name);

        // Setting CGPA using public method
        student.SetCGPA(cgpa);

        // Displaying data
        student.DisplayDetails();
        Console.WriteLine("CGPA        : " + student.GetCGPA());
    }
}
