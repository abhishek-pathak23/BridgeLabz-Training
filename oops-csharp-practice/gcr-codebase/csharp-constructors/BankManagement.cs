using System;

class BankAccount
{
    // Can be accessed from anywhere
    public int accountNumber;

    // Can be accessed in this class and child classes
    protected string accountHolder;

    // Can be accessed only inside this class
    private double balance;

    // Constructor to initialize account details
    public BankAccount(int accNo, string holder)
    {
        accountNumber = accNo;
        accountHolder = holder;
    }

    // Method to set account balance
    public void SetBalance(double amount)
    {
        balance = amount;
    }

    // Method to get account balance
    public double GetBalance()
    {
        return balance;
    }
}

// Child class
class SavingsAccount : BankAccount
{
    // Calling base class constructor
    public SavingsAccount(int accNo, string holder)
        : base(accNo, holder)
    {
    }

    // Display account details
    public void DisplayDetails()
    {
        Console.WriteLine("\nAccount Details");
        Console.WriteLine("Account No : " + accountNumber);   // public
        Console.WriteLine("Holder     : " + accountHolder);  // protected
    }
}

class BankManagement
{
    static void Main()
    {
        // Taking input from user
        Console.Write("Enter Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        Console.Write("Enter Account Holder Name: ");
        string holder = Console.ReadLine();

        Console.Write("Enter Balance: ");
        double balance = double.Parse(Console.ReadLine());

        // Creating object of child class
        SavingsAccount account = new SavingsAccount(accNo, holder);

        // Setting balance using public method
        account.SetBalance(balance);

        // Displaying account information
        account.DisplayDetails();
        Console.WriteLine("Balance    : " + account.GetBalance());
    }
}
