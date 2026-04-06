using System;

// Interface defining refueling capability
interface Refuelable
{
    // Method to be implemented by any refuelable vehicle
    void Refuel();
}

// Base class Vehicle
class Vehicle
{
    // Maximum speed of the vehicle
    public int MaxSpeed;

    // Vehicle model name
    public string Model;
}

// PetrolVehicle inherits from Vehicle and implements Refuelable interface
class PetrolVehicle : Vehicle, Refuelable
{
    // Implementation of Refuel() from Refuelable interface
    public void Refuel()
    {
        Console.WriteLine("Vehicle is refueled");
    }
}

// Main class
class VehicleManagementSys
{
    static void Main()
    {
        // Create object of PetrolVehicle
        PetrolVehicle v = new PetrolVehicle();

        // Take vehicle model input from user
        Console.Write("Enter Model: ");
        v.Model = Console.ReadLine();

        // Take maximum speed input from user
        Console.Write("Enter Max Speed: ");
        v.MaxSpeed = int.Parse(Console.ReadLine());

        // Call Refuel method from Refuelable interface
        v.Refuel();
    }
}
