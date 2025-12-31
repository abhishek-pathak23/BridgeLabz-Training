using System;

// Stores information related to a bank account
class BankAccount
{
    public string AccNumber;
    public string CustomerName;
    public double Funds;
}

// Manages account creation and lookup
class BankOperations
{
    BankAccount[] records = new BankAccount[10];
    int recordCount = 0;

    // Used by admin to add a new account
    public void OpenAccount()
    {
        if (recordCount == records.Length)
        {
            Console.WriteLine("Account storage is full.");
            return;
        }

        BankAccount account = new BankAccount();

        Console.Write("Enter Account Number: ");
        account.AccNumber = Console.ReadLine();

        Console.Write("Enter Customer Name: ");
        account.CustomerName = Console.ReadLine();

        Console.Write("Enter Initial Deposit: ");
        account.Funds = Convert.ToDouble(Console.ReadLine());

        records[recordCount] = account;
        recordCount++;

        Console.WriteLine("Account created successfully.");
    }

    // Retrieves account based on account number
    public BankAccount SearchAccount(string number)
    {
        for (int i = 0; i < recordCount; i++)
        {
            if (records[i].AccNumber == number)
                return records[i];
        }
        return null;
    }
}

// Base class representing a system user
class SystemUser
{
    protected BankOperations operations;

    public SystemUser(BankOperations ops)
    {
        operations = ops;
    }
}

// Derived class for customer-related actions
class Client : SystemUser
{
    public Client(BankOperations ops) : base(ops) { }

    public void ClientMenu()
    {
        Console.Write("Enter Account Number: ");
        string number = Console.ReadLine();

        BankAccount account = operations.SearchAccount(number);

        if (account == null)
        {
            Console.WriteLine("Account does not exist.");
            return;
        }

        int choice;
        do
        {
            Console.WriteLine("\n--- CLIENT MENU ---");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Amount");
            Console.WriteLine("3. Withdraw Amount");
            Console.WriteLine("4. Logout");
            Console.Write("Select option: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Balance Available: " + account.Funds);
                    break;

                case 2:
                    Console.Write("Enter deposit amount: ");
                    double add = Convert.ToDouble(Console.ReadLine());

                    if (add > 0)
                    {
                        account.Funds += add;
                        Console.WriteLine("Deposit completed.");
                    }
                    else
                        Console.WriteLine("Invalid amount.");
                    break;

                case 3:
                    Console.Write("Enter withdrawal amount: ");
                    double deduct = Convert.ToDouble(Console.ReadLine());

                    if (deduct <= 0)
                        Console.WriteLine("Invalid amount.");
                    else if (deduct > account.Funds)
                        Console.WriteLine("Insufficient balance.");
                    else
                    {
                        account.Funds -= deduct;
                        Console.WriteLine("Withdrawal successful.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Client logged out.");
                    break;

                default:
                    Console.WriteLine("Incorrect selection.");
                    break;
            }

        } while (choice != 4);
    }
}

// Derived class for admin-related actions
class Administrator : SystemUser
{
    public Administrator(BankOperations ops) : base(ops) { }

    public void AdministratorMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- ADMINISTRATOR MENU ---");
            Console.WriteLine("1. Open Account");
            Console.WriteLine("2. View Account Details");
            Console.WriteLine("3. Logout");
            Console.Write("Select option: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    operations.OpenAccount();
                    break;

                case 2:
                    Console.Write("Enter Account Number: ");
                    string number = Console.ReadLine();

                    BankAccount account = operations.SearchAccount(number);

                    if (account == null)
                        Console.WriteLine("Account not found.");
                    else
                    {
                        Console.WriteLine("Customer Name: " + account.CustomerName);
                        Console.WriteLine("Account Number: " + account.AccNumber);
                        Console.WriteLine("Balance: " + account.Funds);
                    }
                    break;

                case 3:
                    Console.WriteLine("Administrator logged out.");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        } while (choice != 3);
    }
}

// Program entry point
class BankingSystemSys
{
    static void Main()
    {
        BankOperations ops = new BankOperations();

        Administrator admin = new Administrator(ops);
        Client client = new Client(ops);

        int role;
        do
        {
            Console.WriteLine("\n=== BANK OF IGLAS ===");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Client");
            Console.WriteLine("3. Exit");
            Console.Write("Choose role: ");

            role = Convert.ToInt32(Console.ReadLine());

            switch (role)
            {
                case 1:
                    admin.AdministratorMenu();
                    break;

                case 2:
                    client.ClientMenu();
                    break;

                case 3:
                    Console.WriteLine("System terminated.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (role != 3);
    }
}
