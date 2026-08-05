using System;

namespace HealthClinicApp.Menu
{
    public class HealthMenu
    {
        private readonly PatientMenu _patientMenu;
        private readonly DoctorMenu _doctorMenu;
        private readonly AppointmentMenu _appointmentMenu;
        private readonly VisitHistoryMenu _visitHistoryMenu;
        private readonly BillingMenu _billingMenu;

        public HealthMenu(
            PatientMenu patientMenu,
            DoctorMenu doctorMenu,
            AppointmentMenu appointmentMenu,
            VisitHistoryMenu visitHistoryMenu,
            BillingMenu billingMenu)
        {
            _patientMenu = patientMenu;
            _doctorMenu = doctorMenu;
            _appointmentMenu = appointmentMenu;
            _visitHistoryMenu = visitHistoryMenu;
            _billingMenu = billingMenu;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========================================================");
                Console.WriteLine("             HEALTH CLINIC MANAGEMENT APP                ");
                Console.WriteLine("=========================================================");
                Console.ResetColor();

                Console.WriteLine(" 1. Patient Management");
                Console.WriteLine(" 2. Doctor & Specialty Management");
                Console.WriteLine(" 3. Schedule & Manage Appointments");
                Console.WriteLine(" 4. Track Patient Visit History & Audit Logs");
                Console.WriteLine(" 5. Billing & Payment Management");
                Console.WriteLine(" 0. Exit Application");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write(" Select Choice [0-5]: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _patientMenu.Display();
                        break;
                    case "2":
                        _doctorMenu.Display();
                        break;
                    case "3":
                        _appointmentMenu.Display();
                        break;
                    case "4":
                        _visitHistoryMenu.Display();
                        break;
                    case "5":
                        _billingMenu.Display();
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nThank you for using Health Clinic Management App!");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[ERROR] Invalid selection. Press Enter to retry.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
