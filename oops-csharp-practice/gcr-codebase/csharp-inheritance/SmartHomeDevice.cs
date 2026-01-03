using System;

// Base class Device
class Device
{
    // Unique ID of the device
    public string DeviceId;

    // Current status of the device (On/Off, Active/Inactive)
    public string Status;
}

// Derived class Thermostat inherits from Device
class Thermostat : Device
{
    // Current temperature value
    public int Temperature;

    // Method to display device status and temperature
    public void DisplayStatus()
    {
        Console.WriteLine($"ID: {DeviceId}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"Temperature: {Temperature}");
    }
}

// Main class
class SmartHomeDevice
{
    static void Main()
    {
        // Create object of Thermostat class
        Thermostat t = new Thermostat();

        // Take device ID input from user
        Console.Write("Enter Device ID: ");
        t.DeviceId = Console.ReadLine();

        // Take device status input from user
        Console.Write("Enter Status: ");
        t.Status = Console.ReadLine();

        // Take temperature input from user
        Console.Write("Enter Temperature: ");
        t.Temperature = int.Parse(Console.ReadLine());

        // Display thermostat details
        t.DisplayStatus();
    }
}
