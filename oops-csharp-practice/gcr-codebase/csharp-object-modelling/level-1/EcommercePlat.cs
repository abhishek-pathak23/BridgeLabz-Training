using System;
using System.Collections.Generic;

namespace ECommercePlatform
{
    // Represents a product available in the e-commerce system
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    // Represents a customer who can place orders
    class Customer
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
    }

    // Represents an order placed by a customer
    class Order
    {
        public Customer Customer { get; set; }         // Customer who placed the order
        public List<Product> Products { get; set; }    // List of products in the order

        public Order(Customer customer)
        {
            Customer = customer;
            Products = new List<Product>();
        }

        // Add a product to the order
        public void AddProduct(Product product) => Products.Add(product);

        // Display details of the order
        public void ShowOrder()
        {
            Console.WriteLine($"\nOrder Details for {Customer.Name}:");
            foreach (var product in Products)
                Console.WriteLine($"- {product.Name}: ${product.Price}");
        }
    }

    // Main program to simulate e-commerce order placement
    class EcommercePlat
    {
        static void Main()
        {
            // Input customer name
            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();
            Customer customer = new Customer(customerName);

            // Input number of products to order
            Console.WriteLine("Enter total number of products to order:");
            int totalProducts = int.Parse(Console.ReadLine());
            Order order = new Order(customer);

            // Input product details
            for (int i = 0; i < totalProducts; i++)
            {
                Console.WriteLine($"\nEnter name of Product {i + 1}:");
                string productName = Console.ReadLine();

                Console.WriteLine("Enter price of the product:");
                double productPrice = double.Parse(Console.ReadLine());

                order.AddProduct(new Product(productName, productPrice));
            }

            // Show the final order details
            order.ShowOrder();

            Console.WriteLine("\nThank you for your order! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
