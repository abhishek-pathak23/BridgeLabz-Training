using System.Collections.Generic;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
        Doctor? GetDoctorById(int id);
        int AddDoctor(Doctor doctor);
        bool UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int id);
    }
}
