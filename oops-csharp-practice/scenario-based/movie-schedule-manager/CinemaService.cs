using System;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.cinema_time
{
    // Concrete class implementing cinema operations using arrays
    public class CinemaService : ICinemaService
    {
        private string[] movieTitles = new string[100]; // max 100 movies
        private string[] movieTimes = new string[100];
        private int count = 0; // current number of movies

        // Add a movie
        public void AddMovie(string title, string time)
        {
            if (count >= movieTitles.Length)
            {
                Console.WriteLine("Movie list is full.");
                return;
            }

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(time))
            {
                Console.WriteLine("Title and time cannot be empty.");
                return;
            }

            movieTitles[count] = title;
            movieTimes[count] = time;
            count++;
        }

        // Search movies by keyword
        public void SearchMovie(string keyword)
        {
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (movieTitles[i].ToLower().Contains(keyword.ToLower()))
                {
                    Console.WriteLine($"{movieTitles[i]} at {movieTimes[i]}");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No movie found.");
        }

        // Display all movies
        public void DisplayAllMovies()
        {
            if (count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {movieTitles[i]} at {movieTimes[i]}");
            }
        }

        // Print movie report
        public void PrintReport()
        {
            if (count == 0)
            {
                Console.WriteLine("No movies to display in report.");
                return;
            }

            string[] titlesArray = new string[count];
            string[] timesArray = new string[count];
            Array.Copy(movieTitles, titlesArray, count);
            Array.Copy(movieTimes, timesArray, count);

            Console.WriteLine("\nMovie Report:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{titlesArray[i]} - {timesArray[i]}");
            }
        }
    }
}
