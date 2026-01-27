using System;
using System.Reflection;

// 1. Define RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method)]
public class RoleAllowedAttribute : Attribute
{
    public string Role { get; set; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

// 2. Class with methods
public class AdminModule
{
    [RoleAllowed("ADMIN")]
    public void DeleteUser()
    {
        Console.WriteLine("User deleted successfully!");
    }

    [RoleAllowed("ADMIN")]
    public void ModifySettings()
    {
        Console.WriteLine("Settings modified successfully!");
    }

    public void ViewDashboard()
    {
        Console.WriteLine("Dashboard viewed by any user.");
    }
}

// 3. Main program
class Program
{
    static void Main()
    {
        AdminModule module = new AdminModule();

        // Simulate user role
        Console.Write("Enter your role (ADMIN / USER): ");
        string userRole = Console.ReadLine().ToUpper();

        // Take method name to execute
        Console.Write("Enter method to execute (DeleteUser / ModifySettings / ViewDashboard): ");
        string methodName = Console.ReadLine();

        MethodInfo method = typeof(AdminModule).GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Method not found!");
            return;
        }

        // Check if method has RoleAllowed attribute
        var attr = (RoleAllowedAttribute)Attribute.GetCustomAttribute(method, typeof(RoleAllowedAttribute));

        if (attr != null)
        {
            // Method has role restriction
            if (attr.Role == userRole)
            {
                method.Invoke(module, null); // allowed
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }
        }
        else
        {
            // Method has no role restriction, allow all users
            method.Invoke(module, null);
        }
    }
}
