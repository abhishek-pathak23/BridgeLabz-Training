using System;
using System.Reflection;

namespace ReflectionDemo
{
    // Step 1: Create custom attribute
    [AttributeUsage(AttributeTargets.Class)]
    class AuthorAttribute : Attribute
    {
        public string Name { get; }

        // Constructor to accept author name
        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }

    // Step 2: Apply attribute to a class
    [Author("Aditya Gurjar")]
    class ProjectInfo
    {
        public void Show()
        {
            Console.WriteLine("Project class executed");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get type information of the class
            Type type = typeof(ProjectInfo);

            // Step 3: Retrieve Author attribute using Reflection
            AuthorAttribute author =
                (AuthorAttribute)Attribute.GetCustomAttribute(
                    type,
                    typeof(AuthorAttribute)
                );

            // Display attribute value
            if (author != null)
            {
                Console.WriteLine("Author Name: " + author.Name);
            }
            else
            {
                Console.WriteLine("Author attribute not found");
            }
        }
    }
}
