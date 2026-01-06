using System;
using System.Collections.Generic;

// Interface that defines insurance-related behavior
// Any vehicle that can be insured must implement these methods
interface IInsurable
{
    double CalculateInsurance();        // Returns fixed or calculated insurance amount
    string GetInsuranceDetails();       // Returns insurance description
}

// Abstract base class representing a general vehicle
// Contains common data shared by all vehicle types
abstract class Vehicle
{
    // Private fields to protect direct access
    private string vehicleNumber;
    private double rentalRate;

    // Property to store and retrieve vehicle registration number
    public string VehicleNumber
    {
        get => vehicleNumber;
        set => vehicleNumber = value;
    }

    // Property for storing rental cost per day
    public double RentalRate
    {
        get => rentalRate;
        set => rentalRate = value;
    }

    // Abstract method forces subclasses to define rental cost logic
    public abstract double CalculateRentalCost(int days);
}

// Car class inherits from Vehicle and supports insurance features
class Car : Vehicle, IInsurable
{
    // Calculates total rental cost based on number of days
    public override double CalculateRentalCost(int days)
    {
        return days * RentalRate;
    }

    // Returns a fixed insurance amount for cars
    public double CalculateInsurance()
    {
        return 500;
    }

    // Provides insurance information in readable form
    public string GetInsuranceDetails()
    {
        return "Standard Car Insurance";
    }
}

// Main class that handles user interaction and execution
class VehicleRental
{
    static void Main()
    {
        // Vehicle reference pointing to a Car object (polymorphism)
        Vehicle car = new Car();

        // Taking vehicle number input from the user
        Console.Write("Enter Vehicle Number: ");
        car.VehicleNumber = Console.ReadLine();

        // Taking daily rental rate input
        Console.Write("Enter Rate per Day: ");
        car.RentalRate = double.Parse(Console.ReadLine());

        // Accepting number of rental days
        Console.Write("Enter Days: ");
        int days = int.Parse(Console.ReadLine());

        // Displaying total rental cost
        Console.WriteLine($"Rental Cost: {car.CalculateRentalCost(days)}");
    }
}
