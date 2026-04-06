using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.smart_home_automation_system
{
    class AC : IControllable
    {
        public void TurnOn()
        {
            Console.WriteLine("AC turned ON. Temperature set to 24°C.");
        }

        public void TurnOff()
        {
            Console.WriteLine("AC turned OFF.");
        }
    }
}
