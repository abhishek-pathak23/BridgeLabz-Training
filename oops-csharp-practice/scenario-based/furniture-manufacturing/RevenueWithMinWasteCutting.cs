using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge.Opps_senario.Furniture
{
    internal class RevenueWithMinWasteCutting : IWoodCuttingStrategy
    {
        public int GetMaxRevenue(int length, int[] prices, int allowedWaste)
        {
            int bestRevenue = 0;

            for (int usable = length; usable >= 0; usable--)
            {
                int waste = length - usable;
                if (waste > allowedWaste) continue;

                int[] dp = new int[usable + 1];

                for (int i = 1; i <= usable; i++)
                {
                    int max = 0;
                    for (int cut = 1; cut <= i; cut++)
                    {
                        max = Math.Max(max, prices[cut] + dp[i - cut]);
                    }
                    dp[i] = max;
                }

                if (dp[usable] > bestRevenue)
                    bestRevenue = dp[usable];
            }
            return bestRevenue;
        }
    }
}