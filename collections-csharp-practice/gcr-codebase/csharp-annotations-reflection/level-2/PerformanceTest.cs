using System;
using System.Diagnostics;
using System.Reflection;

// 1. Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTimeAttribute : Attribute
{
    // No fields required, marker attribute
}

// 2. Class with methods
public class PerformanceTest
{
    [LogExecutionTime]
    public void QuickTask()
    {
        for (int i = 0; i < 100000; i++) { } // simulate work
    }

    [LogExecutionTime]
    public void LongerTask()
    {
        long sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
    }

    public void NoLogTask()
    {
        Console.WriteLine("This task is not logged.");
    }
}

// 3. Main program
class Program
{
    static void Main()
    {
        PerformanceTest test = new PerformanceTest();

        // Get all public instance methods declared in PerformanceTest
        MethodInfo[] methods = typeof(PerformanceTest).GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
        );

        foreach (MethodInfo method in methods)
        {
            // Check if LogExecutionTime attribute is applied
            var attr = (LogExecutionTimeAttribute)Attribute.GetCustomAttribute(method, typeof(LogExecutionTimeAttribute));

            if (attr != null)
            {
                // Measure execution time
                Stopwatch sw = Stopwatch.StartNew();
                method.Invoke(test, null); // execute method dynamically
                sw.Stop();

                Console.WriteLine($"Method: {method.Name}, Execution Time: {sw.ElapsedMilliseconds} ms\n");
            }
        }
    }
}
