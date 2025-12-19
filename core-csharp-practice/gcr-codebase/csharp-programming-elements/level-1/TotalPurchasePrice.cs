using System;

class TotalPurchasePrice
{
    public static void Main(string[] args)
    {
        double unitPrice;
        int quantity;

        // Read unit price and quantity from user input
        unitPrice = Convert.ToDouble(Console.ReadLine());
        quantity = Convert.ToInt32(Console.ReadLine());

        // Calculate total purchase price
        double totalPrice = unitPrice * quantity;

        // Display the result
        Console.WriteLine(
            $"The total purchase price is INR {totalPrice} if the quantity {quantity} and unit price is INR {unitPrice}"
        );
    }
}
