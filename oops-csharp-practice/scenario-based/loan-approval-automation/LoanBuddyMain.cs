using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.loan_buddy
{
    
        class LoanBuddyMain
        {
            static void Main()
            {
                Console.WriteLine(" Welcome to LoanBuddy – Loan Approval System");

                Console.Write("Enter Applicant Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Credit Score: ");
                int score = int.Parse(Console.ReadLine());

                Console.Write("Enter Monthly Income: ");
                double income = double.Parse(Console.ReadLine());

                Console.Write("Enter Loan Amount: ");
                double amount = double.Parse(Console.ReadLine());

                Applicant applicant = new Applicant(name, score, income, amount);

                Console.WriteLine("\nSelect Loan Type:");
                Console.WriteLine("1. Personal Loan");
                Console.WriteLine("2. Home Loan");
                Console.WriteLine("3. Auto Loan");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter Loan Tenure (months): ");
                int tenure = int.Parse(Console.ReadLine());

                LoanApplication loan = null;

                switch (choice)
                {
                    case 1:
                        loan = new PersonalLoan(amount, tenure);
                        break;
                    case 2:
                        loan = new HomeLoan(amount, tenure);
                        break;
                    case 3:
                        loan = new AutoLoan(amount, tenure);
                        break;
                    default:
                        Console.WriteLine("Invalid Loan Type");
                        return;
                }

                bool approved = loan.ApproveLoan(applicant);

                Console.WriteLine("\n📄 Loan Decision");
                if (approved)
                {
                    Console.WriteLine("Status: APPROVED ✅");
                    Console.WriteLine("Monthly EMI: ₹" + loan.CalculateEMI().ToString("F2"));
                }
                else
                {
                    Console.WriteLine("Status: REJECTED ❌");
                }
            }
        }
    }
