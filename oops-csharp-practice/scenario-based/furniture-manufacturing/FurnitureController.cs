using System;

namespace bridge.Opps_senario.Furniture
{
    internal class FurnitureController
    {
        public void Start()
        {
            Console.Write("Enter total wooden rod length: ");
            int rodLength = int.Parse(Console.ReadLine());

            int[] priceList = new int[rodLength + 1];

            for (int i = 1; i <= rodLength; i++)
            {
                Console.Write("Enter price for " + i + " ft piece: ");
                priceList[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter allowed waste length: ");
            int allowedWaste = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("PRESS 1- Maximum Revenue");
            Console.WriteLine("PRESS 2- Revenue with Waste Limit");
            Console.WriteLine("PRESS 3- Scenario C - Revenue with Minimum Waste");
            int option = int.Parse(Console.ReadLine());
            IWoodCuttingStrategy cuttingLogic;

            if (option == 1)
            {
                cuttingLogic = new MaxRevenueCutting();
            }
            else if (option == 2)
            {
                cuttingLogic = new WasteConstraintCutting();
            }
            else
            {
                cuttingLogic = new RevenueWithMinWasteCutting();
            }

            int finalAmount =
                cuttingLogic.GetMaxRevenue(rodLength, priceList, allowedWaste);

            Console.WriteLine();
            Console.WriteLine("Total Revenue Earned: " + finalAmount);
        }
    }
}
