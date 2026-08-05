using System.Collections.Generic;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IPatientService
    {
        List<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
        int AddPatient(Patient patient);
        bool UpdatePatient(Patient patient);
        bool DeletePatient(int id);
    }
}
