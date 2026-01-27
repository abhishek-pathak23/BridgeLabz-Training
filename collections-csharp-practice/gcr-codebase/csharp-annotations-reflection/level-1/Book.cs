using System;
using System.Reflection;
using System.Text;

namespace ReflectionDemo
{
    // Sample class
    class Book
    {
        public int BookId;
        public string Title;
        public double Price;
    }

    class JsonGenerator
    {
        // Method to convert object to JSON-like string
        public static string ToJson(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();

            StringBuilder json = new StringBuilder();
            json.Append("{ ");

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                object value = field.GetValue(obj);

                // Add field name and value
                json.Append("\"" + field.Name + "\": ");

                // Add quotes for string values
                if (value is string)
                {
                    json.Append("\"" + value + "\"");
                }
                else
                {
                    json.Append(value);
                }

                // Add comma except for last field
                if (i < fields.Length - 1)
                {
                    json.Append(", ");
                }
            }

            json.Append(" }");
            return json.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object
            Book book = new Book();

            // Take input from user
            Console.Write("Enter Book Id: ");
            book.BookId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Book Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter Price: ");
            book.Price = Convert.ToDouble(Console.ReadLine());

            // Convert object to JSON-like string
            string json = JsonGenerator.ToJson(book);

            // Display result
            Console.WriteLine("\nGenerated JSON:");
            Console.WriteLine(json);
        }
    }
}
