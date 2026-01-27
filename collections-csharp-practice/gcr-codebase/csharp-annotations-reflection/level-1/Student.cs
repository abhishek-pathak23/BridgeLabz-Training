using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Student class
    class Student
    {
        public string Name;
        public int RollNumber;

        // Default constructor
        public Student()
        {
            Name = "Not Set";
            RollNumber = 0;
        }

        // Method to display student details
        public void ShowDetails()
        {
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Roll Number: " + RollNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get type information of Student class
            Type type = typeof(Student);

            // Create object dynamically without using 'new'
            object obj = Activator.CreateInstance(type);

            // Get fields using Reflection
            FieldInfo nameField = type.GetField("Name");
            FieldInfo rollField = type.GetField("RollNumber");

            // Take input from user
            Console.Write("Enter student name: ");
            nameField.SetValue(obj, Console.ReadLine());

            Console.Write("Enter roll number: ");
            rollField.SetValue(obj, Convert.ToInt32(Console.ReadLine()));

            // Call method dynamically
            MethodInfo method = type.GetMethod("ShowDetails");
            method.Invoke(obj, null);
        }
    }
}
