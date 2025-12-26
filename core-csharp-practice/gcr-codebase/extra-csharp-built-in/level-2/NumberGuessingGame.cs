using System;

class NumberGuessingGame
{
    // Generates a random guess between given limits
    static int GenerateGuess(int low, int high)
    {
        Random rand = new Random();
        return rand.Next(low, high + 1);
    }

    // Gets feedback from user
    static string GetUserFeedback()
    {
        Console.Write("Is the guess High, Low, or Correct? ");
        return Console.ReadLine()!.ToLower();
    }

    static void Main()
    {
        int low = 1, high = 100;
        string feedback;

        Console.WriteLine("Think a number between 1 and 100.");

        do
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Computer Guess: " + guess);

            feedback = GetUserFeedback();

            if (feedback == "high")
                high = guess - 1;
            else if (feedback == "low")
                low = guess + 1;

        } while (feedback != "correct");

        Console.WriteLine("Number guessed successfully!");    //Giving output
    }
}
