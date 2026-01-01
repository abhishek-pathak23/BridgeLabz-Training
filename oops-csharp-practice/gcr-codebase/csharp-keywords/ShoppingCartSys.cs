using System;

class Product
{
    // Static variable shared by all Product objects
    // Represents common discount applicable to all products
    public static double Discount;

    // Public instance variable to store product name
    public string ProductName;

    // Public instance variable to store product price
    public int Price;

    // Public instance variable to store available quantity
    public int Quantity;

    // Readonly variable: Product ID cannot be modified after initialization
    public readonly int ProductID;

    // Constructor to initialize product details
    public Product(string name, int price, int qty, int id)
    {
        // Assign constructor parameters to class variables
        this.ProductName = name;
        this.Price = price;
        this.Quantity = qty;
        this.ProductID = id;
    }

    // Static method to update discount value
    // Accessible using class name without creating object
    public static void UpdateDiscount(double d)
    {
        Discount = d;
    }

    // Instance method to display basic product details
    public void ShowProduct()
    {
        Console.WriteLine(ProductName + " - ₹" + Price);
    }
}

class ShoppingCartSys
{
    // Main method: execution starts here
    static void Main()
    {
        // Set discount for all products
        Product.UpdateDiscount(10);

        // Read product name from user
        Console.Write("Product Name: ");
        string n = Console.ReadLine();

        // Read product price and convert to integer
        Console.Write("Price: ");
        int p = int.Parse(Console.ReadLine());

        // Read product quantity
        Console.Write("Quantity: ");
        int q = int.Parse(Console.ReadLine());

        // Read product ID
        Console.Write("Product ID: ");
        int id = int.Parse(Console.ReadLine());

        // Create Product object and store it in object reference (upcasting)
        object pr = new Product(n, p, q, id);

        // Safe type-checking using 'is' operator
        if (pr is Product)
        {
            // Downcasting to access Product methods
            ((Product)pr).ShowProduct();
        }
    }
}
