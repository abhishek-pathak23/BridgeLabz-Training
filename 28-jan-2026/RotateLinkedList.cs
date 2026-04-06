// Rotate the linked list by k nodes
using System;

class Node
{
    public int data;
    public Node? next;

    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

class LinkedList
{
    private Node? head;

    public void AddLast(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    public void Rotate(int k)
    {
        if (head == null || k == 0)
            return;

        Node temp = head;
        int length = 1;

        while (temp.next != null)
        {
            temp = temp.next;
            length++;
        }

        temp.next = head;

        k = k % length;
        int stepsToNewHead = length - k;

        Node newTail = temp;
        while (stepsToNewHead-- > 0)
        {
            newTail = newTail.next!;
        }

        head = newTail.next;
        newTail.next = null;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.data + " -> ");
            temp = temp.next;
        }
        Console.WriteLine("NULL");
    }
}

class RotateLinkedList
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        Console.Write("Enter number of nodes: ");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter node {i + 1}: ");
            int value = int.Parse(Console.ReadLine()!);
            list.AddLast(value);
        }

        Console.Write("Enter the value of K for rotation: ");
        int k = int.Parse(Console.ReadLine()!);

        Console.WriteLine("\nOriginal List:");
        list.Display();

        list.Rotate(k);

        Console.WriteLine("\nRotated List:");
        list.Display();

        Console.WriteLine("\nPress enter to exit the program");
        Console.ReadLine();
    }
}
