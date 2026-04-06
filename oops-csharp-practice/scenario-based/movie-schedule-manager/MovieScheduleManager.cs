using System;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.cinema_time
{
    class MovieScheduleManager
    {
        static void Main()
        {
            ICinemaService cinema = new CinemaService();

            while (true)
            {
                Console.WriteLine("\n=== CinemaTime Menu ===");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Search Movie");
                Console.WriteLine("3. Display All Movies");
                Console.WriteLine("4. Print Movie Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Movie Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Show Time (HH:MM): ");
                        string time = Console.ReadLine();

                        cinema.AddMovie(title, time);
                        Console.WriteLine("Movie added successfully!");
                        break;

                    case 2:
                        Console.Write("Enter search keyword: ");
                        string keyword = Console.ReadLine();
                        cinema.SearchMovie(keyword);
                        break;

                    case 3:
                        cinema.DisplayAllMovies();
                        break;

                    case 4:
                        cinema.PrintReport();
                        break;

                    case 5:
                        Console.WriteLine("Exiting CinemaTime...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
