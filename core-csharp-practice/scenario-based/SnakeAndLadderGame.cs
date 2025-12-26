using System;
using System.Collections.Generic;

class SnakeAndLadderGame
{
    // Random object used for dice roll
    static Random random = new Random();

    // Dictionary to store snakes and ladders positions
    static Dictionary<int, int> snakesAndLadders = new Dictionary<int, int>()
    {
        { 3, 22 },   // ladder
        { 5, 8 },    // ladder
        { 11, 26 },  // ladder
        { 20, 29 },  // ladder

        { 27, 1 },   // snake
        { 21, 9 },   // snake
        { 17, 4 },   // snake
        { 19, 7 }    // snake
    };

    static void Main()
    {
        Console.WriteLine("=== Snake & Ladder Game ===");

        int playerCount = GetPlayerCount();

        string[] players = new string[playerCount];
        int[] positions = new int[playerCount];

        // Taking player names
        for (int i = 0; i < playerCount; i++)
        {
            Console.Write($"Enter name for Player {i + 1}: ");
            players[i] = Console.ReadLine()!;
            positions[i] = 0;
        }

        bool gameWon = false;

        // Game loop
        while (!gameWon)
        {
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"\n{players[i]}'s turn. Press ENTER to roll dice.");
                Console.ReadLine();

                int diceValue = RollDice();
                int oldPosition = positions[i];

                Console.WriteLine($"Dice rolled: {diceValue}");

                // Skip move if it crosses 100
                if (oldPosition + diceValue > 100)
                {
                    Console.WriteLine("Move skipped! Dice value exceeds 100.");
                    continue;
                }

                int newPosition = MovePlayer(oldPosition, diceValue);
                newPosition = ApplySnakeOrLadder(newPosition);

                positions[i] = newPosition;

                Console.WriteLine(
                    $"Position: {oldPosition} → {newPosition}"
                );

                // Ternary operator usage
                string status = newPosition == 100 ? " WINNER!" : "Game continues";
                Console.WriteLine(status);

                if (CheckWin(newPosition))
                {
                    Console.WriteLine($"\n {players[i]} has won the game!");
                    gameWon = true;
                    break;
                }
            }
        }

        Console.WriteLine("\nGame Over. Thanks for playing!");
    }

    // Gets valid number of players
    static int GetPlayerCount()
    {
        int count;

        do
        {
            Console.Write("Enter number of players (2 to 4): ");
            count = int.Parse(Console.ReadLine()!);
        }
        while (count < 2 || count > 4);

        return count;
    }

    // Rolls dice between 1 and 6
    static int RollDice()
    {
        return random.Next(1, 7);
    }

    // Moves player based on dice value
    static int MovePlayer(int currentPosition, int diceValue)
    {
        return currentPosition + diceValue;
    }

    // Applies snake or ladder logic
    static int ApplySnakeOrLadder(int position)
    {
        if (snakesAndLadders.ContainsKey(position))
        {
            int newPosition = snakesAndLadders[position];

            if (newPosition > position)
                Console.WriteLine(" Ladder found! Moving up.");
            else
                Console.WriteLine(" Snake bite! Sliding down.");

            return newPosition;
        }

        return position;
    }

    // Checks if player has won
    static bool CheckWin(int position)
    {
        return position == 100;
    }
}
