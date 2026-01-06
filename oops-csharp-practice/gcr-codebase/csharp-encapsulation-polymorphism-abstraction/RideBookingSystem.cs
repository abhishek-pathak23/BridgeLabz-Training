using System;

// Interface that defines GPS-related operations
// Any vehicle supporting GPS must implement these methods
interface IGPS
{
    void GetCurrentLocation();          // Fetches current location
    void UpdateLocation(string location); // Updates vehicle location
}

// Abstract class representing a generic vehicle
// Contains common vehicle-related data
abstract class Vehicle
{
    // Protected fields accessible to derived classes
    protected string driverName = "";
    protected double ratePerKm;

    // Forces subclasses to define fare calculation logic
    public abstract double CalculateFare(double distance);

    // Displays basic vehicle details
    public void GetVehicleDetails()
    {
        Console.WriteLine($"Driver Name: {driverName}");
        Console.WriteLine($"Rate per Km: {ratePerKm}");
    }
}

// Car class extends Vehicle and supports GPS features
class Car : Vehicle, IGPS
{
    private string currentLocation = "Not Set";

    // Constructor to set default values
    public Car(string driverName)
    {
        this.driverName = driverName;
        ratePerKm = 15;   // default fare rate
    }

    // Calculates total fare based on distance travelled
    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    // Displays current vehicle location
    public void GetCurrentLocation()
    {
        Console.WriteLine($"Current Location: {currentLocation}");
    }

    // Updates vehicle location
    public void UpdateLocation(string location)
    {
        currentLocation = location;
        Console.WriteLine($"Location updated to: {currentLocation}");
    }
}

// Program execution starts here
class RideBookingSystem
{
    static void Main()
    {
        Console.Write("Enter Driver Name: ");
        string driver = Console.ReadLine()!;

        Car car = new Car(driver);
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Ride Booking Menu ---");
            Console.WriteLine("1. View Vehicle Details");
            Console.WriteLine("2. Update Location");
            Console.WriteLine("3. Get Current Location");
            Console.WriteLine("4. Calculate Fare");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    car.GetVehicleDetails();
                    break;

                case 2:
                    Console.Write("Enter New Location: ");
                    string location = Console.ReadLine()!;
                    car.UpdateLocation(location);
                    break;

                case 3:
                    car.GetCurrentLocation();
                    break;

                case 4:
                    Console.Write("Enter Distance (km): ");
                    double distance = double.Parse(Console.ReadLine()!);
                    Console.WriteLine($"Total Fare: ₹{car.CalculateFare(distance)}");
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Thank you for using the Ride Booking System");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
