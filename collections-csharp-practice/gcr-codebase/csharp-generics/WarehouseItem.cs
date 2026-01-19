using System;
using System.Collections.Generic;

// Base class
abstract class WarehouseItem
{
    public string Name;
}

// Item types
class Electronics : WarehouseItem { }
class Groceries : WarehouseItem { }

// Generic storage class
class Storage<T> where T : WarehouseItem
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }
    }
}

class Program
{
    static void Main()
    {
        Storage<Electronics> storage = new Storage<Electronics>();

        Console.Write("Enter item name: ");
        Electronics e = new Electronics();
        e.Name = Console.ReadLine();

        storage.AddItem(e);
        Console.WriteLine("Stored Items:");
        storage.DisplayItems();
    }
}
