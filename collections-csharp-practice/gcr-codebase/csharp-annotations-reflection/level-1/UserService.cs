using System;
using System.Reflection;

// 1. Custom Inject attribute
[AttributeUsage(AttributeTargets.Field)]
public class InjectAttribute : Attribute { }

// 2. Dependency class
public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine("[LOG] " + message);
    }
}

// 3. Service class that depends on Logger
public class UserService
{
    [Inject] // Mark dependency
    private Logger _logger;

    public void CreateUser(string username)
    {
        _logger.Log($"Creating user: {username}");
        Console.WriteLine("User created: " + username);
    }
}

// 4. Simple DI Container
public class DIContainer
{
    public static T Resolve<T>() where T : new()
    {
        // Create object of requested type
        T obj = new T();

        // Get all fields of the object
        FieldInfo[] fields = typeof(T).GetFields(
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        foreach (var field in fields)
        {
            // Check if field has [Inject] attribute
            if (Attribute.IsDefined(field, typeof(InjectAttribute)))
            {
                // Create instance of field type
                object dependency = Activator.CreateInstance(field.FieldType);

                // Inject dependency into field
                field.SetValue(obj, dependency);
            }
        }

        return obj;
    }
}

// 5. Main Program
class Program
{
    static void Main(string[] args)
    {
        // Resolve UserService with dependencies
        UserService userService = DIContainer.Resolve<UserService>();

        // Take input from user
        Console.Write("Enter username to create: ");
        string username = Console.ReadLine();

        // Use service
        userService.CreateUser(username);
    }
}
