using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.smart_home_automation_system
{
    class Fan : IControllable
    {
        public void TurnOn()
        {
            Console.WriteLine("Fan turned ON at medium speed.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Fan turned OFF.");
        }
    }
}
