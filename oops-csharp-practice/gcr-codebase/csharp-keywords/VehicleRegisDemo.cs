using System;

class Vehicle
{
    // Static variable shared by all Vehicle objects
    // Stores the registration fee applicable to every vehicle
    public static int RegistrationFee;

    // Public instance variable to store owner's name
    public string OwnerName;

    // Public instance variable to store type of vehicle
    public string VehicleType;

    // Readonly variable: registration number cannot be changed once assigned
    public readonly string RegistrationNumber;

    // Constructor to initialize vehicle details
    public Vehicle(string owner, string type, string reg)
    {
        // Assign constructor parameters to class fields
        this.OwnerName = owner;
        this.VehicleType = type;
        this.RegistrationNumber = reg;
    }

    // Static method to update the registration fee
    // Can be accessed using the class name
    public static void UpdateRegistrationFee(int fee)
    {
        RegistrationFee = fee;
    }

    // Instance method to display basic vehicle information
    public void ShowVehicle()
    {
        Console.WriteLine(OwnerName + " - " + VehicleType);
    }
}

class VehicleRegisDemo
{
    // Main method: program execution starts here
    static void Main()
    {
        // Set registration fee for all vehicles
        Vehicle.UpdateRegistrationFee(500);

        // Read owner name from user
        Console.Write("Owner Name: ");
        string o = Console.ReadLine();

        // Read vehicle type from user
        Console.Write("Vehicle Type: ");
        string t = Console.ReadLine();

        // Read registration number from user
        Console.Write("Reg No: ");
        string r = Console.ReadLine();

        // Create Vehicle object and store it in object reference (upcasting)
        object v = new Vehicle(o, t, r);

        // Safe type-checking using 'is' operator
        if (v is Vehicle)
        {
            // Downcasting to call Vehicle instance method
            ((Vehicle)v).ShowVehicle();
        }
    }
}
