namespace ExamProctor.Interface
{
    // Defines a contract for exam-related operations
    public interface IExamProctor
    {
        // Records when a user visits a specific question
        void VisitQuestion(int questionId);

        // Accepts and stores an answer for a given question
        bool SubmitAnswer(int questionId, string answer);

        // Displays the sequence of questions visited by the user
        void ShowNavigationHistory();

        // Evaluates answers and returns the final score
        int CalculateScore();
    }
}
