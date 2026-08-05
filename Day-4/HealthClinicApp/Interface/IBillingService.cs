using System.Collections.Generic;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IBillingService
    {
        List<Billing> GetAllBills();
        int GenerateBill(int appointmentId, decimal consultationFee, decimal taxAmount);
        bool UpdateBillPaymentStatus(int billId, string paymentStatus);
    }
}
