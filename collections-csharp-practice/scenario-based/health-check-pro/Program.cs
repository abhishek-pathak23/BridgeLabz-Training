using System;

class Program1
{
    static void Main()
    {
        IScanner scanner = new HealthCheckPro();
        string filePath = "API_Documentation.txt";

        while (true)
        {
            Console.WriteLine("===== HealthCheckPro Menu =====");
            Console.WriteLine("1. Scan all controllers");
            Console.WriteLine("2. Generate API documentation");
            Console.WriteLine("3. View missing annotations");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    scanner.ScanControllers();
                    break;
                case "2":
                    scanner.GenerateDocumentation(filePath);
                    break;
                case "3":
                    if (scanner is HealthCheckPro hc)
                        hc.ShowMissingAnnotations();
                    break;
                case "4":
                    Console.WriteLine("Exiting HealthCheckPro...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.\n");
                    break;
            }
        }
    }
}
