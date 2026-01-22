using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.ambulance_route
{
    public class HospitalUnit
    {
        public string Name { get; private set; }
        public bool IsAvailable { get; private set; }

        public HospitalUnit(string name)
        {
            Name = name;
            IsAvailable = true;
        }

        public void ChangeStatus(bool status)
        {
            IsAvailable = status;
        }
    }

}
