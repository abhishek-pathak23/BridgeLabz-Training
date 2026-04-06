using System;

class InventoryNode
{
    public int ItemId;
    public string ItemName;
    public int Quantity;
    public double Price;
    public InventoryNode Next;

    public InventoryNode(int itemId, string itemName, int quantity, double price)
    {
        ItemId = itemId;
        ItemName = itemName;
        Quantity = quantity;
        Price = price;
        Next = null;
    }
}

class InventoryLinkedList
{
    private InventoryNode head;

    public void AddAtBeginning(int id, string name, int qty, double price)
    {
        InventoryNode newNode = new InventoryNode(id, name, qty, price);
        newNode.Next = head;
        head = newNode;
    }

    public void AddAtEnd(int id, string name, int qty, double price)
    {
        InventoryNode newNode = new InventoryNode(id, name, qty, price);

        if (head == null)
        {
            head = newNode;
            return;
        }

        InventoryNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    public void AddAtPosition(int position, int id, string name, int qty, double price)
    {
        if (position <= 1)
        {
            AddAtBeginning(id, name, qty, price);
            return;
        }

        InventoryNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Invalid position");
            return;
        }

        InventoryNode newNode = new InventoryNode(id, name, qty, price);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    public void RemoveByItemId(int id)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty");
            return;
        }

        if (head.ItemId == id)
        {
            head = head.Next;
            Console.WriteLine("Item removed");
            return;
        }

        InventoryNode temp = head;
        while (temp.Next != null && temp.Next.ItemId != id)
            temp = temp.Next;

        if (temp.Next == null)
            Console.WriteLine("Item not found");
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Item removed");
        }
    }

    public void UpdateQuantity(int id, int qty)
    {
        InventoryNode temp = head;
        while (temp != null)
        {
            if (temp.ItemId == id)
            {
                temp.Quantity = qty;
                Console.WriteLine("Quantity updated");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found");
    }

    public void SearchById(int id)
    {
        InventoryNode temp = head;
        while (temp != null)
        {
            if (temp.ItemId == id)
            {
                DisplayItem(temp);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found");
    }

    public void SearchByName(string name)
    {
        InventoryNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                DisplayItem(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Item not found");
    }

    public void CalculateTotalValue()
    {
        double total = 0;
        InventoryNode temp = head;

        while (temp != null)
        {
            total += temp.Price * temp.Quantity;
            temp = temp.Next;
        }

        Console.WriteLine("Total Inventory Value: " + total);
    }

    public void SortByPrice(bool asc)
    {
        for (InventoryNode i = head; i != null; i = i.Next)
        {
            for (InventoryNode j = i.Next; j != null; j = j.Next)
            {
                if ((asc && i.Price > j.Price) || (!asc && i.Price < j.Price))
                {
                    SwapData(i, j);
                }
            }
        }
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty");
            return;
        }

        InventoryNode temp = head;
        while (temp != null)
        {
            DisplayItem(temp);
            temp = temp.Next;
        }
    }

    private void SwapData(InventoryNode a, InventoryNode b)
    {
        (a.ItemId, b.ItemId) = (b.ItemId, a.ItemId);
        (a.ItemName, b.ItemName) = (b.ItemName, a.ItemName);
        (a.Quantity, b.Quantity) = (b.Quantity, a.Quantity);
        (a.Price, b.Price) = (b.Price, a.Price);
    }

    private void DisplayItem(InventoryNode i)
    {
        Console.WriteLine($"{i.ItemId} {i.ItemName} Qty:{i.Quantity} Price:{i.Price}");
    }
}

class InventoryManagement
{
    static void Main()
    {
        InventoryLinkedList inventory = new InventoryLinkedList();

        while (true)
        {
            Console.WriteLine("\n1 Add At Beginning");
            Console.WriteLine("2 Add At End");
            Console.WriteLine("3 Add At Position");
            Console.WriteLine("4 Remove By ID");
            Console.WriteLine("5 Update Quantity");
            Console.WriteLine("6 Search By ID");
            Console.WriteLine("7 Search By Name");
            Console.WriteLine("8 Display All");
            Console.WriteLine("9 Total Value");
            Console.WriteLine("10 Sort By Price");
            Console.WriteLine("0 Exit");

            int ch = int.Parse(Console.ReadLine() ?? "0");

            if (ch == 0) break;

            int id, qty, pos;
            double price;
            string name;

            switch (ch)
            {
                case 1:
                    Console.Write("ID: "); id = int.Parse(Console.ReadLine());
                    Console.Write("Name: "); name = Console.ReadLine();
                    Console.Write("Qty: "); qty = int.Parse(Console.ReadLine());
                    Console.Write("Price: "); price = double.Parse(Console.ReadLine());
                    inventory.AddAtBeginning(id, name, qty, price);
                    break;

                case 2:
                    Console.Write("ID: "); id = int.Parse(Console.ReadLine());
                    Console.Write("Name: "); name = Console.ReadLine();
                    Console.Write("Qty: "); qty = int.Parse(Console.ReadLine());
                    Console.Write("Price: "); price = double.Parse(Console.ReadLine());
                    inventory.AddAtEnd(id, name, qty, price);
                    break;

                case 3:
                    Console.Write("Position: "); pos = int.Parse(Console.ReadLine());
                    Console.Write("ID: "); id = int.Parse(Console.ReadLine());
                    Console.Write("Name: "); name = Console.ReadLine();
                    Console.Write("Qty: "); qty = int.Parse(Console.ReadLine());
                    Console.Write("Price: "); price = double.Parse(Console.ReadLine());
                    inventory.AddAtPosition(pos, id, name, qty, price);
                    break;

                case 4:
                    Console.Write("ID: "); id = int.Parse(Console.ReadLine());
                    inventory.RemoveByItemId(id);
                    break;

                case 5:
                    Console.Write("ID: "); id = int.Parse(Console.ReadLine());
                    Console.Write("New Qty: "); qty = int.Parse(Console.ReadLine());
                    inventory.UpdateQuantity(id, qty);
                    break;

                case 6:
                    Console.Write("ID: "); id = int.Parse(Console.ReadLine());
                    inventory.SearchById(id);
                    break;

                case 7:
                    Console.Write("Name: "); name = Console.ReadLine();
                    inventory.SearchByName(name);
                    break;

                case 8:
                    inventory.DisplayAll();
                    break;

                case 9:
                    inventory.CalculateTotalValue();
                    break;

                case 10:
                    inventory.SortByPrice(true);
                    inventory.DisplayAll();
                    break;
            }
        }
    }
}
