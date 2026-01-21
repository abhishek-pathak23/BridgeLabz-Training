using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.smart_checkout
{
        public class CheckoutQueueService
        {
            private Queue<Customer> customerQueue =new Queue<Customer>();

            private InventoryService inventory;

            public CheckoutQueueService(InventoryService inventory)
            {
                this.inventory = inventory;
            }

            public void AddCustomer(Customer customer)
            {
                customerQueue.Enqueue(customer);
                Console.WriteLine("Customer added to queue.");
            }

            public void ProcessNextCustomer()
            {
                if (customerQueue.Count == 0)
                {
                    Console.WriteLine("No customers in queue.");
                    return;
                }

                Customer customer = customerQueue.Dequeue();
                double total = 0;

                Console.WriteLine($"\nBilling for {customer.CustomerName}");

                foreach (var entry in customer.Cart)
                {
                    Item item = inventory.GetItem(entry.Key);

                    if (item == null)
                    {
                        Console.WriteLine($"{entry.Key} not found.");
                        continue;
                    }

                    if (!item.ReduceStock(entry.Value))
                    {
                        Console.WriteLine(
                            $"Insufficient stock for {entry.Key}");
                        continue;
                    }

                    double cost = item.Price * entry.Value;
                    total += cost;

                    Console.WriteLine(
                        $"{entry.Key} x {entry.Value} = {cost}");
                }

                Console.WriteLine($"Total Bill: {total}\n");
            }
        }
    }

