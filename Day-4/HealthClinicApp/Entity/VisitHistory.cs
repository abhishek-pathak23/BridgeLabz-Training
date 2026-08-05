using System;

namespace HealthClinicApp.Entity
{
    public class VisitHistory
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? BillID { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
