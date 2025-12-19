using System;

class ProfitCalculation
{
    public static void Main(string[] args)
    {
        double costPrice = 129;

        double sellingPrice = 191;

        // Calculate the profit
        double profit = sellingPrice - costPrice;

        // Calculate the profit percentage
        double profitPercentage = (profit / costPrice) * 100;

        Console.WriteLine(
            $"The Cost Price is INR {costPrice} and Selling Price is INR {sellingPrice}\n" +
            $"The Profit is INR {profit} and the Profit Percentage is {profitPercentage}"
        );
    }
}
