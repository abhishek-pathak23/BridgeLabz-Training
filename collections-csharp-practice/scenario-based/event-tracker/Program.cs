using System;

class Program
{
    static void Main()
    {
        EventTracker tracker = new EventTracker(); // Use concrete class directly
        string filePath = "AuditLog.json";

        while (true)
        {
            Console.WriteLine("===== EventTracker Menu =====");
            Console.WriteLine("1. Scan classes for audited methods");
            Console.WriteLine("2. Generate JSON audit log");
            Console.WriteLine("3. Show scanned events");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    tracker.ScanClasses();
                    break;
                case "2":
                    tracker.GenerateJSON(filePath);
                    break;
                case "3":
                    tracker.ShowEvents();
                    break;
                case "4":
                    Console.WriteLine("Exiting EventTracker...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.\n");
                    break;
            }
        }
    }
}
