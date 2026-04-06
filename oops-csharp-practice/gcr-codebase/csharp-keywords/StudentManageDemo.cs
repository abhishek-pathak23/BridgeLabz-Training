using System;

class Student
{
    // Static variable common to all students
    // Stores the name of the university
    public static string UniversityName;

    // Private static counter to keep track of total students created
    private static int total = 0;

    // Public instance variable for student name
    public string Name;

    // Readonly variable: roll number is fixed once assigned
    public readonly int RollNumber;

    // Public instance variable for student grade
    public string Grade;

    // Constructor to initialize student details
    public Student(string name, int roll, string grade)
    {
        // Assign input values to class fields
        this.Name = name;
        this.RollNumber = roll;
        this.Grade = grade;

        // Increment total student count
        total++;
    }

    // Static method to display total number of students
    // Accessible without creating an object
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + total);
    }

    // Instance method to display student information
    public void ShowStudent()
    {
        Console.WriteLine(Name + " - Grade: " + Grade);
    }
}

class StudentManageDemo
{
    // Main method: starting point of the program
    static void Main()
    {
        // Set university name (shared by all students)
        Student.UniversityName = "GLA University";

        // Take student name as input
        Console.Write("Name: ");
        string n = Console.ReadLine();

        // Take roll number and convert it to integer
        Console.Write("Roll No: ");
        int r = int.Parse(Console.ReadLine());

        // Take grade as input
        Console.Write("Grade: ");
        string g = Console.ReadLine();

        // Create Student object and store it in object reference (upcasting)
        object s = new Student(n, r, g);

        // Check object type safely using 'is' operator
        if (s is Student)
        {
            // Downcast object to Student and call instance method
            ((Student)s).ShowStudent();
        }

        // Display total number of students created
        Student.DisplayTotalStudents();
    }
}
