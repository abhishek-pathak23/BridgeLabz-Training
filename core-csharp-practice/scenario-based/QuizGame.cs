// SUMMARY:
//Uses two string arrays to store correct answers and student answers.
//Compares answers case-insensitively, prints correct/incorrect feedback for each question, and calculates the score.
//Calculates percentage and displays a pass/fail result.



using System;

class QuizGame
{
    // Method to calculate score
    static int CalculateScore(string[] correct, string[] student)
    {
        int score = 0;

        for (int i = 0; i < correct.Length; i++)
        {
            if (correct[i].Equals(student[i], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Question {i + 1}: Correct");
                score++;
            }
            else
            {
                Console.WriteLine($"Question {i + 1}: Incorrect");
            }
        }

        return score;
    }

    static void Main()
    {
        // Correct answers
        string[] correctAnswers = { "A", "B", "C", "D", "A", "B", "C", "D", "A", "B" };

        // Student answers (example)
        string[] studentAnswers = new string[10];

        Console.WriteLine("Enter your answers for 10 questions (A/B/C/D):");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Question {i + 1}: ");
            studentAnswers[i] = Console.ReadLine();
        }

        Console.WriteLine("\n--- Quiz Feedback ---");

        int totalScore = CalculateScore(correctAnswers, studentAnswers);

        // Calculate percentage
        double percentage = (totalScore * 100.0) / correctAnswers.Length;

        Console.WriteLine($"\nTotal Score: {totalScore} / {correctAnswers.Length}");
        Console.WriteLine($"Percentage: {percentage}%");

        // Pass / Fail (pass = 50% or more)
        if (percentage >= 50)
            Console.WriteLine("Result: Pass ");
        else
            Console.WriteLine("Result: Fail ");
    }
}
