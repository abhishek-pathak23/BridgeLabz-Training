using System;
using System.Collections.Generic;

namespace BankManagement
{
    // Customer class represents a bank customer
    class Customer
    {
        public string Name { get; set; }
        public List<double> Accounts { get; set; } // Each customer can have multiple accounts

        public Customer(string name)
        {
            Name = name;
            Accounts = new List<double>();
        }

        // Add a new account with initial balance
        public void AddAccount(double balance)
        {
            Accounts.Add(balance);
            Console.WriteLine($"Account opened for {Name} with balance {balance}");
        }

        // View all balances
        public void ViewBalances()
        {
            Console.WriteLine($"\n{Name}'s Accounts:");
            for (int i = 0; i < Accounts.Count; i++)
                Console.WriteLine($"Account {i + 1}: {Accounts[i]}");
        }
    }

    // Bank class associates with Customers
    class Bank
    {
        public string BankName { get; set; }
        public List<Customer> Customers { get; set; }

        public Bank(string name)
        {
            BankName = name;
            Customers = new List<Customer>();
        }

        // Open account for a customer
        public void OpenAccount(Customer customer, double initialBalance)
        {
            if (!Customers.Contains(customer))
                Customers.Add(customer);

            customer.AddAccount(initialBalance);
            Console.WriteLine($"Account opened in {BankName} for {customer.Name}.\n");
        }
    }

    class BankAccount
    {
        static void Main()
        {
            Console.WriteLine("Enter Bank Name:");
            string bankName = Console.ReadLine();
            Bank bank = new Bank(bankName);

            Console.WriteLine("Enter number of customers:");
            int numCustomers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCustomers; i++)
            {
                Console.WriteLine($"\nEnter name of Customer {i + 1}:");
                string custName = Console.ReadLine();
                Customer customer = new Customer(custName);

                Console.WriteLine($"How many accounts does {custName} want to open?");
                int accounts = int.Parse(Console.ReadLine());

                for (int j = 0; j < accounts; j++)
                {
                    Console.WriteLine($"Enter initial balance for account {j + 1}:");
                    double balance = double.Parse(Console.ReadLine());
                    bank.OpenAccount(customer, balance);
                }

                customer.ViewBalances();
            }

            Console.WriteLine("\nAll customer accounts in the bank:");
            foreach (var cust in bank.Customers)
            {
                cust.ViewBalances();
            }
        }
    }
}
