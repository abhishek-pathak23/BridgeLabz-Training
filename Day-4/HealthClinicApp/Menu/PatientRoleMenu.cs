using System;
using HealthClinicApp.Interface;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    // Patient role menu - shows only what a patient needs to see
    public class PatientRoleMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IVisitHistoryService _visitHistoryService;
        private readonly IBillingService _billingService;
        private readonly IPatientService _patientService;
        private int _patientId;

        public PatientRoleMenu(
            IAppointmentService appointmentService,
            IVisitHistoryService visitHistoryService,
            IBillingService billingService,
            IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _visitHistoryService = visitHistoryService;
            _billingService = billingService;
            _patientService = patientService;
        }

        public void Display()
        {
            Console.Clear();
            Console.Write("Enter your Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out _patientId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid Patient ID.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            // Verify the patient exists
            var patient = _patientService.GetPatientById(_patientId);
            if (patient == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] Patient with ID {_patientId} not found.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"=========================================================");
                Console.WriteLine($"   PATIENT PORTAL  (Welcome, {patient.FullName})");
                Console.WriteLine($"=========================================================");
                Console.ResetColor();
                Console.WriteLine(" 1. View My Appointments");
                Console.WriteLine(" 2. Book New Appointment");
                Console.WriteLine(" 3. View My Visit History & Bills");
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
                        BookAppointment();
                        Pause();
                        break;
                    case "3":
                        ViewVisitHistoryAndBills();
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
            var appointments = _appointmentService.GetAppointmentsByPatientId(_patientId);
            Console.WriteLine($"\n--- MY APPOINTMENTS ---");

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            Console.WriteLine(string.Format("{0,-6} | {1,-22} | {2,-16} | {3,-18} | {4,-12}", "ApptID", "Doctor Name", "Specialization", "Date/Time", "Status"));
            Console.WriteLine(new string('-', 85));

            foreach (var a in appointments)
            {
                Console.WriteLine(string.Format("{0,-6} | {1,-22} | {2,-16} | {3,-18:yyyy-MM-dd HH:mm} | {4,-12}",
                    a.AppointmentID, a.DoctorName, a.Specialization, a.AppointmentDate, a.Status));
            }
        }

        private void BookAppointment()
        {
            Console.WriteLine("\n--- BOOK NEW APPOINTMENT ---");
            Console.Write("Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid Doctor ID.");
                Console.ResetColor();
                return;
            }

            Console.Write("Appointment Date & Time (YYYY-MM-DD HH:MM): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime apptDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid Date Format.");
                Console.ResetColor();
                return;
            }

            try
            {
                int newApptId = _appointmentService.BookAppointment(_patientId, doctorId, apptDate);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SUCCESS] Appointment booked! Appointment ID: {newApptId}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] " + ex.Message);
                Console.ResetColor();
            }
        }

        private void ViewVisitHistoryAndBills()
        {
            var history = _visitHistoryService.GetPatientVisitHistory(_patientId);
            Console.WriteLine($"\n--- MY VISIT HISTORY & BILLS ---");

            if (history.Count == 0)
            {
                Console.WriteLine("No visit history found.");
                return;
            }

            Console.WriteLine(string.Format("{0,-8} | {1,-18} | {2,-20} | {3,-12} | {4,-20}", "ApptID", "Date", "Doctor", "Status", "Bill"));
            Console.WriteLine(new string('-', 88));

            foreach (var v in history)
            {
                string bill = v.TotalAmount.HasValue
                    ? $"Rs.{v.TotalAmount.Value:F0} ({v.PaymentStatus})"
                    : "Not Generated";

                Console.WriteLine(string.Format("{0,-8} | {1,-18:yyyy-MM-dd HH:mm} | {2,-20} | {3,-12} | {4,-20}",
                    v.AppointmentID, v.AppointmentDate, v.DoctorName, v.Status, bill));
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
