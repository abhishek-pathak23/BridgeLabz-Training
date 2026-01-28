using System;

public class UserInterface
{
    public static void Main()
    {
        FlightUtil util = new FlightUtil();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== AeroVigil Flight System =====");
            Console.WriteLine("1. Enter Flight Details");
            Console.WriteLine("2. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("\nEnter flight number (FL-XXXX): ");
                        string flightNumber = Console.ReadLine();

                        Console.WriteLine("Enter flight name (SpiceJet / Vistara / IndiGo / Air Arabia): ");
                        string flightName = Console.ReadLine();

                        Console.WriteLine("Enter passenger count: ");
                        int passengerCount = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter current fuel level: ");
                        double currentFuelLevel = double.Parse(Console.ReadLine());

                        util.ValidateFlightNumber(flightNumber);
                        util.ValidateFlightName(flightName);
                        util.ValidatePassengerCount(passengerCount, flightName);

                        double fuelRequired = util.CalculateFuelToFillTank(flightName, currentFuelLevel);

                        Console.WriteLine("\nFuel required to fill the tank: " + fuelRequired + " liters");
                    }
                    catch (InvalidFlightException e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nInvalid input format");
                    }
                    break;

                case "2":
                    exit = true;
                    Console.WriteLine("\nExiting system...");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    break;
            }
        }
    }
}
