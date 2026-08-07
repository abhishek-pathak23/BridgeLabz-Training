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

### Day-5 (6 August 2026)

#### Topics Covered:
- Introduction to ASP.NET Core and ASP.NET WebAPI
- RESTful Services — principles and design
- Controllers, Routing, HTTP Verbs & Status Codes
- Swagger / OpenAPI for API documentation

#### Completed:
- Scaffolded basic ASP.NET Core WebAPI project (`GreetingAPI`)
- Created `GreetingItem` model as a REST resource
- Built `GreetingsController` with full CRUD — GET, POST, PUT, DELETE
- Applied attribute routing (`[Route]`, `[HttpGet]`, `[HttpPost]`, `[HttpPut]`, `[HttpDelete]`)
- Configured Swagger UI for interactive API documentation and testing

### Day-6 (7 August 2026)

#### Topics Covered:
- Model-View-Controller (MVC) Pattern
- C# REST API calls and Request/Response handling
- HTTP Protocol, Controllers, Routing

#### Completed:
- Scaffolded 'My Greetings App' ASP.NET Core MVC & REST WebAPI project (`Day-6/GreetingsApp`)
- Built `GreetingModel` as data model (Model layer)
- Implemented `IGreetingService` & `GreetingService` for business logic and in-memory repository
- Created MVC `GreetingController` with Razor Views (`Index.cshtml`, `Edit.cshtml`) for web UI (Controller & View layers)
- Built `GreetingsApiController` with full REST HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`), query parameters, and status responses
- Configured Swagger UI and live interactive API testing client