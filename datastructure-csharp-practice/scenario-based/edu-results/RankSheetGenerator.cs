using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.edu_results
{
    class RankSheetGenerator
    {
        class Program
        {
            static Dictionary<string, List<StudentRecord>> districtData =
                new Dictionary<string, List<StudentRecord>>();

            static RankSheetService service = new RankSheetService();

            static void Main()
            {
                while (true)
                {
                    Console.WriteLine("\n===== EduResults Menu =====");
                    Console.WriteLine("1. Add Student to District");
                    Console.WriteLine("2. View District Records");
                    Console.WriteLine("3. Generate State Rank Sheet");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter choice: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            break;

                        case 2:
                            ViewDistricts();
                            break;

                        case 3:
                            GenerateRankSheet();
                            break;

                        case 4:
                            Console.WriteLine("Exiting System...");
                            return;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            break;
                    }
                }
            }

            static void AddStudent()
            {
                Console.Write("Enter District Name: ");
                string district = Console.ReadLine();

                if (!districtData.ContainsKey(district))
                    districtData[district] = new List<StudentRecord>();

                Console.Write("Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                Console.Write("Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Score: ");
                int score = int.Parse(Console.ReadLine());

                districtData[district].Add(
                    new StudentRecord(roll, name, score));

                Console.WriteLine("Student added successfully.");
            }

            static void ViewDistricts()
            {
                foreach (var entry in districtData)
                {
                    Console.WriteLine($"\nDistrict: {entry.Key}");
                    Console.WriteLine("Roll  Name       Score");

                    foreach (var s in entry.Value)
                        Console.WriteLine(s);
                }
            }

            static void GenerateRankSheet()
            {
                var rankList = service.GenerateRankSheet(districtData);

                Console.WriteLine("\n===== State Rank List =====");
                Console.WriteLine("Rank Roll  Name       Score");

                int rank = 1;
                foreach (var s in rankList)
                {
                    Console.WriteLine($"{rank++,4} {s}");
                }
            }
        }
    }
}

