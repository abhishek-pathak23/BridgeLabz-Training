using System;
using System.Collections.Generic;
using ExamProctor.Interface; // Interface defining required exam operations

namespace ExamProctor.Utility
{
    public class ExamProctorUtility : IExamProctor
    {
        // Tracks the order in which questions are visited
        private readonly Stack<int> navigationStack = new();

        // Stores answers submitted by the student (QuestionId → Answer)
        private readonly Dictionary<int, string> studentAnswers = new();

        // Holds the correct answers for evaluation
        private readonly Dictionary<int, string> answerKey = new();

        public ExamProctorUtility()
        {
            // Initializes the correct answers at object creation
            LoadAnswerKey();
        }

        private void LoadAnswerKey()
        {
            // Hardcoded answer key for the exam
            answerKey[1] = "B";
            answerKey[2] = "D";
            answerKey[3] = "B";
            answerKey[4] = "A";
        }

        public void VisitQuestion(int questionId)
        {
            // Records each visited question for navigation tracking
            navigationStack.Push(questionId);
        }

        public bool SubmitAnswer(int questionId, string answer)
        {
            // Rejects empty or invalid input
            if (string.IsNullOrWhiteSpace(answer))
                return false;

            // Converts input to uppercase for consistent comparison
            studentAnswers[questionId] = answer.ToUpper();
            return true;
        }

        public int CalculateScore()
        {
            int score = 0;

            // Compares student responses with correct answers
            foreach (var entry in answerKey)
            {
                if (studentAnswers.TryGetValue(entry.Key, out string? studentAnswer))
                {
                    if (studentAnswer == entry.Value)
                        score++;
                }
            }
            return score;
        }

        public void ShowNavigationHistory()
        {
            // Handles the case where no questions were visited
            if (navigationStack.Count == 0)
            {
                Console.WriteLine("No navigation recorded.");
                return;
            }

            // Displays visited questions in reverse order of access
            Console.WriteLine("Question Navigation (Last Visited First):");
            foreach (int q in navigationStack)
            {
                Console.WriteLine($"Question {q}");
            }
        }
    }
}
