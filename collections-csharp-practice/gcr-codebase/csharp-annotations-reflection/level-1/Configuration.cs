using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Configuration class with private static field
    class Configuration
    {
        private static string API_KEY = "OLD_KEY";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get type information of Configuration class
            Type type = typeof(Configuration);

            // Get private static field 'API_KEY'
            FieldInfo fieldInfo = type.GetField(
                "API_KEY",
                BindingFlags.NonPublic | BindingFlags.Static
            );

            // Take new API key from user
            Console.Write("Enter new API Key: ");
            string newKey = Console.ReadLine();

            // Set new value to static field (null for static fields)
            fieldInfo.SetValue(null, newKey);

            // Get updated value of static field
            string updatedKey = (string)fieldInfo.GetValue(null);

            // Display updated API key
            Console.WriteLine("Updated API Key: " + updatedKey);
        }
    }
}
