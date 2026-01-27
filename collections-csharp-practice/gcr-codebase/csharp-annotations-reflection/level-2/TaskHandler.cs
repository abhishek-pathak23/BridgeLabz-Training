using System;
using System.Reflection;

// 1. Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class ImportantMethodAttribute : Attribute
{
    public string Level { get; set; } = "HIGH"; // Default value

    // Optional constructor
    public ImportantMethodAttribute() { }

    public ImportantMethodAttribute(string level)
    {
        Level = level;
    }
}

// 2. Class with methods
public class TaskHandler
{
    [ImportantMethod] // Default HIGH
    public void CriticalTask()
    {
        Console.WriteLine("Executing CriticalTask...");
    }

    [ImportantMethod("MEDIUM")] // Custom level
    public void RegularTask()
    {
        Console.WriteLine("Executing RegularTask...");
    }

    public void OptionalTask()
    {
        Console.WriteLine("Executing OptionalTask...");
    }
}

class Program
{
    static void Main()
    {
        TaskHandler handler = new TaskHandler();

        // Get all methods of TaskHandler
        MethodInfo[] methods = typeof(TaskHandler).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Console.WriteLine("Important Methods in TaskHandler:");

        // Check each method for ImportantMethodAttribute
        foreach (var method in methods)
        {
            var attr = (ImportantMethodAttribute)Attribute.GetCustomAttribute(method, typeof(ImportantMethodAttribute));
            if (attr != null)
            {
                Console.WriteLine($"Method: {method.Name}, Level: {attr.Level}");
                // Optionally invoke the method
                method.Invoke(handler, null);
            }
        }
    }
}
