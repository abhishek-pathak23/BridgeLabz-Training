using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

// 1. Define CacheResult attribute
[AttributeUsage(AttributeTargets.Method)]
public class CacheResultAttribute : Attribute
{
    // Marker attribute, no fields needed
}

// 2. Class with expensive method
public class MathOperations
{
    [CacheResult]
    public int ComputeFactorial(int n)
    {
        // Simulate expensive computation
        Thread.Sleep(500); 
        int result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;
        return result;
    }
}

// 3. Cache handler
public static class CacheHandler
{
    // Dictionary to store method results: key = method name + input, value = result
    private static Dictionary<string, object> cache = new Dictionary<string, object>();

    public static object InvokeWithCache(object obj, string methodName, params object[] parameters)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        if (method == null)
        {
            Console.WriteLine("Method not found!");
            return null;
        }

        // Check if method has CacheResult attribute
        var attr = (CacheResultAttribute)Attribute.GetCustomAttribute(method, typeof(CacheResultAttribute));

        // Create a cache key
        string key = methodName + "(" + string.Join(",", parameters) + ")";

        if (attr != null)
        {
            if (cache.ContainsKey(key))
            {
                Console.WriteLine("Returning cached result...");
                return cache[key];
            }
            else
            {
                var result = method.Invoke(obj, parameters);
                cache[key] = result; // store in cache
                return result;
            }
        }
        else
        {
            // No caching, just invoke
            return method.Invoke(obj, parameters);
        }
    }
}

// 4. Main program
class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();

        while (true)
        {
            Console.Write("Enter number to compute factorial (or 'exit' to quit): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit") break;

            if (int.TryParse(input, out int n))
            {
                object result = CacheHandler.InvokeWithCache(math, "ComputeFactorial", n);
                Console.WriteLine($"Factorial of {n} = {result}\n");
            }
            else
            {
                Console.WriteLine("Invalid input! Enter a number.\n");
            }
        }
    }
}
