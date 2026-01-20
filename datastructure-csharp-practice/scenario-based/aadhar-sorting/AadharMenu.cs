using System;

public class AadharMenu
{
    private AadharUtilityImpl utility;

    // Constructor to initialize menu with utility instance
    public AadharMenu(AadharUtilityImpl utility)
    {
        this.utility = utility;
    }

    // Display menu and handle user choices in a loop
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Display All Aadhar Records");
            Console.WriteLine("2. Sort Aadhar Records (Radix Sort)");
            Console.WriteLine("3. Search Aadhar Record");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Display all stored Aadhar records
                    utility.DisplayAll();
                    break;

                case 2:
                    // Sort records using Radix Sort
                    utility.SortAadhar();
                    break;

                case 3:
                    // Search for a specific Aadhar number
                    Console.Write("Enter Aadhar number: ");
                    long key = long.Parse(Console.ReadLine());
                    utility.SearchAadhar(key);
                    break;

                case 4:
                    // Exit the menu loop
                    return;
            }
        }
    }
}
