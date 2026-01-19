using System;

// Base product
abstract class Product
{
    public string Name;
    public double Price;
}

class Book : Product { }

class DiscountUtility
{
    // Generic method
    public static void ApplyDiscount<T>(T product, double percent) where T : Product
    {
        product.Price -= product.Price * percent / 100;
    }
}

class Program
{
    static void Main()
    {
        Book book = new Book();

        Console.Write("Enter Book Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Enter Price: ");
        book.Price = double.Parse(Console.ReadLine());

        Console.Write("Enter Discount %: ");
        double d = double.Parse(Console.ReadLine());

        DiscountUtility.ApplyDiscount(book, d);

        Console.WriteLine("Final Price: " + book.Price);
    }
}
