using System;
using System.Diagnostics;
using System.Reflection;

// Sample class to test method execution
public class StringProcessor
{
    public void ConcatenateStrings()
    {
        string result = "";
        for (int i = 0; i < 100000; i++)
        {
            result += "a"; // simulate work
        }
    }

    public void ReverseString()
    {
        string str = "ReflectionIsFun";
        for (int i = 0; i < 10000; i++)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);
        }
    }

    public void WaitForHalfSecond()
    {
        System.Threading.Thread.Sleep(500); // simulate delay
    }
}

class Program
{
    static void Main()
    {
        // Take class name from user
        Console.Write("Enter class name (e.g., StringProcessor): ");
        string className = Console.ReadLine();

        // Get Type
        Type type = Type.GetType(className) ?? Type.GetType("ReflectionDemo." + className);

        if (type == null)
        {
            Console.WriteLine("Class not found");
            return;
        }

        // Create instance dynamically
        object obj = Activator.CreateInstance(type);

        // Get all public instance methods (declared only in this class)
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Console.WriteLine($"\nMeasuring execution time of methods in {className}:");

        foreach (MethodInfo method in methods)
        {
            Stopwatch sw = Stopwatch.StartNew();   // Start timer
            method.Invoke(obj, null);             // Invoke method dynamically
            sw.Stop();                             // Stop timer

            Console.WriteLine($"Method: {method.Name}, Execution Time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
