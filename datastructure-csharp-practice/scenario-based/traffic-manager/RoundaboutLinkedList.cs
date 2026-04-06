using System;

namespace TrafficManager;

// Represents a circular linked list for managing vehicles in a roundabout
public class RoundaboutLinkedList
{
    private Node head;       // Points to the first vehicle in the roundabout
    private int capacity;    // Maximum vehicles allowed in the roundabout
    private int count;       // Current number of vehicles

    // Constructor initializes roundabout with a capacity
    public RoundaboutLinkedList(int capacity)
    {
        this.capacity = capacity;
        count = 0;
    }

    // Checks if the roundabout has reached its capacity
    public bool IsFull() => count == capacity;

    // Checks if the roundabout is empty
    public bool IsEmpty() => head == null;

    // Adds a vehicle to the roundabout
    public void AddVehicle(int data)
    {
        if (IsFull())
        {
            Console.WriteLine("Roundabout is FULL");
            return;
        }

        Node newNode = new Node(data);

        if (head == null) // First vehicle
        {
            head = newNode;
            newNode.Next = head; // Circular link
        }
        else
        {
            // Traverse to last node to maintain circular link
            Node temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            temp.Next = newNode;
            newNode.Next = head; // Link back to first node
        }

        count++;
    }

    // Removes a vehicle from the roundabout (front vehicle)
    public void RemoveVehicle()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Roundabout is EMPTY");
            return;
        }

        if (head.Next == head) // Only one vehicle
        {
            head = null;
        }
        else
        {
            // Find the last node to maintain circular link after removal
            Node temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            head = head.Next; // Move head forward
            temp.Next = head; // Update last node's next pointer
        }

        count--;
    }

    // Displays all vehicles currently in the roundabout
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("No vehicles in roundabout");
            return;
        }

        Node temp = head;
        do
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        } while (temp != head);

        Console.WriteLine("(CIRCULAR)");
    }
}
