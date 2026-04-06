using System;
using System.Collections.Generic;

class SortStackUsingRecursion
{
    // Method to sort the entire stack
    static void SortStack(Stack<int> stack)
    {
        // Base case: if stack is empty, return
        if (stack.Count == 0)
            return;

        // Step 1: Remove top element
        int top = stack.Pop();

        // Step 2: Recursively sort remaining stack
        SortStack(stack);

        // Step 3: Insert the removed element in sorted order
        InsertInSortedOrder(stack, top);
    }

    // Method to insert an element into the stack in sorted order
    static void InsertInSortedOrder(Stack<int> stack, int value)
    {
        // If stack is empty OR top element is smaller or equal
        if (stack.Count == 0 || stack.Peek() <= value)
        {
            stack.Push(value);
            return;
        }

        // Remove top element
        int temp = stack.Pop();

        // Recursively insert value
        InsertInSortedOrder(stack, value);

        // Put back the removed element
        stack.Push(temp);
    }

    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        // Push elements into stack
        stack.Push(3);
        stack.Push(1);
        stack.Push(2);

        Console.WriteLine("Stack before sorting:");
        foreach (int item in stack)
            Console.Write(item + " ");

        // Sort the stack
        SortStack(stack);

        Console.WriteLine("\n\nStack after sorting:");
        foreach (int item in stack)
            Console.Write(item + " ");
    }
}
