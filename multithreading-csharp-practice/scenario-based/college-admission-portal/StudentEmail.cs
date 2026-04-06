 public class StudentEmail
    {
        public string EmailAddress { get; private set; }

        public StudentEmail(string email)
        {
            EmailAddress = email;
        }
    }