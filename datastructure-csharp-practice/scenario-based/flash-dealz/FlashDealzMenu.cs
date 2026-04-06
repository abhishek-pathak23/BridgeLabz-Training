using System;

namespace FlashDealz;

public class FlashDealzMenu
{
    Product[] products = new Product[50];
    int count = 0;

    // Interface reference (Abstraction)
    IProductSorter sorter = new ProductUtility();

    public void Start()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- FLASH DEALZ MENU ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Sort by Discount");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;

                case 2:
                    //  Correct interface method call
                    sorter.SortProducts(products, count);
                    Console.WriteLine("Products sorted by discount (Quick Sort)");
                    break;

                case 3:
                    Display();
                    break;

                case 0:
                    Console.WriteLine("Exiting FlashDealz...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 0);
    }

    private void AddProduct()
    {
        if (count >= products.Length)
        {
            Console.WriteLine("Product list full");
            return;
        }

        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Discount %: ");
        int dis = int.Parse(Console.ReadLine());

        products[count++] = new Product(id, dis);
        Console.WriteLine("Product added successfully");
    }

    private void Display()
    {
        if (count == 0)
        {
            Console.WriteLine("No products available");
            return;
        }

        Console.WriteLine("\n--- PRODUCT LIST ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Product {products[i].Id} - {products[i].Discount}%");
        }
    }
}
