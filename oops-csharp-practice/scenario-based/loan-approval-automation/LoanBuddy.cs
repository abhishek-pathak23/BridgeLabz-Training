using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.loan_buddy
{
   
        public abstract class LoanApplication : IApprovable
        {
            protected double loanAmount;
            protected int tenureMonths;
            protected double annualInterestRate;

            private bool isApproved;

            protected LoanApplication(double loanAmount, int tenureMonths, double interestRate)
            {
                this.loanAmount = loanAmount;
                this.tenureMonths = tenureMonths;
                this.annualInterestRate = interestRate;
            }

            public abstract bool ApproveLoan(Applicant applicant);

            // EMI Formula: P × R × (1+R)^N / ((1+R)^N – 1)
            public virtual double CalculateEMI()
            {
                double monthlyRate = annualInterestRate / (12 * 100);
                double numerator = loanAmount * monthlyRate * Math.Pow(1 + monthlyRate, tenureMonths);
                double denominator = Math.Pow(1 + monthlyRate, tenureMonths) - 1;

                return numerator / denominator;
            }

            protected void SetApprovalStatus(bool status)
            {
                isApproved = status;
            }

            public bool GetApprovalStatus()
            {
                return isApproved;
            }
        }
    }

