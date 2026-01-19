using System;
using System.Collections.Generic;

// Base job role
abstract class JobRole
{
    public string RoleName;
}

class SoftwareEngineer : JobRole { }

// Generic resume class
class Resume<T> where T : JobRole
{
    List<T> candidates = new List<T>();

    public void Add(T role)
    {
        candidates.Add(role);
    }

    public void Display()
    {
        foreach (var r in candidates)
        {
            Console.WriteLine(r.RoleName);
        }
    }
}

class Program
{
    static void Main()
    {
        Resume<SoftwareEngineer> resume = new Resume<SoftwareEngineer>();

        SoftwareEngineer s = new SoftwareEngineer();
        Console.Write("Enter Role Name: ");
        s.RoleName = Console.ReadLine();

        resume.Add(s);
        resume.Display();
    }
}
