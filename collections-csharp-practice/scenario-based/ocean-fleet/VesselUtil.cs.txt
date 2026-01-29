using System;
using System.Collections.Generic;

namespace OceanFleet
{
    public class VesselUtil
    {
        private List<Vessel> vesselList = new List<Vessel>();

        // Getter and Setter
        public List<Vessel> VesselList
        {
            get { return vesselList; }
            set { vesselList = value; }
        }

        // Requirement 1: Add vessel
        public void addVesselPerformance(Vessel vessel)
        {
            vesselList.Add(vessel);
        }

        // Requirement 2: Get vessel by ID (case-sensitive)
        public Vessel getVesselById(string vesselId)
        {
            foreach (Vessel vessel in vesselList)
            {
                if (vessel.VesselId == vesselId)
                {
                    return vessel;
                }
            }
            return null;
        }

        // Requirement 3: Get high-performance vessels
        public List<Vessel> getHighPerformanceVessels()
        {
            List<Vessel> result = new List<Vessel>();

            if (vesselList.Count == 0)
                return result;

            double maxSpeed = vesselList[0].AverageSpeed;

            foreach (Vessel vessel in vesselList)
            {
                if (vessel.AverageSpeed > maxSpeed)
                {
                    maxSpeed = vessel.AverageSpeed;
                }
            }

            foreach (Vessel vessel in vesselList)
            {
                if (vessel.AverageSpeed == maxSpeed)
                {
                    result.Add(vessel);
                }
            }

            return result;
        }
    }
}