using System.Collections.Generic;

public interface ICitizenService
{
    void AddCitizen(Citizen citizen);
    void ViewCitizens();
    Citizen SearchCitizen(int id);
    void RemoveCitizen(int id);

    void SortCitizens();

    void BenchmarkSearch(int iterations);
    void BenchmarkSorting(int size);

    void AddComplaint(Complaint complaint);
    void ProcessComplaint();

    void AddServiceRequest(Service service);
    void ProcessServiceRequest();

    void CheckDuplicateVoter(int id);

    void AddEmergencyService(Service service, int priority);
    void ProcessEmergencyService();

    void VisitPage(string page);
    void GoBack();
    void GoForward();

    void AddCitizenToZone(string zone, Citizen citizen);
    void ViewZone(string zone);
    void BackupCitizens();
    void GenerateReport();
    void LoadServices();
    Task ProcessCitizensAsync();
}
