using System;

namespace HealthClinicApp.Entity
{
    public class Billing
    {
        public int BillID { get; set; }
        public int AppointmentID { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public decimal ConsultationFee { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
        public DateTime BillingDate { get; set; }
    }
}
