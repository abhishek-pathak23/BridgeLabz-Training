using System;
using System.Collections.Generic;

class QueueUsingStacks
{
    // Stack for enqueue operation
    static Stack<int> stack1 = new Stack<int>();

    // Stack for dequeue operation
    static Stack<int> stack2 = new Stack<int>();

    // Enqueue element into queue
    static void Enqueue(int value)
    {
        // Push element into first stack
        stack1.Push(value);
    }

    // Dequeue element from queue
    static int Dequeue()
    {
        // If both stacks are empty, queue is empty
        if (stack1.Count == 0 && stack2.Count == 0)
        {
            Console.WriteLine("Queue is empty");
            return -1;
        }

        // Transfer elements from stack1 to stack2 if stack2 is empty
        if (stack2.Count == 0)
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }

        // Pop from second stack (FIFO behavior)
        return stack2.Pop();
    }

    static void Main()
    {
        Enqueue(10);
        Enqueue(20);
        Enqueue(30);

        Console.WriteLine(Dequeue()); // 10
        Console.WriteLine(Dequeue()); // 20
    }
}
