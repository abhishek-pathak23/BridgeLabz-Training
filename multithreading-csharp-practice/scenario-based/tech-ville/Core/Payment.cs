public class Payment
{
    private int paymentId;
    private double amount;

    public Payment(int id, double amount)
    {
        paymentId = id;
        this.amount = amount;
    }

    public override string ToString()
    {
        return $"Payment ID: {paymentId}, Amount: {amount}";
    }
}
