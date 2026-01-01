using System;

class BankAccount
{
    // static: shared across all accounts
    public static string BankName;
    private static int totalAccounts = 0;

    // readonly: cannot be changed after constructor
    public readonly int AccountNumber;

    public string AccountHolderName;

    // constructor using this
    public BankAccount(string name, int accNo)
    {
        this.AccountHolderName = name;
        this.AccountNumber = accNo;
        totalAccounts++;
    }

    // static method
    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    public void DisplayDetails()
    {
        Console.WriteLine(AccountHolderName + " - " + AccountNumber);
    }
}

class BankManagementDemo
{
    static void Main()
    {
        Console.Write("Enter Bank Name: ");
        BankAccount.BankName = Console.ReadLine();

        Console.Write("Enter Account Holder Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        object acc = new BankAccount(name, accNo);

        // is operator for safe checking
        if (acc is BankAccount)
        {
            ((BankAccount)acc).DisplayDetails();
        }

        BankAccount.GetTotalAccounts();
    }
}
