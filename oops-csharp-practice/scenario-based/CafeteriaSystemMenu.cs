//SUMMARY
// We are building a simple cafeteria menu system using arrays and methods.
// A string[] array is used to store the fixed list of menu items.
// The menu is displayed with index numbers, allowing users to select items easily.
// Methods like DisplayMenu() and GetItemByIndex() are used to organize the code and fetch user-selected items, making the program clear and reusable.
using System;

class CafeteriaSystemMenu
{
    static void Main()
    {
        // Stores names of food items available in cafeteria
        string[] foodNames =
        {
            "Idli", "Dosa", "Vada", "Poha",
            "Sandwich", "Burger", "Pizza",
            "Pasta", "Tea", "Coffee"
        };

        // Stores prices corresponding to each food item
        int[] foodPrices = { 30, 40, 25, 35, 50, 80, 120, 100, 15, 20 };

        // Stores quantity ordered for each item
        int[] orderedQty = new int[foodNames.Length];

        int option;

        // Menu runs until user chooses Exit option
        do
        {
            Console.WriteLine("\n=== Cafeteria Menu ===");
            Console.WriteLine("1. View Items");
            Console.WriteLine("2. Place Order");
            Console.WriteLine("3. Generate Bill & Exit");
            Console.Write("Choose option: ");

            // Read user choice
            option = int.Parse(Console.ReadLine());

            // Perform action based on user choice
            switch (option)
            {
                case 1:
                    // Display food items with prices
                    ShowItems(foodNames, foodPrices);
                    break;

                case 2:
                    // Allow user to order food items
                    TakeOrder(foodNames, orderedQty);
                    break;

                case 3:
                    // Generate final bill and exit
                    PrintBill(foodNames, foodPrices, orderedQty);
                    break;

                default:
                    // Invalid menu choice
                    Console.WriteLine("Please select a valid option");
                    break;
            }

        } while (option != 3);
    }

    // Method to display available food items with prices
    static void ShowItems(string[] names, int[] prices)
    {
        Console.WriteLine("\nAvailable Food:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(i + " -> " + names[i] + " : ₹" + prices[i]);
        }
    }

    // Method to take food order from user
    static void TakeOrder(string[] names, int[] qty)
    {
        Console.Write("Enter item index (-1 to stop): ");
        int index = int.Parse(Console.ReadLine());

        // Continue ordering until user enters -1
        while (index != -1)
        {
            if (index >= 0 && index < names.Length)
            {
                // Increase quantity for selected item
                qty[index]++;
                Console.WriteLine(names[index] + " added to cart");
            }
            else
            {
                // Invalid item index entered
                Console.WriteLine("Invalid item number");
            }

            Console.Write("Enter item index (-1 to stop): ");
            index = int.Parse(Console.ReadLine());
        }
    }

    // Method to calculate and display final bill
    static void PrintBill(string[] names, int[] prices, int[] qty)
    {
        int grandTotal = 0;
        Console.WriteLine("\n--- Final Bill ---");

        // Calculate bill for each ordered item
        for (int i = 0; i < names.Length; i++)
        {
            if (qty[i] > 0)
            {
                int amount = qty[i] * prices[i];
                Console.WriteLine(names[i] + " x " + qty[i] + " = ₹" + amount);
                grandTotal += amount;
            }
        }

        // Display total payable amount
        Console.WriteLine("-------------------");
        Console.WriteLine("Payable Amount: ₹" + grandTotal);
    }
}
