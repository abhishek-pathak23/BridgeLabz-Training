using System;
using System.Reflection;

// 1. Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class TaskInfoAttribute : Attribute
{
    public string Priority { get; set; }
    public string AssignedTo { get; set; }

    // Constructor to initialize fields
    public TaskInfoAttribute(string priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// 2. Class with methods
public class TaskManager
{
    [TaskInfo("High", "Aditya")]
    public void CompleteTask()
    {
        Console.WriteLine("Task is completed.");
    }

    [TaskInfo("Low", "Rohan")]
    public void ReviewTask()
    {
        Console.WriteLine("Task is reviewed.");
    }
}

class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();

        // Take method name from user
        Console.Write("Enter method name (CompleteTask / ReviewTask): ");
        string methodName = Console.ReadLine();

        // Get method info using Reflection
        MethodInfo method = typeof(TaskManager).GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Method not found!");
            return;
        }

        // Retrieve custom attribute
        TaskInfoAttribute attr = (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

        if (attr != null)
        {
            Console.WriteLine($"\nTask Details for {methodName}:");
            Console.WriteLine("Priority: " + attr.Priority);
            Console.WriteLine("Assigned To: " + attr.AssignedTo);

            // Optionally invoke the method
            method.Invoke(manager, null);
        }
        else
        {
            Console.WriteLine("No TaskInfo attribute applied to this method.");
        }
    }
}
