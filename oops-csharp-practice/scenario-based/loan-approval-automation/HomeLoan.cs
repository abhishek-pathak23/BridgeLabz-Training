using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.loan_buddy
{
    
        public class HomeLoan : LoanApplication
        {
            public HomeLoan(double amount, int tenure)
                : base(amount, tenure, 8.5) { }

            public override bool ApproveLoan(Applicant applicant)
            {
                bool approved = applicant.GetCreditScore() >= 700 &&
                                applicant.Income >= loanAmount * 0.3;

                SetApprovalStatus(approved);
                return approved;
            }

            // Polymorphism: discounted interest logic
            public override double CalculateEMI()
            {
                annualInterestRate -= 0.5;
                return base.CalculateEMI();
            }
        }
    }
