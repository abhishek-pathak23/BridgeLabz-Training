using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge.Opps_senario.Furniture
{
    internal class WasteConstraintCutting:IWoodCuttingStrategy
    {
        public int GetMaxRevenue(int length, int[] prices, int allowedWaste)
        {
            int best = 0;
            for (int usable = length; usable >= length - allowedWaste; usable--)
            {
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
                best = Math.Max(best, dp[usable]);
            }
            return best;
        }
        }
}
