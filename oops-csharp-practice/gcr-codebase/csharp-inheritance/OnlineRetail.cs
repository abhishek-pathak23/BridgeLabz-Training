using System;

// Base class Order
class Order
{
    // Unique order ID
    public int OrderId;

    // Date when order was placed
    public string OrderDate;
}

// Derived class ShippedOrder inherits from Order
class ShippedOrder : Order
{
    // Tracking number for shipped order
    public string TrackingNumber;
}

// Derived class DeliveredOrder inherits from ShippedOrder
class DeliveredOrder : ShippedOrder
{
    // Date when order was delivered
    public string DeliveryDate;

    // Method to display order delivery status
    public void GetOrderStatus()
    {
        Console.WriteLine("Order Delivered Successfully");
    }
}

// Main class
class OnlineRetail
{
    static void Main()
    {
        // Create object of DeliveredOrder class
        DeliveredOrder o = new DeliveredOrder();

        // Take order ID input from user
        Console.Write("Enter Order ID: ");
        o.OrderId = int.Parse(Console.ReadLine());

        // Take order date input from user
        Console.Write("Enter Order Date: ");
        o.OrderDate = Console.ReadLine();

        // Take tracking number input from user
        Console.Write("Enter Tracking Number: ");
        o.TrackingNumber = Console.ReadLine();

        // Take delivery date input from user
        Console.Write("Enter Delivery Date: ");
        o.DeliveryDate = Console.ReadLine();

        // Display order status
        o.GetOrderStatus();
    }
}
