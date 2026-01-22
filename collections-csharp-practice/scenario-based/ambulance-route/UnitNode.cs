using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.ambulance_route
{
    public class UnitNode
    {
        public HospitalUnit Data { get; private set; }
        public UnitNode Next { get; set; }

        public UnitNode(HospitalUnit unit)
        {
            Data = unit;
            Next = null;
        }
    }

}
