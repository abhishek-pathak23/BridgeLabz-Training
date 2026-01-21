using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.smart_checkout
{
        public class Customer
        {
            public string CustomerName { get; }
            public Dictionary<string, int> Cart { get; }

            public Customer(string name)
            {
                CustomerName = name;
                Cart = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            }
        //method to add item
            public void AddItem(string itemName, int quantity)
            {
                if (Cart.ContainsKey(itemName))
                    Cart[itemName] += quantity;
                else
                    Cart[itemName] = quantity;
            }
        }
    }
