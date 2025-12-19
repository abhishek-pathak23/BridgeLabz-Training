using System;

class CourseFeeDiscount
{
    public static void Main(string[] args)
    {
        double fee = 125000;
        double discountPercent = 10;

        // Calculate discount amount
        double discountAmount = (fee * discountPercent) / 100;

        // Calculate final fee after discount
        double finalFee = fee - discountAmount;

        Console.WriteLine(
            $"The discount amount is INR {discountAmount} and final discounted fee is INR {finalFee}"
        );
    }
}
