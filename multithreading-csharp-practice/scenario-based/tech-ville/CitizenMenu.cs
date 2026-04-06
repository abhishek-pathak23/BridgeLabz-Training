using System;

public class CitizenMenu
{
    private ICitizenService system = new CitizenUtility();

    public async Task Start()
    {
        while (true)
        {
            Console.WriteLine("\n=== TechVille System ===");
            Console.WriteLine("1. Add Citizen");
            Console.WriteLine("2. View Citizens");
            Console.WriteLine("3. Search Citizen");
            Console.WriteLine("4. Remove Citizen");
            Console.WriteLine("5. Sort Citizens");
            Console.WriteLine("6. Benchmark Search");
            Console.WriteLine("7. Benchmark Sorting");
            Console.WriteLine("8. Add Complaint");
            Console.WriteLine("9. Process Complaint");
            Console.WriteLine("10. Add Service Request");
            Console.WriteLine("11. Process Service Request");
            Console.WriteLine("12. Check Duplicate Voter");
            Console.WriteLine("13. Add Emergency Service");
            Console.WriteLine("14. Process Emergency Service");
            Console.WriteLine("15. Visit Page");
            Console.WriteLine("16. Go Back");
            Console.WriteLine("17. Go Forward");
            Console.WriteLine("18. Add Citizen to the Zone.");
            Console.WriteLine("19. View Zone");
            Console.WriteLine("20. Backup Citizens");
            Console.WriteLine("21. Generate Report");
            Console.WriteLine("22. Load Services");
            Console.WriteLine("23. Process Citizens (Async + Parallel)");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddCitizenMenu();
                    break;
                case 2:
                    system.ViewCitizens();
                    break;
                case 3:
                    {
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var citizen = system.SearchCitizen(id);
                        Console.WriteLine(citizen != null ? citizen.ToString() : "Not Found");
                        break;
                    }
                case 4:
                    Console.Write("Enter ID: ");
                    system.RemoveCitizen(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 5:
                    system.SortCitizens();
                    break;
                case 6:
                    system.BenchmarkSearch(1000000);
                    break;
                case 7:
                    system.BenchmarkSorting(100000);
                    break;
                case 8:
                    Console.Write("Complaint ID: ");
                    int cid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    system.AddComplaint(new Complaint(cid, desc));
                    break;

                case 9:
                    system.ProcessComplaint();
                    break;

                case 10:
                    Console.Write("Service ID: ");
                    int sid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Service Name: ");
                    string sname = Console.ReadLine();
                    system.AddServiceRequest(new Service(sid, sname));
                    break;

                case 11:
                    system.ProcessServiceRequest();
                    break;

                case 12:
                    Console.Write("Enter Voter ID: ");
                    int vid = Convert.ToInt32(Console.ReadLine());
                    system.CheckDuplicateVoter(vid);
                    break;
                case 13:
                    Console.Write("Service ID: ");
                    int esid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Name: ");
                    string esname = Console.ReadLine();
                    Console.Write("Priority (lower = higher): ");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    system.AddEmergencyService(new Service(esid, esname), pr);
                    break;

                case 14:
                    system.ProcessEmergencyService();
                    break;

                case 15:
                    Console.Write("Enter page name: ");
                    system.VisitPage(Console.ReadLine());
                    break;

                case 16:
                    system.GoBack();
                    break;

                case 17:
                    system.GoForward();
                    break;

                case 18:
                    {
                    Console.Write("Zone: ");
                    string zone = Console.ReadLine();
                    Console.Write("Citizen ID: ");
                    int zid = Convert.ToInt32(Console.ReadLine());
                    var citizen = system.SearchCitizen(zid);
                    if (citizen != null)
                        system.AddCitizenToZone(zone, citizen);
                    break;
                    }
                case 19:
                    Console.Write("Zone: ");
                    system.ViewZone(Console.ReadLine());
                    break;
                case 20:
                    {
                        system.BackupCitizens();
                        break;
                    }
                case 21:
                    system.GenerateReport();
                    break;
                case 22:
                    system.LoadServices();
                    break;
                case 23:
                    await system.ProcessCitizensAsync();
                    break;


                case 0:
                    return;
            }
        }
    }

    private void AddCitizenMenu()
    {
        Console.Write("ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Income: ");
        double income = Convert.ToDouble(Console.ReadLine());

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();


        system.AddCitizen(new Citizen(id, name, age, income, email, phone));
    }

}
