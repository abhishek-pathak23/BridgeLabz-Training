namespace ExamProctor.Encapsulation
{
    public class Question
    {
        // Unique identifier for each question
        public int QuestionId { get; }

        // Stores the actual question content
        public string Text { get; }

        public Question(int id, string text)
        {
            // Initializes question details during object creation
            QuestionId = id;
            Text = text;
        }
    }
}
