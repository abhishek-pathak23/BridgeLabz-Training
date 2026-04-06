using System;

class InvoiceTool
{
    // Breaks the input string into individual invoice items
    public static string[] ExtractItems(string data)
    {
        string[] items = data.Split(',');
        return items;
    }

    // Calculates total amount from invoice items
    public static int CalculateTotal(string[] items)
    {
        int sum = 0;

        for (int i = 0; i < items.Length; i++)
        {
            string item = items[i];

            int dashIndex = item.IndexOf('-');
            if (dashIndex == -1)
                continue;

            string pricePart = item.Substring(dashIndex + 1);
            pricePart = pricePart.Replace("INR", "").Trim();

            int price = Convert.ToInt32(pricePart);
            sum += price;
        }

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Enter invoice description:");
        string inputData = Console.ReadLine() ?? "";

        string[] invoiceItems = ExtractItems(inputData);

        Console.WriteLine("\nInvoice Details:");
        for (int i = 0; i < invoiceItems.Length; i++)
        {
            Console.WriteLine(invoiceItems[i].Trim());
        }

        int totalAmount = CalculateTotal(invoiceItems);
        Console.WriteLine("\nTotal Payable Amount: " + totalAmount + " INR");
    }
}
