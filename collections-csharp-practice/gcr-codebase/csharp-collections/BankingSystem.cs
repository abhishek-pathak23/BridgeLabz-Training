using System;
using System.Collections.Generic;
using System.Linq;

class BankingSystem
{
    static void Main()
    {
        // Dictionary to store account balances (AccountNumber -> Balance)
        Dictionary<int, double> accounts = new Dictionary<int, double>();

        Console.WriteLine("Enter number of accounts to create:");
        int n = int.Parse(Console.ReadLine());

        // Input account details
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter Account Number for account #{i + 1}:");
            int accNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter initial balance for account {accNumber}:");
            double balance = double.Parse(Console.ReadLine());

            accounts[accNumber] = balance;
        }

        // Display accounts sorted by balance
        SortedDictionary<double, List<int>> sortedAccounts = new SortedDictionary<double, List<int>>();
        foreach (var pair in accounts)
        {
            int accNumber = pair.Key;
            double balance = pair.Value;

            if (!sortedAccounts.ContainsKey(balance))
                sortedAccounts[balance] = new List<int>();

            sortedAccounts[balance].Add(accNumber);
        }

        Console.WriteLine("\n--- Accounts Sorted by Balance (Ascending) ---");
        foreach (var pair in sortedAccounts)
        {
            double balance = pair.Key;
            foreach (int acc in pair.Value)
            {
                Console.WriteLine($"Account {acc} : ${balance:0.00}");
            }
        }

        // Process withdrawal requests using a Queue
        Queue<Tuple<int, double>> withdrawalQueue = new Queue<Tuple<int, double>>();

        Console.WriteLine("\nEnter number of withdrawal requests:");
        int m = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine($"\nRequest #{i + 1}: Enter Account Number:");
            int acc = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter withdrawal amount for account {acc}:");
            double amount = double.Parse(Console.ReadLine());

            withdrawalQueue.Enqueue(Tuple.Create(acc, amount));
        }

        // Process withdrawal requests
        Console.WriteLine("\n--- Processing Withdrawals ---");
        while (withdrawalQueue.Count > 0)
        {
            var request = withdrawalQueue.Dequeue();
            int accNumber = request.Item1;
            double amount = request.Item2;

            if (!accounts.ContainsKey(accNumber))
            {
                Console.WriteLine($"Account {accNumber} does not exist!");
                continue;
            }

            if (accounts[accNumber] >= amount)
            {
                accounts[accNumber] -= amount;
                Console.WriteLine($"Withdrawal of ${amount:0.00} from account {accNumber} successful. New balance: ${accounts[accNumber]:0.00}");
            }
            else
            {
                Console.WriteLine($"Insufficient balance in account {accNumber}. Current balance: ${accounts[accNumber]:0.00}");
            }
        }

        // Display final account balances
        Console.WriteLine("\n--- Final Account Balances ---");
        foreach (var pair in accounts)
        {
            Console.WriteLine($"Account {pair.Key} : ${pair.Value:0.00}");
        }
    }
}
