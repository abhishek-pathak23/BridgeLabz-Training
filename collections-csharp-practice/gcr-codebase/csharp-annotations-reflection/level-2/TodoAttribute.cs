using System;
using System.Reflection;

// 1. Define custom Todo attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TodoAttribute : Attribute
{
    public string Task { get; set; }
    public string AssignedTo { get; set; }
    public string Priority { get; set; } = "MEDIUM"; // default priority

    // Constructor to set mandatory fields
    public TodoAttribute(string task, string assignedTo)
    {
        Task = task;
        AssignedTo = assignedTo;
    }

    // Optional constructor to set priority as well
    public TodoAttribute(string task, string assignedTo, string priority)
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// 2. Class with methods
public class ProjectModule
{
    [Todo("Implement login feature", "Aditya")]
    [Todo("Add input validation", "Rohan", "HIGH")]
    public void LoginModule()
    {
        Console.WriteLine("Executing LoginModule...");
    }

    [Todo("Create report generation", "Sita")]
    public void ReportModule()
    {
        Console.WriteLine("Executing ReportModule...");
    }

    public void OptionalModule()
    {
        Console.WriteLine("Executing OptionalModule...");
    }
}

// 3. Main program
class Program
{
    static void Main()
    {
        ProjectModule module = new ProjectModule();

        Console.Write("Enter a method name to check pending tasks (LoginModule / ReportModule / OptionalModule): ");
        string methodName = Console.ReadLine();

        MethodInfo method = typeof(ProjectModule).GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Method not found!");
            return;
        }

        // Get all Todo attributes applied to the method
        object[] todos = method.GetCustomAttributes(typeof(TodoAttribute), false);

        if (todos.Length > 0)
        {
            Console.WriteLine($"\nPending Tasks for {methodName}:");
            foreach (TodoAttribute todo in todos)
            {
                Console.WriteLine($"- Task: {todo.Task}, AssignedTo: {todo.AssignedTo}, Priority: {todo.Priority}");
            }

            // Optionally execute the method
            method.Invoke(module, null);
        }
        else
        {
            Console.WriteLine("No pending tasks for this method.");
        }
    }
}
