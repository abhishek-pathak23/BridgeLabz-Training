using System;

class ATMDispenser
{
    static void Main()
    {
        // Prompt user to enter withdrawal amount
        Console.Write("Enter the amount you wish to withdraw: ");
        int amount = int.Parse(Console.ReadLine());

        int choice;
        do
        {
            // Show menu options
            Console.WriteLine("\n===== ATM MENU =====");
            Console.WriteLine("1. Withdraw using all available notes");
            Console.WriteLine("2. Withdraw without 500 note");
            Console.WriteLine("3. Withdraw using limited notes (fallback scenario)");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    int[] notesA = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
                    ProcessWithdrawal(amount, notesA);
                    break;

                case 2:
                    int[] notesB = { 200, 100, 50, 20, 10, 5, 2, 1 };
                    ProcessWithdrawal(amount, notesB);
                    break;

                case 3:
                    int[] notesC = { 200, 100, 50 };
                    ProcessWithdrawal(amount, notesC);
                    break;

                case 4:
                    Console.WriteLine("\nExiting ATM. Thank you!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option! Please try again.");
                    break;
            }

        } while (choice != 4);
    }

    // Method to calculate and display dispensed notes
    static void ProcessWithdrawal(int amount, int[] notes)
    {
        int remainingAmount = amount;
        int notesDispensed = 0;

        Console.WriteLine($"\nProcessing withdrawal of ₹{amount}...");
        Console.WriteLine("Notes breakdown:");

        foreach (int note in notes)
        {
            int count = remainingAmount / note;
            if (count > 0)
            {
                Console.WriteLine($"  - ₹{note} : {count} piece(s)");
                remainingAmount -= count * note;
                notesDispensed += count;
            }
        }

        if (remainingAmount == 0)
        {
            Console.WriteLine($"\n Withdrawal successful! Total notes dispensed: {notesDispensed}\n");
        }
        else
        {
            Console.WriteLine($"\n Cannot dispense exact amount.");
            Console.WriteLine($"  Remaining balance not dispensed: ₹{remainingAmount}");
            Console.WriteLine($"  Total notes given: {notesDispensed}\n");
        }
    }
}
