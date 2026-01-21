using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.smart_checkout
{
        class SmartCheckout
        {
            static InventoryService inventory = new InventoryService();
            static CheckoutQueueService checkout =new CheckoutQueueService(inventory);

            static void Main()
            {
                SeedInventory();

                while (true)
                {
                    Console.WriteLine("\n===== SmartCheckout Menu =====");
                    Console.WriteLine("1. Add Customer to Queue");
                    Console.WriteLine("2. Process Next Customer");
                    Console.WriteLine("3. View Inventory");
                Console.WriteLine("4. Exit");
                    Console.Write("Enter choice: ");
                //take the use choice as input

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddCustomer();
                            break;

                        case 2:
                            checkout.ProcessNextCustomer();
                            break;

                        case 3:
                            inventory.DisplayInventory();
                            break;

                        case 4:
                            Console.WriteLine("System Closed.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }
        //method for inventory
            static void SeedInventory()
            {
                inventory.AddItem(new Item("Milk", 40, 20));
                inventory.AddItem(new Item("Bread", 30, 15));
                inventory.AddItem(new Item("Rice", 60, 10));
            }
        //method for add customer
            static void AddCustomer()
            {
                Console.Write("Customer Name: ");
                string name = Console.ReadLine();

                Customer customer = new Customer(name);

                while (true)
                {
                    Console.Write("Item name (or done): ");
                    string item = Console.ReadLine();

                    if (item.ToLower() == "done")
                        break;

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    customer.AddItem(item, qty);
                }

                checkout.AddCustomer(customer);
            }
        }
    }

