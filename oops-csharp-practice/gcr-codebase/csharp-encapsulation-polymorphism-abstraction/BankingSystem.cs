using System;

// Interface for loan-related features
interface ILoanable
{
    void ApplyForLoan();
    double CalculateLoanEligibility();
}

// Abstract class for common bank account structure
abstract class BankAccount
{
    private string accountNumber;
    private string holderName;
    protected double balance;

    public string AccountNumber
    {
        get => accountNumber;
        set => accountNumber = value;
    }

    public string HolderName
    {
        get => holderName;
        set => holderName = value;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public abstract double CalculateInterest();
}

// Savings account implementation
class SavingsAccount : BankAccount, ILoanable
{
    public override double CalculateInterest()
    {
        return balance * 0.04;
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Loan Applied Successfully");
    }

    public double CalculateLoanEligibility()
    {
        return balance * 5;
    }
}

// Program execution starts here
class BankingSystem
{
    static void Main()
    {
        SavingsAccount account = new SavingsAccount();
        bool exit = false;

        Console.Write("Enter Account Number: ");
        account.AccountNumber = Console.ReadLine();

        Console.Write("Enter Holder Name: ");
        account.HolderName = Console.ReadLine();

        while (!exit)
        {
            Console.WriteLine("\n--- Banking Menu ---");
            Console.WriteLine("1. Deposit Amount");
            Console.WriteLine("2. Calculate Interest");
            Console.WriteLine("3. Check Loan Eligibility");
            Console.WriteLine("4. Apply for Loan");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Deposit Amount: ");
                    double amount = double.Parse(Console.ReadLine());
                    account.Deposit(amount);
                    Console.WriteLine("Amount Deposited Successfully");
                    break;

                case 2:
                    Console.WriteLine($"Interest Amount: {account.CalculateInterest()}");
                    break;

                case 3:
                    Console.WriteLine($"Loan Eligibility: {account.CalculateLoanEligibility()}");
                    break;

                case 4:
                    account.ApplyForLoan();
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Thank you for using the Banking System");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
