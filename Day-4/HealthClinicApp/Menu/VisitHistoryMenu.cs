using System;
using System.Data;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    public class VisitHistoryMenu
    {
        private readonly IVisitHistoryService _visitHistoryService;

        public VisitHistoryMenu(IVisitHistoryService visitHistoryService)
        {
            _visitHistoryService = visitHistoryService;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- VISIT HISTORY & SYSTEM AUDIT LOGS ---");
                Console.ResetColor();
                Console.WriteLine(" 1. View Patient Visit History");
                Console.WriteLine(" 2. View Patient Audit Trail");
                Console.WriteLine(" 3. View Appointment Audit Trail");
                Console.WriteLine(" 0. Back to Main Menu");
                Console.Write(" Select Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewVisitHistory();
                        Pause();
                        break;
                    case "2":
                        ViewPatientAudit();
                        Pause();
                        break;
                    case "3":
                        ViewAppointmentAudit();
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

        private void ViewVisitHistory()
        {
            Console.Write("\nEnter Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                ShowError("Invalid Patient ID!");
                return;
            }

            var history = _visitHistoryService.GetPatientVisitHistory(patientId);
            Console.WriteLine($"\n--- VISIT HISTORY FOR PATIENT #{patientId} ---");
            if (history.Count == 0)
            {
                Console.WriteLine("No visit records found for this patient.");
                return;
            }

            Console.WriteLine(string.Format("{0,-8} | {1,-18} | {2,-20} | {3,-15} | {4,-10} | {5,-12}",
                "ApptID", "Date", "Doctor", "Specialization", "Status", "Bill Amount"));
            Console.WriteLine(new string('-', 95));

            foreach (var v in history)
            {
                string billAmt = v.TotalAmount.HasValue ? $"Rs. {v.TotalAmount.Value:F2} ({v.PaymentStatus})" : "N/A";
                Console.WriteLine(string.Format("{0,-8} | {1,-18:yyyy-MM-dd HH:mm} | {2,-20} | {3,-15} | {4,-10} | {5,-12}",
                    v.AppointmentID, v.AppointmentDate, v.DoctorName, v.Specialization, v.Status, billAmt));
            }
        }

        private void ViewPatientAudit()
        {
            var dt = _visitHistoryService.GetPatientAuditLogs();
            Console.WriteLine("\n--- PATIENT AUDIT LOG ---");
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No audit entries recorded.");
                return;
            }

            Console.WriteLine(string.Format("{0,-8} | {1,-10} | {2,-15} | {3,-10} | {4,-20}", "AuditID", "PatientID", "Name", "Action", "ActionDate"));
            Console.WriteLine(new string('-', 75));

            foreach (DataRow row in dt.Rows)
            {
                string name = $"{row["FirstName"]} {row["LastName"]}".Trim();
                Console.WriteLine(string.Format("{0,-8} | {1,-10} | {2,-15} | {3,-10} | {4,-20:yyyy-MM-dd HH:mm:ss}",
                    row["AuditID"], row["PatientID"], name, row["Action"], row["ActionDate"]));
            }
        }

        private void ViewAppointmentAudit()
        {
            var dt = _visitHistoryService.GetAppointmentAuditLogs();
            Console.WriteLine("\n--- APPOINTMENT AUDIT LOG ---");
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No audit entries recorded.");
                return;
            }

            Console.WriteLine(string.Format("{0,-8} | {1,-8} | {2,-12} | {3,-12} | {4,-10} | {5,-20}", "AuditID", "ApptID", "Old Status", "New Status", "Action", "ActionDate"));
            Console.WriteLine(new string('-', 85));

            foreach (DataRow row in dt.Rows)
            {
                string oldSt = row["OldStatus"] != DBNull.Value ? row["OldStatus"].ToString()! : "NULL";
                string newSt = row["NewStatus"] != DBNull.Value ? row["NewStatus"].ToString()! : "NULL";
                Console.WriteLine(string.Format("{0,-8} | {1,-8} | {2,-12} | {3,-12} | {4,-10} | {5,-20:yyyy-MM-dd HH:mm:ss}",
                    row["AuditID"], row["AppointmentID"], oldSt, newSt, row["Action"], row["ActionDate"]));
            }
        }

        private static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] " + msg);
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
