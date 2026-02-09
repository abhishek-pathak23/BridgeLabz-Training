using System;

class Clinic
{
    static void Main(string[] args)
    {
        IPatientService patientService = new PatientService();
        IDoctorService doctorService = new DoctorService();
        IAppointmentService appointmentService = new AppointmentService();
        IVisitService visitService = new VisitService();
        IBillingService billingService = new BillingService();
        IAdminService adminService = new AdminService();   // ✅ UC-6

        while (true)
        {
            Console.WriteLine("\n====== HEALTH CLINIC SYSTEM ======");
            Console.WriteLine("1. Patient Management");
            Console.WriteLine("2. Doctor Management");
            Console.WriteLine("3. Appointment Scheduling");
            Console.WriteLine("4. Visit Management");
            Console.WriteLine("5. Billing & Payments");
            Console.WriteLine("6. System Administration");   // ✅ UC-6
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int mainChoice))
                continue;

            switch (mainChoice)
            {
                case 1: PatientMenu(patientService); break;
                case 2: DoctorMenu(doctorService); break;
                case 3: AppointmentMenu(appointmentService); break;
                case 4: VisitMenu(visitService); break;
                case 5: BillingMenu(billingService); break;
                case 6: AdminMenu(adminService); break;   // ✅ FIXED
                case 0:
                    Console.WriteLine("Exiting system...");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    /* ================= PATIENT MENU ================= */
    static void PatientMenu(IPatientService service)
    {
        while (true)
        {
            Console.WriteLine("\n--- Patient Management ---");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Update Patient");
            Console.WriteLine("3. Search Patient");
            Console.WriteLine("4. View Visit History");
            Console.WriteLine("0. Back");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1: service.RegisterPatient(); break;
                case 2: service.UpdatePatient(); break;
                case 3: service.SearchPatient(); break;
                case 4: service.ViewPatientVisitHistory(); break;
                case 0: return;
            }
        }
    }

    /* ================= DOCTOR MENU ================= */
    static void DoctorMenu(IDoctorService service)
    {
        while (true)
        {
            Console.WriteLine("\n--- Doctor Management ---");
            Console.WriteLine("1. Add Doctor Profile");
            Console.WriteLine("2. Update Doctor Specialty");
            Console.WriteLine("3. View Doctors by Specialty");
            Console.WriteLine("4. Deactivate Doctor");
            Console.WriteLine("0. Back");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1: service.AddDoctorProfile(); break;
                case 2: service.UpdateDoctorSpecialty(); break;
                case 3: service.ViewDoctorsBySpecialty(); break;
                case 4: service.DeactivateDoctor(); break;
                case 0: return;
            }
        }
    }

    /* ================= APPOINTMENT MENU ================= */
    static void AppointmentMenu(IAppointmentService service)
    {
        while (true)
        {
            Console.WriteLine("\n--- Appointment Scheduling ---");
            Console.WriteLine("1. Book Appointment");           // UC-3.1
            Console.WriteLine("2. Check Doctor Availability"); // UC-3.2
            Console.WriteLine("3. Cancel Appointment");        // UC-3.3
            Console.WriteLine("4. Reschedule Appointment");    // UC-3.4
            Console.WriteLine("5. View Daily Schedule");       // UC-3.5
            Console.WriteLine("0. Back");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1: service.BookAppointment(); break;
                case 2: service.CheckDoctorAvailability(); break;
                case 3: service.CancelAppointment(); break;
                case 4: service.RescheduleAppointment(); break;
                case 5: service.ViewDailySchedule(); break;
                case 0: return;
            }
        }
    }

    /* ================= VISIT MENU ================= */
    static void VisitMenu(IVisitService service)
    {
        while (true)
        {
            Console.WriteLine("\n--- Visit Management ---");
            Console.WriteLine("1. Record Patient Visit"); // UC-4.1
            Console.WriteLine("2. View Medical History"); // UC-4.2
            Console.WriteLine("3. Add Prescription");    // UC-4.3
            Console.WriteLine("0. Back");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1: service.RecordPatientVisit(); break;
                case 2: service.ViewMedicalHistory(); break;
                case 3: service.AddPrescriptionDetails(); break;
                case 0: return;
            }
        }
    }

    /* ================= BILLING MENU ================= */
    static void BillingMenu(IBillingService service)
    {
        while (true)
        {
            Console.WriteLine("\n--- Billing & Payments ---");
            Console.WriteLine("1. Generate Bill for Visit");  // UC-5.1
            Console.WriteLine("2. Record Payment");          // UC-5.2
            Console.WriteLine("3. View Outstanding Bills");  // UC-5.3
            Console.WriteLine("4. Generate Revenue Report"); // UC-5.4
            Console.WriteLine("0. Back");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1: service.GenerateBill(); break;   // ✅ FIXED
                case 2: service.RecordPayment(); break;
                case 3: service.ViewOutstandingBills(); break;
                case 4: service.GenerateRevenueReport(); break;
                case 0: return;
            }
        }
    }

    /* ================= ADMIN MENU ================= */
    static void AdminMenu(IAdminService service)
    {
        while (true)
        {
            Console.WriteLine("\n--- System Administration ---");
            Console.WriteLine("1. Add Specialty");      // UC-6.1
            Console.WriteLine("2. View Specialties");   // UC-6.1
            Console.WriteLine("3. Delete Specialty");   // UC-6.1
            Console.WriteLine("4. View Audit Logs");    // UC-6.3
            Console.WriteLine("0. Back");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1: service.AddSpecialty(); break;
                case 2: service.ViewSpecialties(); break;
                case 3: service.DeleteSpecialty(); break;
                case 4: service.ViewAuditLogs(); break;
                case 0: return;
            }
        }
    }
}
