using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge.Opps_senario.MetalFaactory
{
    internal class NonOptimizedRodCutting:IRodCuttinngStrategy
    {
        public int GetMaxRevenue(int length, int[] prices)
        {
            return prices[length];
        }
    
    }
}
