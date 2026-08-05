# Day 4: ADO.NET & Health Clinic App Completion

## Modular Layered Architecture

The application is structured into clean domain-driven service and presentation layers:

```
Day-4/
├── README.md                   # Documentation
└── HealthClinicApp/            # C# ADO.NET Console Application
    ├── HealthClinicApp.csproj
    ├── Program.cs              # Application Entry Point & Dependency Wiring
    ├── Entity/                 # Domain Entity Models
    │   ├── Patient.cs
    │   ├── Doctor.cs
    │   ├── Appointment.cs
    │   ├── Billing.cs
    │   └── VisitHistory.cs
    ├── Service/                # Domain-Specific ADO.NET Services
    │   ├── PatientService.cs
    │   ├── DoctorService.cs
    │   ├── AppointmentService.cs
    │   ├── BillingService.cs
    │   └── VisitHistoryService.cs
    └── Menu/                   # Feature-Specific Presentation UI Layer
        ├── HealthMenu.cs       # Main Navigator Menu
        ├── PatientMenu.cs
        ├── DoctorMenu.cs
        ├── AppointmentMenu.cs
        ├── BillingMenu.cs
        └── VisitHistoryMenu.cs
```

---

## Database Connection
- **Server**: `localhost\SQLEXPRESS`
- **Database**: `healthappdb`
- **Provider**: `Microsoft.Data.SqlClient` (ADO.NET)
- **Connection String**: `Server=localhost\SQLEXPRESS;Database=healthappdb;Integrated Security=True;TrustServerCertificate=True;`

---

## Features & Implementation Highlights

1. **Patient Management (`PatientService.cs` & `PatientMenu.cs`)**:
   - Registered patients, view details, search by ID, update, and delete patient records via ADO.NET stored procedures.

2. **Doctor & Specialty Management (`DoctorService.cs` & `DoctorMenu.cs`)**:
   - Manage doctor profiles, specialties, phone contact, and experience years.

3. **Appointment Scheduling (`AppointmentService.cs` & `AppointmentMenu.cs`)**:
   - Schedule appointments via `sp_BookAppointment`. Updating status to `Completed` triggers `trg_AutoGenerateBillOnCompletion`.

4. **Visit History & Audit Tracking (`VisitHistoryService.cs` & `VisitHistoryMenu.cs`)**:
   - Retrieve visit history via `sp_GetPatientVisitHistory` and inspect real-time trigger audit logs (`PatientAudit` & `AppointmentAudit`).

5. **Billing & Invoicing (`BillingService.cs` & `BillingMenu.cs`)**:
   - Manage auto-generated or manual bills, tax calculation, and payment status transitions (`Pending`, `Paid`, `Cancelled`).

---

## How to Run

Build and run the C# console application:
```bash
cd HealthClinicApp
dotnet run
```
