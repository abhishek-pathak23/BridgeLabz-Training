using System;
using System.Reflection;

// 1. Define repeatable attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class BugReportAttribute : Attribute
{
    public string Description { get; set; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// 2. Class with methods
public class SoftwareModule
{
    // Apply attribute multiple times
    [BugReport("NullReferenceException occurs on line 23")]
    [BugReport("UI not updating correctly after button click")]
    public void ProcessData()
    {
        Console.WriteLine("Processing data...");
    }

    [BugReport("Incorrect calculation for edge cases")]
    public void CalculateResult()
    {
        Console.WriteLine("Calculating result...");
    }
}

class Program
{
    static void Main()
    {
        SoftwareModule module = new SoftwareModule();

        // Take method name from user
        Console.Write("Enter method name (ProcessData / CalculateResult): ");
        string methodName = Console.ReadLine();

        // Get MethodInfo
        MethodInfo method = typeof(SoftwareModule).GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Method not found!");
            return;
        }

        // Get all BugReport attributes
        object[] bugReports = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        if (bugReports.Length > 0)
        {
            Console.WriteLine($"\nBug Reports for method {methodName}:");
            foreach (BugReportAttribute bug in bugReports)
            {
                Console.WriteLine("- " + bug.Description);
            }

            // Optionally invoke the method
            method.Invoke(module, null);
        }
        else
        {
            Console.WriteLine("No bug reports found for this method.");
        }
    }
}
