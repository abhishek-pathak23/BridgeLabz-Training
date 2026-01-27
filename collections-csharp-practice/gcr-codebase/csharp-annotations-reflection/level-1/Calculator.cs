using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Calculator class
    class Calculator
    {
        // private method
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object of Calculator class
            Calculator calculator = new Calculator();

            // Get type information of Calculator class
            Type type = typeof(Calculator);

            // Get private method 'Multiply'
            MethodInfo methodInfo = type.GetMethod(
                "Multiply",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            // Take input from user
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Invoke private method using Reflection
            object result = methodInfo.Invoke(
                calculator,
                new object[] { num1, num2 }
            );

            // Display result
            Console.WriteLine("Multiplication Result: " + result);
        }
    }
}
