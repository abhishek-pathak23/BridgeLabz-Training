using System;
using System.IO;


    public class FileEmailRepository : IEmailRepository
    {
        private readonly string _filePath = "RegisteredEmails.txt";
        private static readonly object _syncLock = new object();

        public void Save(string email)
        {
            lock (_syncLock)
            {
                File.AppendAllText(_filePath, email + Environment.NewLine);
            }
        }

        public void DisplayAll()
        {
            if (File.Exists(_filePath))
            {
                string content = File.ReadAllText(_filePath);
                Console.WriteLine("\n--- Registered Emails ---");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("No emails registered yet.");
            }
        }
    }
