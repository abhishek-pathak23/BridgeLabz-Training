using System;
using System.Collections.Generic;
using System.Threading.Tasks;


    class Program
    {
        static void Main()
        {
            IEmailValidator validator = new EmailValidator();
            IEmailRepository repository = new FileEmailRepository();
            Registration registration =
                new Registration(validator, repository);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===== EduConnect Admission Portal =====");
                Console.WriteLine("1. Register Email");
                Console.WriteLine("2. Bulk Register (Multithreading)");
                Console.WriteLine("3. View Registered Emails");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Email: ");
                        string inputEmail = Console.ReadLine();

                        StudentEmail email =
                            new StudentEmail(inputEmail);

                        registration.Register(email);
                        break;

                    case "2":
                        Console.WriteLine("Enter emails separated by comma:");
                        string bulkInput = Console.ReadLine();

                        string[] emails = bulkInput.Split(',');

                        List<Task> taskList = new List<Task>();

                        foreach (string e in emails)
                        {
                            StudentEmail bulkEmail =
                                new StudentEmail(e.Trim());

                            taskList.Add(Task.Run(() =>
                            {
                                registration.Register(bulkEmail);
                            }));
                        }

                        Task.WaitAll(taskList.ToArray());
                        Console.WriteLine("Bulk Registration Completed.");
                        break;

                    case "3":
                        repository.DisplayAll();
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }

            Console.WriteLine("Application Closed.");
        }
    }
