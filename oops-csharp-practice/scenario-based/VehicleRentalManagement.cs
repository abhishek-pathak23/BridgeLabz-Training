using System;

// Interface for rentable vehicles
interface IRentable
{
    double CalculateRent(int days);
}

// Base Vehicle class
class Vehicle : IRentable
{
    protected string Make;
    protected string Model;
    protected double DailyRate;

    public Vehicle(string make, string model, double dailyRate)
    {
        Make = make;
        Model = model;
        DailyRate = dailyRate;
    }

    public virtual double CalculateRent(int days)
    {
        return DailyRate * days;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{Make} {Model} | Daily Rate: {DailyRate}");
    }
}

// Bike class
class Bike : Vehicle
{
    public Bike(string make, string model, double dailyRate)
        : base(make, model, dailyRate) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Bike -> {Make} {Model} | Rate: {DailyRate}");
    }
}

// Car class
class Car : Vehicle
{
    public Car(string make, string model, double dailyRate)
        : base(make, model, dailyRate) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Car -> {Make} {Model} | Rate: {DailyRate}");
    }
}

// Truck class
class Truck : Vehicle
{
    public Truck(string make, string model, double dailyRate)
        : base(make, model, dailyRate) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Truck -> {Make} {Model} | Rate: {DailyRate}");
    }
}

// Customer class
class Customer
{
    private string Name;
    private string Email;

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void RentVehicle(IRentable vehicle, int days)
    {
        Console.WriteLine($"{Name} rented for {days} days");
        Console.WriteLine($"Total Rent: {vehicle.CalculateRent(days)}");
    }
}

// Main class (MENU DRIVEN)
class VehicleRentalManagement
{
    static void Main()
    {
        Console.WriteLine("Enter Customer Name:");
        string customerName = Console.ReadLine() ?? "";

        Console.WriteLine("Enter Customer Email:");
        string customerEmail = Console.ReadLine() ?? "";

        Customer customer = new Customer(customerName, customerEmail);

        while (true)
        {
            Console.WriteLine("\n--- Vehicle Rental Menu ---");
            Console.WriteLine("1. Rent Bike");
            Console.WriteLine("2. Rent Car");
            Console.WriteLine("3. Rent Truck");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Thank you for using Vehicle Rental System.");
                break;
            }

            Console.Write("Enter Company Name: ");
            string make = Console.ReadLine() ?? "";

            Console.Write("Enter Model: ");
            string model = Console.ReadLine() ?? "";

            Console.Write("Enter Daily Charge: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Number of Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            IRentable vehicle;

            switch (choice)
            {
                case 1:
                    vehicle = new Bike(make, model, rate);
                    ((Bike)vehicle).DisplayInfo();
                    break;

                case 2:
                    vehicle = new Car(make, model, rate);
                    ((Car)vehicle).DisplayInfo();
                    break;

                case 3:
                    vehicle = new Truck(make, model, rate);
                    ((Truck)vehicle).DisplayInfo();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    continue;
            }

            customer.RentVehicle(vehicle, days);
        }
    }
}