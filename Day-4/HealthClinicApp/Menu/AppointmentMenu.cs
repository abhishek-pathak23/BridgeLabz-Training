using System;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentMenu(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- APPOINTMENT SCHEDULING & MANAGEMENT ---");
                Console.ResetColor();
                Console.WriteLine(" 1. View All Appointments");
                Console.WriteLine(" 2. Schedule New Appointment");
                Console.WriteLine(" 3. Update Appointment Status");
                Console.WriteLine(" 4. Cancel Appointment");
                Console.WriteLine(" 0. Back to Main Menu");
                Console.Write(" Select Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllAppointments();
                        Pause();
                        break;
                    case "2":
                        BookAppointment();
                        Pause();
                        break;
                    case "3":
                        UpdateAppointmentStatus();
                        Pause();
                        break;
                    case "4":
                        CancelAppointment();
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

        private void ViewAllAppointments()
        {
            var apps = _appointmentService.GetAllAppointments();
            Console.WriteLine("\n--- ALL APPOINTMENTS ---");
            Console.WriteLine(string.Format("{0,-6} | {1,-20} | {2,-20} | {3,-18} | {4,-12}", "ApptID", "Patient Name", "Doctor Name", "Date/Time", "Status"));
            Console.WriteLine(new string('-', 85));

            foreach (var a in apps)
            {
                Console.WriteLine(string.Format("{0,-6} | {1,-20} | {2,-20} | {3,-18:yyyy-MM-dd HH:mm} | {4,-12}",
                    a.AppointmentID, a.PatientName, a.DoctorName, a.AppointmentDate, a.Status));
            }
        }

        private void BookAppointment()
        {
            Console.WriteLine("\n--- SCHEDULE NEW APPOINTMENT ---");
            Console.Write("Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                ShowError("Invalid Patient ID!");
                return;
            }

            Console.Write("Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                ShowError("Invalid Doctor ID!");
                return;
            }

            Console.Write("Appointment Date & Time (YYYY-MM-DD HH:MM): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime apptDate))
            {
                ShowError("Invalid Date Format!");
                return;
            }

            try
            {
                int newApptId = _appointmentService.BookAppointment(patientId, doctorId, apptDate);
                ShowSuccess($"Appointment scheduled via sp_BookAppointment! Appointment ID: {newApptId}");
            }
            catch (Exception ex)
            {
                ShowError("Error booking appointment: " + ex.Message);
            }
        }

        private void UpdateAppointmentStatus()
        {
            Console.Write("\nEnter Appointment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            Console.WriteLine("Select New Status:");
            Console.WriteLine(" 1. Scheduled");
            Console.WriteLine(" 2. Completed");
            Console.WriteLine(" 3. Cancelled");
            Console.Write(" Choice [1-3]: ");
            string? choice = Console.ReadLine();

            string status = choice switch
            {
                "1" => "Scheduled",
                "2" => "Completed",
                "3" => "Cancelled",
                _ => ""
            };

            if (string.IsNullOrEmpty(status))
            {
                ShowError("Invalid choice.");
                return;
            }

            bool updated = _appointmentService.UpdateAppointmentStatus(id, status);
            if (updated)
            {
                ShowSuccess($"Appointment status updated to '{status}'.");
                if (status == "Completed")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[TRIGGER NOTICE] Automatic billing record generated for completed appointment via trg_AutoGenerateBillOnCompletion!");
                    Console.ResetColor();
                }
            }
            else
            {
                ShowError("Failed to update status.");
            }
        }

        private void CancelAppointment()
        {
            Console.Write("\nEnter Appointment ID to Cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            bool cancelled = _appointmentService.CancelAppointment(id);
            if (cancelled)
                ShowSuccess("Appointment cancelled.");
            else
                ShowError("Failed to cancel appointment.");
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
