using System;

class CarRental
{
    // Fields to store rental information
    public string customerName; // Name of the customer renting the car
    public string carModel;     // Model of the car being rented
    public int rentalDays;      // Number of days the car is rented for
    public double totalCost;    // Total cost of the rental
    private double pricePerDay = 1000; // Daily rental rate (fixed)

    // Parameterized constructor to initialize rental details
    public CarRental(string name, string model, int days)
    {
        customerName = name;   // Assign customer name
        carModel = model;      // Assign car model
        rentalDays = days;     // Assign number of rental days
        totalCost = rentalDays * pricePerDay; // Calculate total rental cost
    }

    // Method to display all rental information
    public void DisplayRental()
    {
        Console.WriteLine($"Customer: {customerName}");
        Console.WriteLine($"Car Model: {carModel}");
        Console.WriteLine($"Rental Days: {rentalDays}");
        Console.WriteLine($"Total Cost: {totalCost} INR");
    }
}

class ProgCarRental
{
    static void Main()
    {
        // Ask user to enter rental details
        Console.WriteLine("Enter Rental Details:");
        Console.Write("Customer Name: "); 
        string name = Console.ReadLine(); // Read customer name
        Console.Write("Car Model: "); 
        string model = Console.ReadLine(); // Read car model
        Console.Write("Number of Rental Days: "); 
        int days = Convert.ToInt32(Console.ReadLine()); // Read rental days and convert to integer

        // Create a CarRental object with the entered details
        CarRental rental = new CarRental(name, model, days);

        // Display the rental information
        Console.WriteLine("\nRental Details:");
        rental.DisplayRental();
    }
}
