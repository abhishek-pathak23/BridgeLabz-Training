using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Class with multiple public methods
    class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object of MathOperations class
            MathOperations math = new MathOperations();

            // Get type information
            Type type = typeof(MathOperations);

            // Take method name from user
            Console.Write("Enter method name (Add / Subtract / Multiply): ");
            string methodName = Console.ReadLine();

            // Take numbers from user
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Get method info dynamically
            MethodInfo methodInfo = type.GetMethod(methodName);

            // Check if method exists
            if (methodInfo == null)
            {
                Console.WriteLine("Invalid method name");
                return;
            }

            // Invoke method dynamically
            object result = methodInfo.Invoke(
                math,
                new object[] { num1, num2 }
            );

            // Display result
            Console.WriteLine("Result: " + result);
        }
    }
}
