using System;
using HealthClinicApp.Menu;
using HealthClinicApp.Service;

namespace HealthClinicApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string connectionString = "Server=localhost\\SQLEXPRESS;Database=healthappdb;Integrated Security=True;TrustServerCertificate=True;";

            Console.Title = "Health Clinic Management App - Day 4 ADO.NET";

            try
            {
                // Instantiate all domain services
                var patientService = new PatientService(connectionString);
                var doctorService = new DoctorService(connectionString);
                var appointmentService = new AppointmentService(connectionString);
                var visitHistoryService = new VisitHistoryService(connectionString);
                var billingService = new BillingService(connectionString);

                // Instantiate domain-specific menus
                var patientMenu = new PatientMenu(patientService);
                var doctorMenu = new DoctorMenu(doctorService);
                var appointmentMenu = new AppointmentMenu(appointmentService);
                var visitHistoryMenu = new VisitHistoryMenu(visitHistoryService);
                var billingMenu = new BillingMenu(billingService);

                // Admin menu has full access to all sub-menus
                var adminMenu = new HealthMenu(patientMenu, doctorMenu, appointmentMenu, visitHistoryMenu, billingMenu);

                // Role-specific menus for doctors and patients
                var doctorRoleMenu = new DoctorRoleMenu(appointmentService, visitHistoryService);
                var patientRoleMenu = new PatientRoleMenu(appointmentService, visitHistoryService, billingService, patientService);

                // Role selector is the first screen shown to the user
                var roleMenu = new RoleMenu(adminMenu, doctorRoleMenu, patientRoleMenu);
                roleMenu.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fatal Application Error: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
