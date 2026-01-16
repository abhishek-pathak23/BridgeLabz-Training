// Manages the waiting queue for vehicles using a simple array-based queue
class WaitingQueueUtility
{
    int[] queue;       // Array to store waiting vehicles
    int front = 0;     // Index of the first element in the queue
    int rear = -1;     // Index of the last element
    int size = 0;      // Current number of vehicles in the queue

    // Initialize the queue with a given capacity
    public WaitingQueueUtility(int capacity)
    {
        queue = new int[capacity];
    }

    // Check if the queue is empty
    public bool IsEmpty() => size == 0;

    // Check if the queue is full
    public bool IsFull() => size == queue.Length;

    // Add a vehicle to the rear of the queue
    public void Enqueue(int data)
    {
        if (IsFull())
        {
            Console.WriteLine("Waiting queue full");
            return;
        }
        queue[++rear] = data;
        size++;
    }

    // Remove a vehicle from the front of the queue
    public int Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Waiting queue empty");
            return -1; // Sentinel value indicating no vehicle
        }
        size--;
        return queue[front++];
    }

    // Display all vehicles currently in the waiting queue
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("No waiting vehicles");
            return;
        }

        Console.Write("Waiting Queue: ");
        for (int i = front; i <= rear; i++)
            Console.Write(queue[i] + " ");
        Console.WriteLine();
    }
}
