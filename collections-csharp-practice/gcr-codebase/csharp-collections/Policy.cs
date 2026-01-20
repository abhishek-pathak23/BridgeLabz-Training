using System;
using System.Collections.Generic;
using System.Linq;

class Policy
{
    public string PolicyNumber { get; set; }
    public string HolderName { get; set; }
    public string CoverageType { get; set; }
    public DateTime ExpiryDate { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Policy p && PolicyNumber == p.PolicyNumber;
    }

    public override int GetHashCode()
    {
        return PolicyNumber.GetHashCode();
    }

    public override string ToString()
    {
        return $"PolicyNumber: {PolicyNumber}, Holder: {HolderName}, Coverage: {CoverageType}, Expiry: {ExpiryDate.ToShortDateString()}";
    }
}

class InsuranceSystem
{
    static void Main()
    {
        // ---------- Storage ----------

        // 1. HashSet for uniqueness check
        HashSet<Policy> uniquePolicies = new HashSet<Policy>();

        // 2. LinkedHashSet equivalent: List + HashSet to maintain insertion order
        List<Policy> insertionOrderList = new List<Policy>();
        HashSet<Policy> insertionSet = new HashSet<Policy>();

        // 3. SortedSet by ExpiryDate
        SortedSet<Policy> sortedByExpiry = new SortedSet<Policy>(Comparer<Policy>.Create((p1, p2) =>
        {
            int cmp = p1.ExpiryDate.CompareTo(p2.ExpiryDate);
            if (cmp == 0) return p1.PolicyNumber.CompareTo(p2.PolicyNumber); // tie-breaker
            return cmp;
        }));

        // ---------- Input ----------
        Console.WriteLine("Enter number of policies to add:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for policy #{i + 1}:");
            Console.Write("Policy Number: ");
            string number = Console.ReadLine();
            Console.Write("Holder Name: ");
            string holder = Console.ReadLine();
            Console.Write("Coverage Type: ");
            string coverage = Console.ReadLine();
            Console.Write("Expiry Date (yyyy-mm-dd): ");
            DateTime expiry = DateTime.Parse(Console.ReadLine());

            Policy policy = new Policy
            {
                PolicyNumber = number,
                HolderName = holder,
                CoverageType = coverage,
                ExpiryDate = expiry
            };

            // HashSet for uniqueness
            uniquePolicies.Add(policy);

            // LinkedHashSet equivalent
            if (!insertionSet.Contains(policy))
            {
                insertionOrderList.Add(policy);
                insertionSet.Add(policy);
            }

            // SortedSet by expiry
            sortedByExpiry.Add(policy);
        }

        // ---------- Retrieval ----------

        Console.WriteLine("\n--- All Unique Policies ---");
        foreach (var p in uniquePolicies)
            Console.WriteLine(p);

        Console.WriteLine("\n--- Policies in Insertion Order ---");
        foreach (var p in insertionOrderList)
            Console.WriteLine(p);

        Console.WriteLine("\n--- Policies Sorted by Expiry Date ---");
        foreach (var p in sortedByExpiry)
            Console.WriteLine(p);

        Console.WriteLine("\n--- Policies Expiring in Next 30 Days ---");
        DateTime today = DateTime.Today;
        DateTime next30Days = today.AddDays(30);
        foreach (var p in sortedByExpiry)
        {
            if (p.ExpiryDate <= next30Days && p.ExpiryDate >= today)
                Console.WriteLine(p);
        }

        Console.WriteLine("\nEnter Coverage Type to search:");
        string coverageSearch = Console.ReadLine();
        Console.WriteLine($"--- Policies with Coverage '{coverageSearch}' ---");
        foreach (var p in uniquePolicies.Where(x => x.CoverageType.Equals(coverageSearch, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\n--- Duplicate Policies by Policy Number ---");
        var duplicates = insertionOrderList
            .GroupBy(x => x.PolicyNumber)
            .Where(g => g.Count() > 1)
            .SelectMany(g => g);

        if (!duplicates.Any())
            Console.WriteLine("No duplicate policies found.");
        else
            foreach (var p in duplicates)
                Console.WriteLine(p);
    }
}
