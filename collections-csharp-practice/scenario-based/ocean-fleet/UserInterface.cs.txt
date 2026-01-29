using System;
using System.Collections.Generic;

namespace OceanFleet
{
    class UserInterface
    {
        static void Main(string[] args)
        {
            VesselUtil vesselUtil = new VesselUtil();

            Console.WriteLine("Enter the number of vessels to be added");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter vessel details");
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(':');

                Vessel vessel = new Vessel(
                    parts[0],
                    parts[1],
                    double.Parse(parts[2]),
                    parts[3]
                );

                vesselUtil.addVesselPerformance(vessel);
            }

            Console.WriteLine("Enter the Vessel Id to check speed");
            string searchId = Console.ReadLine();

            Vessel searchedVessel = vesselUtil.getVesselById(searchId);

            if (searchedVessel != null)
            {
                Console.WriteLine(
                    $"{searchedVessel.VesselId} | {searchedVessel.VesselName} | {searchedVessel.VesselType} | {searchedVessel.AverageSpeed} knots"
                );
            }
            else
            {
                Console.WriteLine($"Vessel Id {searchId} not found");
            }

            Console.WriteLine("High performance vessels are");
            List<Vessel> highPerformanceVessels = vesselUtil.getHighPerformanceVessels();

            foreach (Vessel vessel in highPerformanceVessels)
            {
                Console.WriteLine(
                    $"{vessel.VesselId} | {vessel.VesselName} | {vessel.VesselType} | {vessel.AverageSpeed} knots"
                );
            }
        }
    }
}