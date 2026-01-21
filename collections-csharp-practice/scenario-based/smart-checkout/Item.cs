using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.smart_checkout
{
        public class Item
        {
            public string Name { get; }
            public double Price { get; }
            public int Stock { get; private set; }
        //constructor
            public Item(string name, double price, int stock)
            {
                Name = name;
                Price = price;
                Stock = stock;
            }

            public bool ReduceStock(int quantity)
            {
                if (quantity > Stock)
                    return false;

                Stock -= quantity;
                return true;
            }

            public override string ToString()
            {
                return $"{Name,-10} Price: {Price,-5} Stock: {Stock}";
            }
        }
    }


