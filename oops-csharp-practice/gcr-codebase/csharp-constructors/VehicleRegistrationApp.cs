using System;

class Vehicle
{
    // Instance variables (unique for each vehicle)
    public string ownerName;
    public string vehicleType;

    // Class variable (same for all vehicles)
    public static double registrationFee;

    // Constructor to initialize vehicle details
    public Vehicle(string owner, string type)
    {
        ownerName = owner;
        vehicleType = type;
    }

    // Instance method: displays details of one vehicle
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name      : " + ownerName);
        Console.WriteLine("Vehicle Type    : " + vehicleType);
        Console.WriteLine("Registration Fee: " + registrationFee);
        Console.WriteLine("--------------------------------");
    }

    // Class method: updates registration fee for all vehicles
    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
    }
}

class VehicleRegistrationApp
{
    static void Main()
    {
        // Take registration fee input
        Console.Write("Enter Registration Fee: ");
        double fee = Convert.ToDouble(Console.ReadLine());
        Vehicle.UpdateRegistrationFee(fee);

        // Take number of vehicles
        Console.Write("Enter number of vehicles: ");
        int count = Convert.ToInt32(Console.ReadLine());

        // Create array to store vehicle objects
        Vehicle[] vehicles = new Vehicle[count];

        // Input details for each vehicle
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\nEnter details for Vehicle " + (i + 1));

            Console.Write("Owner Name: ");
            string owner = Console.ReadLine();

            Console.Write("Vehicle Type: ");
            string type = Console.ReadLine();

            vehicles[i] = new Vehicle(owner, type);
        }

        // Display all vehicle details
        Console.WriteLine("\n--- Vehicle Registration Details ---");
        for (int i = 0; i < count; i++)
        {
            vehicles[i].DisplayVehicleDetails();
        }
    }
}
