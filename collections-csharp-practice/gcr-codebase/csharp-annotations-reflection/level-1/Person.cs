using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Person class with a private field
    class Person
    {
        private int age = 25;   // private field
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object of Person class
            Person person = new Person();

            // Get the type information of Person class
            Type type = typeof(Person);

            // Get private field 'age' using BindingFlags
            FieldInfo field = type.GetField(
                "age",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            // Take new age from user
            Console.Write("Enter new age: ");
            int newAge = Convert.ToInt32(Console.ReadLine());

            // Set new value to private field
            field.SetValue(person, newAge);

            // Get updated value from private field
            int updatedAge = (int)field.GetValue(person);

            // Display updated age
            Console.WriteLine("Updated Age is: " + updatedAge);
        }
    }
}
