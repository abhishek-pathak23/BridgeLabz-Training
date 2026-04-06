using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge.Opps_senario.Furniture
{
    internal interface IWoodCuttingStrategy
    {
        int GetMaxRevenue(int length, int[] prices, int allowedWaste);
    }
}
