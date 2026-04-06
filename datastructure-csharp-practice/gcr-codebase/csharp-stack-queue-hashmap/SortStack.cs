using System;
using System.Collections.Generic;

class SortStack
{
    // Method to sort the stack
    static void Sort(Stack<int> stack)
    {
        // Base case: stack is empty
        if (stack.Count == 0)
            return;

        // Remove top element
        int temp = stack.Pop();

        // Sort remaining stack
        Sort(stack);

        // Insert element in sorted order
        InsertSorted(stack, temp);
    }

    // Insert element at correct position
    static void InsertSorted(Stack<int> stack, int value)
    {
        if (stack.Count == 0 || stack.Peek() <= value)
        {
            stack.Push(value);
            return;
        }

        int temp = stack.Pop();
        InsertSorted(stack, value);
        stack.Push(temp);
    }

    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(30);
        stack.Push(10);
        stack.Push(20);

        Sort(stack);

        // Print sorted stack
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}
