using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
    static void Main()
    {
        // Dictionary to store product prices
        Dictionary<string, double> productPrices = new Dictionary<string, double>();

        // List to maintain insertion order (LinkedDictionary equivalent)
        List<string> insertionOrder = new List<string>();

        Console.WriteLine("Enter number of products to add to the cart:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nProduct #{i + 1} Name:");
            string product = Console.ReadLine();

            Console.WriteLine($"Price of {product}:");
            double price = double.Parse(Console.ReadLine());

            // Store in dictionary
            productPrices[product] = price;

            // Maintain insertion order
            if (!insertionOrder.Contains(product))
                insertionOrder.Add(product);
        }

        // Display products in insertion order
        Console.WriteLine("\n--- Products in Insertion Order ---");
        foreach (string product in insertionOrder)
        {
            Console.WriteLine($"{product} : ${productPrices[product]:0.00}");
        }

        // Display products sorted by price (ascending)
        SortedDictionary<double, List<string>> sortedByPrice = new SortedDictionary<double, List<string>>();
        foreach (var pair in productPrices)
        {
            string product = pair.Key;
            double price = pair.Value;

            if (!sortedByPrice.ContainsKey(price))
                sortedByPrice[price] = new List<string>();

            sortedByPrice[price].Add(product);
        }

        Console.WriteLine("\n--- Products Sorted by Price ---");
        foreach (var pair in sortedByPrice)
        {
            double price = pair.Key;
            foreach (string product in pair.Value)
            {
                Console.WriteLine($"{product} : ${price:0.00}");
            }
        }

        // Display total cost
        double total = productPrices.Values.Sum();
        Console.WriteLine($"\nTotal Cost: ${total:0.00}");
    }
}
