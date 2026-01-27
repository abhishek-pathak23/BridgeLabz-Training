using System;
using System.Reflection;
using System.Text;

// 1. Define JsonField attribute
[AttributeUsage(AttributeTargets.Field)]
public class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }

    public JsonFieldAttribute(string name)
    {
        Name = name;
    }
}

// 2. User class with fields
public class User
{
    [JsonField("user_name")]
    public string Username;

    [JsonField("user_email")]
    public string Email;

    [JsonField("user_age")]
    public int Age;

    public User(string username, string email, int age)
    {
        Username = username;
        Email = email;
        Age = age;
    }
}

// 3. Method to convert object to JSON string using Reflection
public static class JsonSerializer
{
    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.Append("{ ");

        foreach (FieldInfo field in fields)
        {
            var attr = (JsonFieldAttribute)Attribute.GetCustomAttribute(field, typeof(JsonFieldAttribute));

            if (attr != null)
            {
                string key = attr.Name;
                object value = field.GetValue(obj);
                string valueStr = value is string ? $"\"{value}\"" : value.ToString();

                sb.Append($"\"{key}\": {valueStr}, ");
            }
        }

        if (sb.Length > 2)
            sb.Length -= 2; // remove last comma and space

        sb.Append(" }");
        return sb.ToString();
    }
}

// 4. Main program
class Program
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        User user = new User(username, email, age);

        string json = JsonSerializer.ToJson(user);
        Console.WriteLine("\nJSON Representation:");
        Console.WriteLine(json);
    }
}
