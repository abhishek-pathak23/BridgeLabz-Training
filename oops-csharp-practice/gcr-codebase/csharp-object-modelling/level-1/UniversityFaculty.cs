using System;
using System.Collections.Generic;

namespace UniversityManagement
{
    // Represents a faculty member
    class Faculty
    {
        public string Name { get; set; }

        public Faculty(string name)
        {
            Name = name;
        }
    }

    // Represents a department in the university
    class Department
    {
        public string Name { get; set; }

        public Department(string name)
        {
            Name = name;
        }
    }

    // Represents a university
    class University
    {
        public string Name { get; set; }

        // Composition: Departments are part of the university and depend on it
        public List<Department> Departments { get; set; }

        // Aggregation: Faculties can exist independently of the university
        public List<Faculty> Faculties { get; set; }

        public University(string name)
        {
            Name = name;
            Departments = new List<Department>();
            Faculties = new List<Faculty>();
        }

        // Add a department to the university (Composition)
        public void AddDepartment(Department dept)
        {
            Departments.Add(dept);
            Console.WriteLine($"Department '{dept.Name}' added to {Name}");
        }

        // Associate a faculty with the university (Aggregation)
        public void AddFaculty(Faculty fac)
        {
            Faculties.Add(fac);
            Console.WriteLine($"Faculty '{fac.Name}' associated with {Name}");
        }

        // Display all departments and faculties of the university
        public void ShowUniversity()
        {
            Console.WriteLine($"\nUniversity: {Name}");

            Console.WriteLine("Departments:");
            foreach (var d in Departments)
                Console.WriteLine($"- {d.Name}");

            Console.WriteLine("Faculties:");
            foreach (var f in Faculties)
                Console.WriteLine($"- {f.Name}");
        }
    }

    // Main program class
    class UniversityFaculty
    {
        static void Main()
        {
            // Input university name
            Console.WriteLine("Enter University Name:");
            string uniName = Console.ReadLine();
            University uni = new University(uniName);

            // Input and add departments
            Console.WriteLine("Enter number of departments:");
            int numDept = int.Parse(Console.ReadLine());
            for (int i = 0; i < numDept; i++)
            {
                Console.WriteLine($"Enter Department {i + 1} name:");
                uni.AddDepartment(new Department(Console.ReadLine()));
            }

            // Input and associate faculties
            Console.WriteLine("Enter number of faculties:");
            int numFac = int.Parse(Console.ReadLine());
            for (int i = 0; i < numFac; i++)
            {
                Console.WriteLine($"Enter Faculty {i + 1} name:");
                uni.AddFaculty(new Faculty(Console.ReadLine()));
            }

            // Display university details
            uni.ShowUniversity();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
