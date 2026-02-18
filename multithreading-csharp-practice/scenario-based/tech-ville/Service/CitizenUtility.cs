using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class CitizenUtility : ICitizenService
{
    // Module 17 Collections
    private CitizenRegistry registry = new CitizenRegistry();
    private CitizenLookup lookup = new CitizenLookup();
    private UniqueVoterRegistry voterRegistry = new UniqueVoterRegistry();
    private ComplaintQueue complaintQueue = new ComplaintQueue();
    private ServiceRequestQueue serviceQueue = new ServiceRequestQueue();
    private EmergencyServiceQueue emergencyQueue = new EmergencyServiceQueue();
    private NavigationHistory navigationHistory = new NavigationHistory();
    private ZoneRegistry zoneRegistry = new ZoneRegistry();

    private LogManager logManager = new LogManager();
    private RegistrationWriter registrationWriter = new RegistrationWriter();
    private ProfileBackup backup = new ProfileBackup();
    private ReportGenerator reportGenerator = new ReportGenerator();
    private ServiceBackup serviceBackup = new ServiceBackup();




    // ===== Basic Citizen Operations =====

    public void AddCitizen(Citizen citizen)
    {
        try
        {
            if (citizen.Age < 18)
                throw new UnderageException("Citizen must be 18+.");

            if (lookup.Get(citizen.Id) != null)
                throw new DuplicateCitizenException("Citizen ID already exists.");

            if (!CitizenValidator.ValidateEmail(citizen.Email))
                throw new ArgumentException("Invalid Email Format.");

            if (!CitizenValidator.ValidatePhone(citizen.Phone))
                throw new ArgumentException("Invalid Phone Format.");

            registry.AddCitizen(citizen);
            lookup.Add(citizen);

            Console.WriteLine("Citizen added successfully.");
        }
        catch (Exception ex)
        {
            ExceptionLogger.Log(ex);
            Console.WriteLine("Error: " + ex.Message);
        }
    }



    public void ViewCitizens()
    {
        foreach (var c in registry.GetAll())
            Console.WriteLine(c);
    }

    public Citizen SearchCitizen(int id)
    {
        try
        {
            var citizen = lookup.Get(id);

            if (citizen == null)
                throw new NullReferenceException("Citizen not found.");

            return citizen;
        }
        catch (Exception ex)
        {
            ExceptionLogger.Log(ex);
            Console.WriteLine(ex.Message);
            return null;
        }
    }


    public void RemoveCitizen(int id)
    {
        Citizen citizen = lookup.Get(id);

        if (citizen != null)
        {
            registry.RemoveCitizen(citizen);
            Console.WriteLine("Citizen removed.");
        }
        else
        {
            Console.WriteLine("Citizen not found.");
        }
    }

    public void SortCitizens()
    {
        var list = registry.GetAll();
        list.Sort();
        Console.WriteLine("Citizens sorted by ID.");
    }

    // ===== Complaint Management (LinkedList) =====

    public void AddComplaint(Complaint complaint)
    {
        complaintQueue.AddLast(complaint);
        Console.WriteLine("Complaint added.");
    }

    public void ProcessComplaint()
    {
        complaintQueue.RemoveFirst();
        Console.WriteLine("Complaint processed.");
    }

    // ===== Service Queue (Queue FIFO) =====

    public void AddServiceRequest(Service service)
    {
        try
        {
            if (service == null)
                throw new ArgumentNullException("Service cannot be null.");

            serviceQueue.Enqueue(service);
            Console.WriteLine("Service request added.");
        }
        catch (Exception ex)
        {
            ExceptionLogger.Log(ex);
            Console.WriteLine("Service error: " + ex.Message);
        }
    }


    public void ProcessServiceRequest()
    {
        Service service = serviceQueue.Dequeue();

        if (service != null)
            Console.WriteLine("Processing: " + service);
        else
            Console.WriteLine("No service requests.");
    }

    // ===== Unique Voter Check =====

    public void CheckDuplicateVoter(int id)
    {
        bool added = voterRegistry.AddVoter(id);

        if (!added)
            Console.WriteLine("Duplicate voter detected!");
        else
            Console.WriteLine("Voter registered.");
    }

    // ===== Performance Methods (Module 15) =====

    public void BenchmarkSearch(int iterations)
    {
        for (int i = 0; i < iterations; i++)
            lookup.Get(i);

        Console.WriteLine("Search benchmark completed.");
    }

    public void BenchmarkSorting(int size)
    {
        var list = registry.GetAll();
        list.Sort();
        Console.WriteLine("Sorting benchmark completed.");
    }

    public void AddEmergencyService(Service service, int priority)
    {
        emergencyQueue.Enqueue(service, priority);
        Console.WriteLine("Emergency service added.");
    }

    public void ProcessEmergencyService()
    {
        Service service = emergencyQueue.Dequeue();

        if (service != null)
            Console.WriteLine("Emergency Processing: " + service);
        else
            Console.WriteLine("No emergency services.");
    }

    public void VisitPage(string page)
    {
        navigationHistory.Visit(page);
        Console.WriteLine("Visited: " + page);
    }

    public void GoBack()
    {
        string page = navigationHistory.Back();
        Console.WriteLine("Back to: " + page);
    }

    public void GoForward()
    {
        string page = navigationHistory.Forward();
        Console.WriteLine("Forward to: " + page);
    }
    
    public void AddCitizenToZone(string zone, Citizen citizen)
    {
        zoneRegistry.AddCitizen(zone, citizen);
        Console.WriteLine("Citizen added to zone.");
    }

    public void ViewZone(string zone)
    {
        var citizens = zoneRegistry.GetZoneCitizens(zone);

        if (citizens != null)
            foreach (var c in citizens)
                Console.WriteLine(c);
        else
            Console.WriteLine("Zone not found.");
    }

    public void BackupCitizens()
    {
        backup.Save(registry.GetAll());
        Console.WriteLine("Backup completed.");
    }
    public void GenerateReport()
    {
        Console.WriteLine("Generating report...");

        var citizens = registry.GetAll(); 

        using (StreamWriter writer = new StreamWriter("CitizenReport.txt"))
        {
            foreach (var citizen in citizens)
            {
                writer.WriteLine(citizen.ToString());
            }
        }

        Console.WriteLine("Report generated successfully.");
    }

    public void LoadServices()
    {
        try
        {
            var services = serviceBackup.Load();

            foreach (var service in services)
                serviceQueue.Enqueue(service);

            Console.WriteLine("Services loaded successfully.");
        }
        catch (Exception ex)
        {
            ExceptionLogger.Log(ex);
            Console.WriteLine("Failed to load services.");
        }
    }
    public async Task ProcessCitizensAsync()
    {
        var citizens = registry.GetAll();

        Console.WriteLine("Starting async parallel processing...\n");

        await Task.Run(() =>
        {
            Parallel.ForEach(citizens, citizen =>
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;

                Console.WriteLine($"Thread {threadId} processing Citizen ID: {citizen.Id}");

                // Simulate work
                Thread.Sleep(500);
            });
        });

        Console.WriteLine("\nProcessing completed.");
    }
}
