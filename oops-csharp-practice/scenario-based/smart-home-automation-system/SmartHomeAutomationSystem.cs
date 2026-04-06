using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.smart_home_automation_system
{
    class SmartHomeAutomationSystem
    {
        static void Main(string[] args)
        {
            IControllable appliance = null;

            Console.WriteLine("Smart Home Automation System");
            Console.WriteLine("1. Light");
            Console.WriteLine("2. Fan");
            Console.WriteLine("3. AC");
            Console.Write("Select Appliance: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    appliance = new Light();
                    break;
                case 2:
                    appliance = new Fan();
                    break;
                case 3:
                    appliance = new AC();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            Console.WriteLine("\n1. Turn ON");
            Console.WriteLine("2. Turn OFF");
            Console.Write("Select Action: ");

            int action = int.Parse(Console.ReadLine());

            if (action == 1)
                appliance.TurnOn();
            else if (action == 2)
                appliance.TurnOff();
            else
                Console.WriteLine("Invalid action");
        }
    }
}
