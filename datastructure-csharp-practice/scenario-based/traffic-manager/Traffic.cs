using System;

namespace TrafficManager;

// Main class to run the Traffic Manager menu-driven program
class Traffic
{
    static void Main()
    {
        // Initialize TrafficMenu with roundabout capacity 5 and waiting queue size 5
        TrafficMenu traffic = new TrafficMenu(5, 5);

        int choice;
        do
        {
            // Display menu options
            Console.WriteLine("\n--- TRAFFIC MENU ---");
            Console.WriteLine("1. Enter Vehicle");
            Console.WriteLine("2. Exit Vehicle");
            Console.WriteLine("3. Show Traffic Status");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Handle new vehicle entry
                    Console.Write("Enter Vehicle Number: ");
                    int v = int.Parse(Console.ReadLine());
                    traffic.EnterVehicle(v);
                    break;

                case 2:
                    // Handle vehicle exit
                    traffic.ExitVehicle();
                    break;

                case 3:
                    // Display current roundabout and waiting queue status
                    traffic.ShowTrafficStatus();
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 0); // Repeat until user chooses to exit
    }
}
