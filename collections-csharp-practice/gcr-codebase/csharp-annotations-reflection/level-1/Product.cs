using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionDemo
{
    // Different target class
    class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;
    }

    class ObjectMapper
    {
        // Generic method to map dictionary data to object
        public static T ToObject<T>(Type clazz, Dictionary<string, object> properties)
            where T : new()
        {
            // Create object dynamically (no new keyword)
            T obj = (T)Activator.CreateInstance(clazz);

            // Assign values to fields using reflection
            foreach (var item in properties)
            {
                FieldInfo fieldInfo = clazz.GetField(item.Key);

                // Set value only if field exists
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(obj, item.Value);
                }
            }

            return obj;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to hold user input
            Dictionary<string, object> data = new Dictionary<string, object>();

            // Take input from user
            Console.Write("Enter Product Id: ");
            data["ProductId"] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            data["ProductName"] = Console.ReadLine();

            Console.Write("Enter Price: ");
            data["Price"] = Convert.ToDouble(Console.ReadLine());

            // Map dictionary to Product object
            Product product = ObjectMapper.ToObject<Product>(
                typeof(Product),
                data
            );

            // Display result
            Console.WriteLine("\n--- Product Details ---");
            Console.WriteLine("Product Id: " + product.ProductId);
            Console.WriteLine("Product Name: " + product.ProductName);
            Console.WriteLine("Price: " + product.Price);
        }
    }
}
