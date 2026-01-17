using System;
namespace MovieManagementSystem
{
    class Movie
    {
        public int Id;
        public string Name, Genre;
        public int AvailableSeats;
    }
	 class MovieBookingPlatform
    {
        static List<Movie> movies = new List<Movie>();
        static int movieIdCounter = 1;
		
		  static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Movie Management System ");
                Console.WriteLine("1. Admin\n2. User\n3. Exit");
                Console.Write("Choose role: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: AdminMenu(); break;
                    case 2: UserMenu(); break;
                    case 3: Environment.Exit(0); break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }
		
		  static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Admin Menu \n1. Add Movie\n2. Remove Movie\n3. View Movies\n4. Back");
                Console.Write("Enter choice: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: AddMovie(); break;
                    case 2: RemoveMovie(); break;
                    case 3: ViewMovies(); break;
                    case 4: return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
                Console.ReadKey();
            }
        }
		
		 static void AddMovie()
        {
            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter available seats: ");
            int seats = Convert.ToInt32(Console.ReadLine());
            movies.Add(new Movie { Id = movieIdCounter++, Name = name, Genre = genre, AvailableSeats = seats });
            Console.WriteLine("Movie added successfully!");
        }
		
		  static void RemoveMovie()
        {
            ViewMovies();
            Console.Write("Enter Movie ID to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie movie = movies.Find(m => m.Id == id);
            if (movie != null) { movies.Remove(movie); Console.WriteLine("Movie removed successfully!"); }
            else Console.WriteLine("Movie not found!");
        }

 static void UserMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== User Menu ====\n1. View Movies\n2. Book Movie\n3. Back");
                Console.Write("Enter choice: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: ViewMovies(); break;
                    case 2: BookMovie(); break;
                    case 3: return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
                Console.ReadKey();
            }
        }
		        static void ViewMovies()
        {
            Console.WriteLine("\n Movie List ");
            if (movies.Count == 0) Console.WriteLine("No movies available.");
            else foreach (var movie in movies) Console.WriteLine($"ID: {movie.Id}, Name: {movie.Name}, Genre: {movie.Genre}, Seats: {movie.AvailableSeats}");
        }
		
		  static void BookMovie()
        {
            ViewMovies();
            Console.Write("Enter Movie ID to book: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie movie = movies.Find(m => m.Id == id);
            if (movie == null) { Console.WriteLine("Movie not found!"); return; }
            Console.Write("Enter number of seats to book: ");
            int seats = Convert.ToInt32(Console.ReadLine());
            if (seats <= movie.AvailableSeats) { movie.AvailableSeats -= seats; Console.WriteLine("Booking successful!"); }
            else Console.WriteLine("Not enough seats available!");
        }
    }
}
