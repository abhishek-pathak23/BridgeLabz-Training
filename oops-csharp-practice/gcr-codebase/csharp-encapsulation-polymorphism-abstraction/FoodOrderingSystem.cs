using System;

// Interface for discount behavior
interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

// Abstract base class
abstract class FoodItem
{
    protected string itemName;
    protected double price;
    protected int quantity;

    // Constructor sets common values
    protected FoodItem(string name, int quantity)
    {
        this.itemName = name;
        this.quantity = quantity;
    }

    // Abstract method
    public abstract double CalculateTotalPrice();

    // Common method
    public void GetItemDetails()
    {
        Console.WriteLine($"Item: {itemName}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Quantity: {quantity}");
    }
}

// Veg food item with default price
class VegItem : FoodItem, IDiscountable
{
    public VegItem(string name, int quantity)
        : base(name, quantity)
    {
        price = 120;   // ✅ default veg price
    }

    public override double CalculateTotalPrice()
    {
        return price * quantity;
    }

    public double ApplyDiscount()
    {
        return 50;
    }

    public string GetDiscountDetails()
    {
        return "Veg discount applied";
    }
}

// Non-veg food item with default price
class NonVegItem : FoodItem, IDiscountable
{
    public NonVegItem(string name, int quantity)
        : base(name, quantity)
    {
        price = 180;   // ✅ default non-veg price
    }

    public override double CalculateTotalPrice()
    {
        return (price * quantity) + 80; // extra charge
    }

    public double ApplyDiscount()
    {
        return 30;
    }

    public string GetDiscountDetails()
    {
        return "Non-veg discount applied";
    }
}

// Main class
class FoodOrderingSystem
{
    static void Main()
    {
        Console.WriteLine("Choose Food Type: 1. Veg  2. Non-Veg");
        int choice = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Item Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter Quantity: ");
        int qty = int.Parse(Console.ReadLine()!);

        FoodItem food;

        if (choice == 1)
            food = new VegItem(name, qty);
        else
            food = new NonVegItem(name, qty);

        // Polymorphic behavior
        food.GetItemDetails();

        double total = food.CalculateTotalPrice();
        double discount = ((IDiscountable)food).ApplyDiscount();

        Console.WriteLine(((IDiscountable)food).GetDiscountDetails());
        Console.WriteLine($"Final Amount: ₹{total - discount}");
    }
}
