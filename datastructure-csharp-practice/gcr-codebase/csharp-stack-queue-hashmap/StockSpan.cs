using System;
using System.Collections.Generic;

class StockSpan
{
    static void CalculateSpan(int[] prices)
    {
        Stack<int> stack = new Stack<int>();
        int[] span = new int[prices.Length];

        // First day span is always 1
        stack.Push(0);
        span[0] = 1;

        for (int i = 1; i < prices.Length; i++)
        {
            // Remove smaller prices from stack
            while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
            {
                stack.Pop();
            }

            span[i] = (stack.Count == 0) ? i + 1 : i - stack.Peek();
            stack.Push(i);
        }

        // Print result
        for (int i = 0; i < span.Length; i++)
        {
            Console.Write(span[i] + " ");
        }
    }

    static void Main()
    {
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
        CalculateSpan(prices);
    }
}
