namespace HealthClinicApp.Entity
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
    }
}
