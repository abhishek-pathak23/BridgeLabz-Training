using System;
using ExamProctor.Utility; // Provides exam-related helper functions

namespace ExamProctor.Menu
{
    public class ExamMenu
    {
        // Utility object that handles exam operations and logic
        private readonly ExamProctorUtility exam = new();

        public void Show()
        {
            // Keeps the menu running until the exam is submitted
            while (true)
            {
                PrintMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        VisitQuestion(); // Allows the user to navigate to a question
                        break;

                    case "2":
                        SubmitAnswer(); // Stores the user's answer for a question
                        break;

                    case "3":
                        exam.ShowNavigationHistory(); // Displays visited questions
                        break;

                    case "4":
                        // Ends the exam and displays the final score
                        int score = exam.CalculateScore();
                        Console.WriteLine($"Final Score: {score}");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void PrintMenu()
        {
            // Displays available actions to the user
            Console.WriteLine("\n--- Exam Proctor Menu ---");
            Console.WriteLine("1. Visit Question");
            Console.WriteLine("2. Submit Answer");
            Console.WriteLine("3. View Navigation History");
            Console.WriteLine("4. Submit Exam");
            Console.Write("Choice: ");
        }

        private void VisitQuestion()
        {
            Console.Write("Enter Question ID: ");
            // Validates numeric input before processing
            if (int.TryParse(Console.ReadLine(), out int qId))
            {
                exam.VisitQuestion(qId);
                Console.WriteLine($"Visited Question {qId}");
            }
            else
            {
                Console.WriteLine("Invalid Question ID.");
            }
        }

        private void SubmitAnswer()
        {
            Console.Write("Enter Question ID: ");
            // Stops execution if the question ID is not valid
            if (!int.TryParse(Console.ReadLine(), out int qId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter Answer (A/B/C/D): ");
            string answer = Console.ReadLine() ?? "";

            // Saves the answer only if it meets validation rules
            bool success = exam.SubmitAnswer(qId, answer);
            Console.WriteLine(success ? "Answer saved." : "Invalid answer.");
        }
    }
}
