# Backend Refresher Training

## Progress

### Day-1 (31 July 2026)

Topics Covered:
- RDBMS Basics
- SQL Server
- Primary Key
- Foreign Key
- ER Diagram

Completed:
- Created Health Clinic Database Schema
- Created ER Diagram
- Added Tables with PK and FK

### Day-2 (3 August 2026)

#### Topics Covered:
- ER Diagram & Relationship Cardinality
- Table Indexing & Execution Plans
- Normalization (1NF, 2NF, 3NF, BCNF)

#### Completed:
- Extended Schema (`rooms`, `doctor_room`, `patient_phones`)
- Verified 1NF, 2NF, 3NF Normalization
- Implemented Indexes & Covering Index on `Appointments`
- Finalized Day 2 ER Diagram

### Day-3 (4 August 2026)

#### Topics Covered:
- SQL Joins (Inner, Left, Right, Full Outer)
- Stored Procedures
- Triggers & Audit Tables

#### Completed:
- Wrote join queries across Patients, Doctors & Appointments
- Created stored procedures for booking and status updates
- Built audit tables (`PatientAudit`, `AppointmentAudit`)
- Implemented AFTER INSERT/UPDATE/DELETE triggers for automated visit history tracking
- Added `SeedData.sql` script to populate sample data across all tables

### Day-4 (5 August 2026)

#### Topics Covered:
- ADO.NET (`Microsoft.Data.SqlClient`)
- Modular Layered Architecture (Entity, Service, Menu/UI)
- Integration of SQL Stored Procedures & Triggers with C#
- Interactive Console Application Navigation

#### Completed:
- Built full C# Console Application (`HealthClinicApp`) using ADO.NET
- Created entity models (`Patient`, `Doctor`, `Appointment`, `Billing`, `VisitHistory`)
- Implemented ADO.NET data access services with parameterized queries and stored procedure execution
- Implemented menu-driven UI supporting Patient, Doctor, Appointment, Audit Log & Billing management