using System;

// Superclass Person
class Person
{
    // Common attributes
    public string Name;
    public int Age;
}

// Teacher class inherits from Person
class Teacher : Person
{
    // Teacher-specific attribute
    public string Subject;

    // Method to display teacher role
    public void DisplayRole()
    {
        Console.WriteLine("\nRole: Teacher");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Subject: {Subject}");
    }
}

// Student class inherits from Person
class Student : Person
{
    // Student-specific attribute
    public string Grade;

    // Method to display student role
    public void DisplayRole()
    {
        Console.WriteLine("\nRole: Student");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Grade: {Grade}");
    }
}

// Staff class inherits from Person
class Staff : Person
{
    // Staff-specific attribute
    public string Department;

    // Method to display staff role
    public void DisplayRole()
    {
        Console.WriteLine("\nRole: Staff");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Department: {Department}");
    }
}

// Main class
class SchoolSystem
{
    static void Main()
    {
        //  Teacher Input
        Teacher t = new Teacher();
        Console.Write("Enter Teacher Name: ");
        t.Name = Console.ReadLine();
        Console.Write("Enter Teacher Age: ");
        t.Age = int.Parse(Console.ReadLine());
        Console.Write("Enter Subject: ");
        t.Subject = Console.ReadLine();
        t.DisplayRole();

        //  Student Input
        Student s = new Student();
        Console.Write("\nEnter Student Name: ");
        s.Name = Console.ReadLine();
        Console.Write("Enter Student Age: ");
        s.Age = int.Parse(Console.ReadLine());
        Console.Write("Enter Grade: ");
        s.Grade = Console.ReadLine();
        s.DisplayRole();

        //  Staff Input
        Staff st = new Staff();
        Console.Write("\nEnter Staff Name: ");
        st.Name = Console.ReadLine();
        Console.Write("Enter Staff Age: ");
        st.Age = int.Parse(Console.ReadLine());
        Console.Write("Enter Department: ");
        st.Department = Console.ReadLine();
        st.DisplayRole();
    }
}
