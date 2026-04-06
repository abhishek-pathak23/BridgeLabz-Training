using System;

class CircularTour
{
    static int FindStart(int[] petrol, int[] distance)
    {
        int balance = 0, deficit = 0, start = 0;

        for (int i = 0; i < petrol.Length; i++)
        {
            balance += petrol[i] - distance[i];

            // If balance becomes negative
            if (balance < 0)
            {
                deficit += balance;
                start = i + 1;
                balance = 0;
            }
        }

        return (balance + deficit >= 0) ? start : -1;
    }

    static void Main()
    {
        int[] petrol = { 6, 3, 7 };
        int[] distance = { 4, 6, 3 };

        Console.WriteLine("Start Index: " + FindStart(petrol, distance));
    }
}
