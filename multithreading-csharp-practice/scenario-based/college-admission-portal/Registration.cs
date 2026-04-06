using System;

    public class Registration
    {
        private readonly IEmailValidator _validator;
        private readonly IEmailRepository _repository;

        public Registration(IEmailValidator validator,
                                   IEmailRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public void Register(StudentEmail studentEmail)
        {
            try
            {
                bool isValid = _validator.Validate(studentEmail.EmailAddress);

                if (isValid)
                {
                    Console.WriteLine($"Valid Email: {studentEmail.EmailAddress}");
                    _repository.Save(studentEmail.EmailAddress);
                }
                else
                {
                    Console.WriteLine($"Invalid Email: {studentEmail.EmailAddress}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
