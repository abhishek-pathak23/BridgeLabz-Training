using System;

class LegacyAPI
{
    // Mark old method as obsolete
    [Obsolete("OldFeature is deprecated. Please use NewFeature() instead.")]
    public void OldFeature()
    {
        Console.WriteLine("Executing old feature...");
    }

    // New recommended method
    public void NewFeature()
    {
        Console.WriteLine("Executing new feature!");
    }
}

class Program
{
    static void Main()
    {
        LegacyAPI api = new LegacyAPI();

        Console.WriteLine("Choose method to execute:");
        Console.WriteLine("1. OldFeature (deprecated)");
        Console.WriteLine("2. NewFeature");

        Console.Write("Enter choice (1 or 2): ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            api.OldFeature(); // This will show a compile-time warning
        }
        else if (choice == "2")
        {
            api.NewFeature();
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}
