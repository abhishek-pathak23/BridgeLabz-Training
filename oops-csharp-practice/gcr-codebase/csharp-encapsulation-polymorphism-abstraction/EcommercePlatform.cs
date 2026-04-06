using System;
using System.Collections.Generic;

// Interface that defines tax-related responsibilities
// Any class implementing this must provide tax calculation logic
interface ITaxable
{
    double CalculateTax();        // Returns the tax amount for a product
    string GetTaxDetails();       // Returns tax description (rate/type)
}

// Abstract base class representing a generic product
// Common product properties are defined here
abstract class Product
{
    // Private fields to enforce encapsulation
    private int productId;
    private string name;
    private double price;

    // Public property to access and modify product ID
    public int ProductId
    {
        get => productId;
        set => productId = value;
    }

    // Public property for product name
    public string Name
    {
        get => name;
        set => name = value;
    }

    // Price property includes validation to prevent invalid values
    public double Price
    {
        get => price;
        set
        {
            if (value > 0)
                price = value;
        }
    }

    // Abstract method forces derived classes to implement discount logic
    public abstract double CalculateDiscount();
}

// Electronics class extends Product and applies tax rules
class Electronics : Product, ITaxable
{
    // Electronics products get a fixed 10% discount
    public override double CalculateDiscount()
    {
        return Price * 0.1;
    }

    // GST tax calculation specific to electronics
    public double CalculateTax()
    {
        return Price * 0.18;
    }

    // Provides a readable description of the tax applied
    public string GetTaxDetails()
    {
        return "18% GST";
    }
}

// Entry point of the application
class EcommercePlatform
{
    static void Main()
    {
        // List prepared for handling multiple products (scalable design)
        List<Product> products = new List<Product>();

        // Creating an Electronics object
        Electronics e = new Electronics();

        // Accepting product details from the user
        Console.Write("Enter Product ID: ");
        e.ProductId = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        e.Name = Console.ReadLine();

        Console.Write("Enter Price: ");
        e.Price = double.Parse(Console.ReadLine());

        // Final price calculation after applying tax and discount
        double finalPrice = e.Price + e.CalculateTax() - e.CalculateDiscount();

        // Displaying the computed final price
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}
