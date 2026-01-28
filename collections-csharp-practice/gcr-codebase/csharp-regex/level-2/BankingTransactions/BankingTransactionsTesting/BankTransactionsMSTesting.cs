using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class BankWalletTests
{
    [TestMethod]
    public void Deposit_UpdatesBalance()
    {
        BankWallet wallet = new BankWallet();
        wallet.Deposit(500);
        Assert.AreEqual(500, wallet.GetBalance());
    } // ✅ method closed properly

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Withdraw_InsufficientFunds_Fails()
    {
        BankWallet wallet = new BankWallet();
        wallet.Withdraw(100);
    }
}