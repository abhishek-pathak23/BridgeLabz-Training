using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.ambulance_route
{
    class AmbulanceSystem
    {
        static void Main()
        {
            IHospitalRoute route = new CircularHospitalRoute();

            route.AddUnit("Emergency");
            route.AddUnit("Radiology");
            route.AddUnit("Surgery");
            route.AddUnit("ICU");

            int choice;
            do
            {
                Console.WriteLine("\n--- Ambulance Route System ---");
                Console.WriteLine("1. Display Route");
                Console.WriteLine("2. Redirect Patient");
                Console.WriteLine("3. Mark Unit Available");
                Console.WriteLine("4. Mark Unit Busy");
                Console.WriteLine("5. Remove Unit");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        route.DisplayRoute();
                        break;
                    case 2:
                        route.RedirectPatient();
                        break;
                    case 3:
                        Console.Write("Unit name: ");
                        route.UpdateAvailability(Console.ReadLine(), true);
                        break;
                    case 4:
                        Console.Write("Unit name: ");
                        route.UpdateAvailability(Console.ReadLine(), false);
                        break;
                    case 5:
                        Console.Write("Unit name: ");
                        route.RemoveUnit(Console.ReadLine());
                        break;
                }

            } while (choice != 0);
        }
    }

}
