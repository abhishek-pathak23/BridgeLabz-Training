using System;
using HealthClinicApp.Entity;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    public class BillingMenu
    {
        private readonly BillingService _billingService;

        public BillingMenu(BillingService billingService)
        {
            _billingService = billingService;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- BILLING & PAYMENT MANAGEMENT ---");
                Console.ResetColor();
                Console.WriteLine(" 1. View All Bills & Payment Statuses");
                Console.WriteLine(" 2. Generate Custom Bill");
                Console.WriteLine(" 3. Update Payment Status");
                Console.WriteLine(" 0. Back to Main Menu");
                Console.Write(" Select Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllBills();
                        Pause();
                        break;
                    case "2":
                        GenerateBill();
                        Pause();
                        break;
                    case "3":
                        UpdatePaymentStatus();
                        Pause();
                        break;
                    case "0":
                        return;
                    default:
                        ShowError("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewAllBills()
        {
            var bills = _billingService.GetAllBills();
            Console.WriteLine("\n--- ALL CLINIC BILLS & INVOICES ---");
            Console.WriteLine(string.Format("{0,-6} | {1,-8} | {2,-18} | {3,-18} | {4,-10} | {5,-10} | {6,-10}",
                "BillID", "ApptID", "Patient Name", "Doctor Name", "Fee", "Tax", "Total", "Status"));
            Console.WriteLine(new string('-', 95));

            foreach (var b in bills)
            {
                Console.WriteLine(string.Format("{0,-6} | {1,-8} | {2,-18} | {3,-18} | {4,-10:F2} | {5,-10:F2} | {6,-10:F2} | {7,-10}",
                    b.BillID, b.AppointmentID, b.PatientName, b.DoctorName, b.ConsultationFee, b.TaxAmount, b.TotalAmount, b.PaymentStatus));
            }
        }

        private void GenerateBill()
        {
            Console.WriteLine("\n--- GENERATE CUSTOM BILL ---");
            Console.Write("Appointment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int apptId))
            {
                ShowError("Invalid Appointment ID!");
                return;
            }

            Console.Write("Consultation Fee (Rs.): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal fee)) fee = 500.00m;

            Console.Write("Tax Amount (Rs.): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tax)) tax = 90.00m;

            try
            {
                int billId = _billingService.GenerateBill(apptId, fee, tax);
                ShowSuccess($"Bill generated successfully! Bill ID: {billId}, Total Amount: Rs. {fee + tax:F2}");
            }
            catch (Exception ex)
            {
                ShowError("Error generating bill: " + ex.Message);
            }
        }

        private void UpdatePaymentStatus()
        {
            Console.Write("\nEnter Bill ID: ");
            if (!int.TryParse(Console.ReadLine(), out int billId))
            {
                ShowError("Invalid Bill ID!");
                return;
            }

            Console.WriteLine("Select Payment Status:");
            Console.WriteLine(" 1. Paid");
            Console.WriteLine(" 2. Pending");
            Console.WriteLine(" 3. Cancelled");
            Console.Write(" Choice [1-3]: ");
            string status = Console.ReadLine() switch
            {
                "1" => "Paid",
                "2" => "Pending",
                "3" => "Cancelled",
                _ => ""
            };

            if (string.IsNullOrEmpty(status))
            {
                ShowError("Invalid choice.");
                return;
            }

            bool updated = _billingService.UpdateBillPaymentStatus(billId, status);
            if (updated)
                ShowSuccess($"Payment status for Bill #{billId} updated to '{status}'.");
            else
                ShowError("Failed to update payment status.");
        }

        private static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] " + msg);
            Console.ResetColor();
        }

        private static void ShowSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[SUCCESS] " + msg);
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
