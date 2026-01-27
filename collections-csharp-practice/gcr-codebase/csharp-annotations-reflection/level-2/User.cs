using System;
using System.Reflection;

// 1. Define custom MaxLength attribute
[AttributeUsage(AttributeTargets.Field)]
public class MaxLengthAttribute : Attribute
{
    public int Length { get; set; }

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

// 2. User class with a field
public class User
{
    [MaxLength(10)] // Maximum length is 10
    public string Username;

    // Constructor
    public User(string username)
    {
        // Get field info
        FieldInfo field = typeof(User).GetField("Username");

        // Check if MaxLength attribute is applied
        var attr = (MaxLengthAttribute)Attribute.GetCustomAttribute(field, typeof(MaxLengthAttribute));

        if (attr != null && username.Length > attr.Length)
        {
            throw new ArgumentException($"Username cannot exceed {attr.Length} characters!");
        }

        Username = username;
    }

    public void Display()
    {
        Console.WriteLine($"Username: {Username}");
    }
}

// 3. Main program
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter username: ");
            string input = Console.ReadLine();

            User user = new User(input);
            user.Display();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
