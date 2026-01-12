using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.loan_buddy
{
    
        public interface IApprovable
        {
            bool ApproveLoan(Applicant applicant);
            double CalculateEMI();
        }
    }

