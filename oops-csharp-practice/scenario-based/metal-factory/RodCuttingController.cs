using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge.Opps_senario.MetalFaactory
{
    class RodCuttingController
    {
        int length;
        int[] prices;
        public void Start()
        {
            InputData();
            while (true)
            {
                Console.WriteLine("1. Scenario A - Optimized Revenue");
                Console.WriteLine("2. Scenario B - Add Custom Order");
                Console.WriteLine("3. Scenario C - Non Optimized Revenue");
                Console.WriteLine("4. Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) RunOptimized();
                else if (choice == 2) AddCustomOrder();
                else if (choice == 3) RunNonOptimized();
                else if (choice == 4) return;
                else Console.WriteLine("Invalid Choice");
            }
        }
        void InputData()
        {
            Console.Write("Enter Rod Length: ");
            length = int.Parse(Console.ReadLine());
            prices = new int[length + 1];
            for (int i = 1; i <= length; i++)
            {
                Console.Write("Price for length " + i + ": ");
                prices[i] = int.Parse(Console.ReadLine());
            }
        }
        void RunOptimized()
        {
            IRodCuttinngStrategy strategy = new OptimizedRodCutting();
            int revenue = strategy.GetMaxRevenue(length, prices);
            Console.WriteLine("Optimized Revenue: " + revenue);
        }
        void RunNonOptimized()
        {
            IRodCuttinngStrategy strategy = new NonOptimizedRodCutting();
            int revenue = strategy.GetMaxRevenue(length, prices);
            Console.WriteLine("Non Optimized Revenue: " + revenue);
        }
        void AddCustomOrder()
        {
            Console.Write("Enter length to update: ");
            int l = int.Parse(Console.ReadLine());
            Console.Write("Enter new price: ");
            prices[l] = int.Parse(Console.ReadLine());
            Console.WriteLine("Custom order added successfully.");
            RunOptimized();
        }
    }

}
