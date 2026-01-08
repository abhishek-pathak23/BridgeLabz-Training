using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.smart_home_automation_system
{
        class Light : IControllable
        {
            public void TurnOn()
            {
                Console.WriteLine("Light turned ON with soft brightness.");
            }

            public void TurnOff()
            {
                Console.WriteLine("Light turned OFF.");
            }
        }
}
