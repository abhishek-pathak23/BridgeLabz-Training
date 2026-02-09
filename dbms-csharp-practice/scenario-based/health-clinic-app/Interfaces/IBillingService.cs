using System;

public interface IBillingService
{
    /// <summary>
    /// UC-5.1: Generate a bill for a visit
    /// </summary>
    void GenerateBill(); 

    /// <summary>
    /// UC-5.2: Record payment for a bill
    /// </summary>
    void RecordPayment();

    /// <summary>
    /// UC-5.3: View all outstanding bills
    /// </summary>
    void ViewOutstandingBills();

    /// <summary>
    /// UC-5.4: Generate revenue report by date range
    /// </summary>
    void GenerateRevenueReport();
}
