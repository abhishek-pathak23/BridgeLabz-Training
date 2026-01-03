using System;

// Base class Vehicle
class Vehicle
{
    // Maximum speed of the vehicle
    public int MaxSpeed;

    // Type of fuel used by the vehicle
    public string FuelType;

    // Virtual method to display vehicle information
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Speed: {MaxSpeed}, Fuel: {FuelType}");
    }
}

// Derived class Car inherits from Vehicle
class Car : Vehicle
{
    // Seating capacity of the car
    public int SeatCapacity;

    // Overriding DisplayInfo method
    public override void DisplayInfo()
    {
        // Call base class method
        base.DisplayInfo();

        // Display car-specific information
        Console.WriteLine($"Seats: {SeatCapacity}");
    }
}

// Main class
class VehicleTransport
{
    static void Main()
    {
        // Create object of Car class
        Car car = new Car();

        // Take maximum speed input from user
        Console.Write("Enter Max Speed: ");
        car.MaxSpeed = int.Parse(Console.ReadLine());

        // Take fuel type input from user
        Console.Write("Enter Fuel Type: ");
        car.FuelType = Console.ReadLine();

        // Take seat capacity input from user
        Console.Write("Enter Seat Capacity: ");
        car.SeatCapacity = int.Parse(Console.ReadLine());

        // Display all vehicle details
        car.DisplayInfo();
    }
}
