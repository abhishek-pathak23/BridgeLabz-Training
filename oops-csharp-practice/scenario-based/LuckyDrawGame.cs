using System;

class LuckyDraw
{
    // Method to run the lucky draw
    public void Play()
    {
        while (true)
        {
            Console.Write("Enter lucky number (-1 to stop): ");
            int num;

            // Check if input is a valid number
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input! Try again.");
                continue; // skip this turn
            }

            // Exit condition
            if (num == -1)
            {
                Console.WriteLine("Lucky Draw Finished");
                break;
            }

            // Winning condition
            if (num % 3 == 0 && num % 5 == 0)
            {
                Console.WriteLine(" You won a gift!");
            }
            else
            {
                Console.WriteLine("No gift this time.");
            }
        }
    }
}

class LuckyDrawGame
{
    static void Main()
    {
        // Create object and start lucky draw
        LuckyDraw draw = new LuckyDraw();
        draw.Play();
    }
}