using System;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    // Doctor role menu - shows only what a doctor needs
    public class DoctorRoleMenu
    {
        private readonly AppointmentService _appointmentService;
        private readonly VisitHistoryService _visitHistoryService;
        private int _doctorId;

        public DoctorRoleMenu(AppointmentService appointmentService, VisitHistoryService visitHistoryService)
        {
            _appointmentService = appointmentService;
            _visitHistoryService = visitHistoryService;
        }

        public void Display()
        {
            Console.Clear();
            Console.Write("Enter your Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out _doctorId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid Doctor ID.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"=========================================================");
                Console.WriteLine($"   DOCTOR PORTAL  (Doctor ID: {_doctorId})");
                Console.WriteLine($"=========================================================");
                Console.ResetColor();
                Console.WriteLine(" 1. View My Appointments");
                Console.WriteLine(" 2. Update Appointment Status");
                Console.WriteLine(" 0. Logout");
                Console.Write(" Select Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewMyAppointments();
                        Pause();
                        break;
                    case "2":
                        UpdateStatus();
                        Pause();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[ERROR] Invalid choice.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void ViewMyAppointments()
        {
            var appointments = _appointmentService.GetAppointmentsByDoctorId(_doctorId);
            Console.WriteLine($"\n--- MY APPOINTMENTS ---");

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            Console.WriteLine(string.Format("{0,-6} | {1,-20} | {2,-18} | {3,-12}", "ApptID", "Patient Name", "Date/Time", "Status"));
            Console.WriteLine(new string('-', 65));

            foreach (var a in appointments)
            {
                Console.WriteLine(string.Format("{0,-6} | {1,-20} | {2,-18:yyyy-MM-dd HH:mm} | {3,-12}",
                    a.AppointmentID, a.PatientName, a.AppointmentDate, a.Status));
            }
        }

        private void UpdateStatus()
        {
            Console.Write("\nEnter Appointment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int apptId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid Appointment ID.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Select New Status:");
            Console.WriteLine(" 1. Completed");
            Console.WriteLine(" 2. Cancelled");
            Console.Write(" Choice [1-2]: ");
            string status = Console.ReadLine() switch
            {
                "1" => "Completed",
                "2" => "Cancelled",
                _ => ""
            };

            if (string.IsNullOrEmpty(status))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid choice.");
                Console.ResetColor();
                return;
            }

            bool updated = _appointmentService.UpdateAppointmentStatus(apptId, status);
            if (updated)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SUCCESS] Appointment status updated to '{status}'.");
                if (status == "Completed")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[TRIGGER] Auto-billing record created for this completed appointment.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Failed to update status.");
                Console.ResetColor();
            }
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
