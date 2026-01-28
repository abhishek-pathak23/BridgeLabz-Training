using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    Program account;

    [SetUp]
    public void Setup()
    {
        account = new Program(1000m);
    }

    [Test]
    public void Test_Deposit_ValidAmount()
    {
        account.Deposit(500m);
        Assert.AreEqual(1500m, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Assert.Throws<Exception>(() => account.Deposit(-100m));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        account.Withdraw(300m);
        Assert.AreEqual(700m, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Assert.Throws<Exception>(() => account.Withdraw(2000m));
    }
}
