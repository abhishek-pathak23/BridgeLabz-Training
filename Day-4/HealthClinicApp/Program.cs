using System;
using HealthClinicApp.Interface;
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
                // Centralized DB Connection Utility
                var dbUtility = new DBConnectionUtility(connectionString);

                // Instantiate all domain services via interface types
                IPatientService patientService = new PatientService(dbUtility);
                IDoctorService doctorService = new DoctorService(dbUtility);
                IAppointmentService appointmentService = new AppointmentService(dbUtility);
                IVisitHistoryService visitHistoryService = new VisitHistoryService(dbUtility);
                IBillingService billingService = new BillingService(dbUtility);

                // Instantiate domain-specific menus consuming service interfaces
                var patientMenu = new PatientMenu(patientService);
                var doctorMenu = new DoctorMenu(doctorService);
                var appointmentMenu = new AppointmentMenu(appointmentService);
                var visitHistoryMenu = new VisitHistoryMenu(visitHistoryService);
                var billingMenu = new BillingMenu(billingService);

                // Admin menu has full access to all sub-menus
                var adminMenu = new HealthMenu(patientMenu, doctorMenu, appointmentMenu, visitHistoryMenu, billingMenu);

                // Role-specific menus for doctors and patients consuming service interfaces
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
