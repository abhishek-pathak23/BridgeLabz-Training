using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.loan_buddy
{
    
        public class AutoLoan : LoanApplication
        {
            public AutoLoan(double amount, int tenure)
                : base(amount, tenure, 9.5) { }

            public override bool ApproveLoan(Applicant applicant)
            {
                bool approved = applicant.GetCreditScore() >= 600 &&
                                applicant.Income >= loanAmount * 0.35;

                SetApprovalStatus(approved);
                return approved;
            }
        }
    }

