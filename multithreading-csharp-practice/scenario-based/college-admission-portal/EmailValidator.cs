using System;
using System.Text.RegularExpressions;

    public class EmailValidator : IEmailValidator
    {
        private readonly string _pattern =
            @"^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]{2,6}$";

        public bool Validate(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            Regex regex = new Regex(_pattern);
            return regex.IsMatch(email);
        }
    }
