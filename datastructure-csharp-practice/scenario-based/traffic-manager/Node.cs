namespace TrafficManager;

// Represents a single vehicle in the roundabout (node of circular linked list)
public class Node
{
    // Vehicle number stored in this node
    public int Data;

    // Reference to the next vehicle in the circular list
    public Node Next;

    // Constructor to initialize the vehicle node
    public Node(int data)
    {
        Data = data;
        Next = null; // Initially, next points to null
    }
}
