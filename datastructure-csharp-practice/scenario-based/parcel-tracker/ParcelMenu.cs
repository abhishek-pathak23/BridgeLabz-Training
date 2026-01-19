using ParcelTracker.Utility;
using System;

namespace ParcelTracker.Menu
{
    public class ParcelMenu
    {
        private readonly ParcelTrackerUtility tracker = new();

        public void Show()
        {
            while (true)
            {
                PrintMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddStage();
                        break;

                    case "2":
                        tracker.DisplayStages();
                        break;

                    case "3":
                        tracker.CheckParcelStatus();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n--- Parcel Tracker Menu ---");
            Console.WriteLine("1. Add Delivery Stage");
            Console.WriteLine("2. View Delivery Chain");
            Console.WriteLine("3. Check Parcel Status");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");
        }

        private void AddStage()
        {
            Console.Write("Enter Stage Name: ");
            string stage = Console.ReadLine() ?? "";
            tracker.AddStage(stage);
        }
    }
}
