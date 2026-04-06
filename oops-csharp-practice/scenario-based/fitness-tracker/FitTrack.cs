using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.fitness_tracker
{
    // Main program class to run the fitness tracker
    class FitTrack
    {
        static void Main()
        {
            Console.Write("Enter User Name: ");
            string name = Console.ReadLine(); // get user name input

            UserProfile user = new UserProfile(name); // create user profile

            int choice;
            do
            {
                // Display menu options
                Console.WriteLine("\n---- FitTrack Menu ----");
                Console.WriteLine("1. Cardio Workout");
                Console.WriteLine("2. Strength Workout");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CardioWorkout cardio = new CardioWorkout();
                        Console.Write("Enter duration in minutes: ");
                        cardio.DurationMinutes = int.Parse(Console.ReadLine());
                        user.PerformWorkout(cardio); // perform cardio workout
                        break;

                    case 2:
                        StrengthWorkout strength = new StrengthWorkout();
                        Console.Write("Enter duration in minutes: ");
                        strength.DurationMinutes = int.Parse(Console.ReadLine());
                        user.PerformWorkout(strength); // perform strength workout
                        break;

                    case 3:
                        Console.WriteLine("Exiting FitTrack...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!"); // handle wrong input
                        break;
                }
            }
            while (choice != 3); // loop until user chooses exit
        }
    }
}
