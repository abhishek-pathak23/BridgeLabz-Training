using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Sample class to test reflection
    class Employee
    {
        public int Id;
        private string Name;

        public Employee() { }

        public Employee(int id)
        {
            Id = id;
        }

        public void Work() { }
        private void CalculateSalary() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter class name: ");
            string className = Console.ReadLine();

            // Get the type using the class name
            Type type = Type.GetType("ReflectionDemo." + className);

            // Check if class exists
            if (type == null)
            {
                Console.WriteLine("Class not found");
                return;
            }

            // Display methods
            Console.WriteLine("\n--- Methods ---");
            foreach (MethodInfo method in type.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(method.Name);
            }

            // Display fields
            Console.WriteLine("\n--- Fields ---");
            foreach (FieldInfo field in type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(field.Name);
            }

            // Display constructors
            Console.WriteLine("\n--- Constructors ---");
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                Console.WriteLine(ctor.ToString());
            }
        }
    }
}
