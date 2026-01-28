using System;

public class BankWallet
{
    private double balance = 0;

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
            throw new InvalidOperationException("Insufficient funds");

        balance -= amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}