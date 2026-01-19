using ParcelTracker.Interface;
using ParcelTracker.Node;
using System;

namespace ParcelTracker.Utility
{
    public class ParcelTrackerUtility : IParcelTracker
    {
        private ParcelNode? head;

        public ParcelTrackerUtility()
        {
            // Initial delivery stages
            AddStage("Packed");
            AddStage("Shipped");
            AddStage("In Transit");
            AddStage("Delivered");
        }

        public void AddStage(string stageName)
        {
            if (string.IsNullOrWhiteSpace(stageName))
                return;

            ParcelNode newNode = new(stageName);

            if (head == null)
            {
                head = newNode;
                return;
            }

            ParcelNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void DisplayStages()
        {
            if (head == null)
            {
                Console.WriteLine("Parcel is missing (no tracking data).");
                return;
            }

            ParcelNode? current = head;
            while (current != null)
            {
                Console.Write(current.Stage);
                if (current.Next != null)
                    Console.Write(" -> ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void CheckParcelStatus()
        {
            if (head == null)
            {
                Console.WriteLine("Parcel lost or not registered.");
                return;
            }

            ParcelNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            Console.WriteLine($"Current Status: {current.Stage}");
        }
    }
}
