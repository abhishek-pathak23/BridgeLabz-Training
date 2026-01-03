using System;

// Base class BankAccount
class BankAccount
{
    // Bank account number
    public int AccountNumber;

    // Current balance in the account
    public double Balance;
}

// Derived class SavingsAccount inherits from BankAccount
class SavingsAccount : BankAccount
{
    // Interest rate for savings account
    public double InterestRate;

    // Method to display savings account details
    public void Display()
    {
        Console.WriteLine("Savings Account");
        Console.WriteLine($"Interest Rate: {InterestRate}");
    }
}

// Main class
class BankAccountSys
{
    static void Main()
    {
        // Create object of SavingsAccount class
        SavingsAccount s = new SavingsAccount();

        // Take account number input from user
        Console.Write("Enter Account Number: ");
        s.AccountNumber = int.Parse(Console.ReadLine());

        // Take balance input from user
        Console.Write("Enter Balance: ");
        s.Balance = double.Parse(Console.ReadLine());

        // Take interest rate input from user
        Console.Write("Enter Interest Rate: ");
        s.InterestRate = double.Parse(Console.ReadLine());

        // Display savings account information
        s.Display();
    }
}
