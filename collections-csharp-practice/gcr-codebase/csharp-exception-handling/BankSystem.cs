using System;

class InsufficientFunds : Exception
{
    public InsufficientFunds(string msg) : base(msg) { }
}

class BankSystem
{
    class BankAccount
    {
        public double Balance { get; private set; }
        public BankAccount(double bal) => Balance = bal;

        public void Withdraw(double amt)
        {
            if (amt < 0) throw new ArgumentException("Invalid amount!");
            if (amt > Balance) throw new InsufficientFunds("Insufficient balance!");
            Balance -= amt;
            Console.WriteLine("Withdrawal successful, balance: " + Balance);
        }
    }

    static void Main()
    {
        Console.Write("Initial balance: ");
        double bal = double.Parse(Console.ReadLine());
        BankAccount acc = new BankAccount(bal);

        Console.Write("Withdrawal amount: ");
        double amt = double.Parse(Console.ReadLine());

        try { acc.Withdraw(amt); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}
