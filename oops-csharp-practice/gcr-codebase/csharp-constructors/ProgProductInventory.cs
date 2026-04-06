using System;

class Product
{
    // Instance variables for each product
    public string productName;
    public double price;

    // Class variable to track total products created
    public static int totalProducts = 0;

    // Constructor to initialize a product
    public Product(string name, double p)
    {
        productName = name;
        price = p;
        totalProducts++; // Increment total products whenever a new product is created
    }

    // Instance method to display details of this product
    public void DisplayProductDetails()
    {
        Console.WriteLine($"Product: {productName}, Price: {price}");
    }

    // Class method to display total number of products
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: " + totalProducts);
    }
}

class ProgProductInventory
{
    static void Main()
    {
        Console.Write("How many products do you want to enter? ");
        int n = Convert.ToInt32(Console.ReadLine());
        Product[] products = new Product[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Product {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            products[i] = new Product(name, price);
        }

        Console.WriteLine("\n--- Product Details ---");
        foreach (var prod in products)
        {
            prod.DisplayProductDetails();
        }

        Product.DisplayTotalProducts();
    }
}
