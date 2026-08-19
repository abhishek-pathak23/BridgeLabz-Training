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
- Built `GreetingModel` as data model  (Model layer)
- Implemented `IGreetingService` & `GreetingService` for business logic and in-memory repository
- Created MVC `GreetingController` with Razor Views (`Index.cshtml`, `Edit.cshtml`) for web UI (Controller & View layers)
- Built `GreetingsApiController` with full REST HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`), query parameters, and status responses
- Configured Swagger UI and live interactive API testing client

### Day-7 (10 August 2026)

#### Topics Covered:
- Backend Basics & Minimal APIs in ASP.NET Core
- Lightweight Endpoint Definitions & Route Mapping (`MapGroup`, `MapGet`, `MapPost`, `MapPut`, `MapDelete`)
- Dependency Injection with Services & Models in Minimal APIs
- OpenAPI / Swagger Integration & Interactive Web Dashboard

#### Completed:
- Scaffolded Contacts App Minimal API project (`Day-7/ContactsApi`)
- Created `Contact` domain model and DTO records (`CreateContactDto`, `UpdateContactDto`)
- Implemented `IContactService` and thread-safe `ContactService` with seed data
- Defined modular Minimal API endpoints in Program.cs with full CRUD support, search, and category filtering
- Configured Swashbuckle OpenAPI / Swagger UI integration for interactive API testing

### Day-8 (11 August 2026)

#### Topics Covered:
- H2 Database & ADO.NET wrapper (H2Sharp / H2SharpADO.NET50)
- Repository Layer Pattern with ADO.NET
- Postman API Testing with embedded test scripts
- RestAssured.Net for automated API endpoint testing

#### Completed:
- Continued Contacts App backend — added H2 in-memory database (`Day-8/ContactsApi`)
- Created `IContactRepository` interface and `ContactRepository` with ADO.NET (`System.Data.H2`) for CRUD operations
- Added `DatabaseInitializer` for automatic H2 table creation and seed data on startup
- Updated Minimal API endpoints to use Repository layer via Dependency Injection
- Created Postman collection (`Contacts_API_Day8.postman_collection.json`) with test scripts for all endpoints
- Added RestAssured.Net xUnit test suite (`RestAssuredApiTests.cs`) directly inside the project testing 3 API endpoints (GET all, POST create, GET by ID)

### Day-9 (12 August 2026)

#### Topics Covered:
- ORM concepts; Entity Framework introduction
- WebAPI-powered REST API with EF
- Dependency Injection in ASP.NET Core

#### Completed:
- Bootstrapped Entity Framework in a new WebAPI project (`Day-9/ContactsApiEF`)
- Created `ContactsDbContext` with EF Core connected to SQL Server Express (`localhost\SQLEXPRESS`)
- Configured Dependency Injection for `DbContext` and EF Core repository `EfContactRepository`
- Applied EF Core Migrations (`InitialCreate`) to auto-create the `ContactsDb` database and `Contacts` table with seed data
- Migrated the Contacts App backend endpoints to use Entity Framework Core while retaining the Repository Pattern architecture

### Day-10 (13 August 2026)

#### Topics Covered:
- Backend w/ Entity Framework & H2 Database integration (`H2Sharp8_v14200.Driver`)
- Dynamic connection string configuration via `appsettings.json` (no hardcoding)
- LINQ to Entities — querying via LINQ (`Where`, `FirstOrDefaultAsync`, `ToListAsync`, `OrderBy`)
- 4-Tier Clean Architecture Solution (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `EmployeePayrollApp`)
- Layer-specific Interfaces & Services (`IEmployeeRL`/`EmployeeRL`, `IEmployeeBL`/`EmployeeBL`)

#### Completed:
- Scaffolded full solution `Day-10/EmployeePayrollApp` containing 4 projects (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `EmployeePayrollApp`)
- Implemented `ModelLayer` with `Employee` model, DTOs, and `EmployeeDbContext`
- Implemented `RepositoryLayer` with `IEmployeeRL` interface in `Interface/` and `EmployeeRL` service in `Service/` utilizing LINQ to Entities
- Implemented `BusinessLayer` with `IEmployeeBL` interface in `Interface/` and `EmployeeBL` service in `Service/` enforcing business validations
- Configured dynamic connection string & H2 database properties in `appsettings.json` without hardcoding
- Built `EmployeeController` REST API supporting full CRUD operations, department filtering, and search
- Successfully built solution (`0 Warnings, 0 Errors`) and verified HTTP endpoints (`GET`, `POST`, `PUT`, `DELETE`)

### Day-11 (14 August 2026)

#### Topics Covered:
- Backend w/ Entity Framework — Schema Evolution & DbContext Lifecycle
- EF Core Migrations (`dotnet ef migrations add InitialCreate`, `Database.Migrate()`)
- Database Schema Seeding (`OnModelCreating` seed data)
- 4-Tier Clean Architecture for **Employee Payroll App** backend

#### Completed:
- Built `Day-11/EmployeePayrollApp` 4-tier solution (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `EmployeePayrollApp`) with EF Core SQL Server provider and EF Migrations
- Implemented `EmployeeDbContext` with model seeding and automated migration execution on application startup
- Retained full CRUD REST API in `EmployeeController` with department filtering and search
- Verified solution compiles cleanly (`0 Warnings, 0 Errors`) and EF Core migrations (`InitialCreate`) execute successfully

### Day-12 (17 August 2026)

#### Topics Covered:
- Advanced Backend Development — WebAPI REST Verbs, HttpClient & Action Methods
- WebAPI REST Verbs — `GET` / `POST` / `PUT` / `PATCH` / `DELETE`
- Action Methods in ASP.NET Core Controllers
- HttpClient for consuming external REST APIs
- Password Encryption using HMAC-SHA512 salted hashing
- 4-Tier Clean Architecture for **Fundoo Notes App — User Management Module**

#### Completed:
- Scaffolded `Day-12/FundooNotesApp` 4-tier solution (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `FundooNotesApp`)
- Implemented `User` entity model with `PasswordHash`, `PasswordSalt`, `ResetToken`, `ResetTokenExpiry` fields
- Created DTOs: `UserRegisterDto`, `UserLoginDto`, `ForgotPasswordDto`, `ResetPasswordDto`, `UpdateUserDto`, `PatchEmailDto`, `UserResponseDto`
- Implemented `FundooDbContext` with unique email index constraint and EF Core Migrations (`InitialCreate`)
- Implemented `IPasswordHasher`/`PasswordHasher` with salted HMAC-SHA512 password encryption and verification
- Implemented `IUserService`/`UserService` handling user registration, authentication, password recovery, and profile updates
- Built `IExternalQuoteService`/`ExternalQuoteService` demonstrating `HttpClient` consuming external REST APIs
- Built `UserController` with Action Methods covering all REST verbs:
  - `POST /api/User/register` — User registration with encrypted password
  - `POST /api/User/login` — User authentication and verification
  - `POST /api/User/forgot-password` — Generate password recovery token (30-min expiry)
  - `POST /api/User/reset-password` — Password reset with valid token
  - `GET /api/User` — Retrieve all users
  - `GET /api/User/{id}` — Retrieve user by ID
  - `PUT /api/User/{id}` — Full profile update
  - `PATCH /api/User/{id}/email` — Partial email update
  - `DELETE /api/User/{id}` — Delete user account
  - `GET /api/User/quote` — External API consumption via HttpClient
- Configured Swagger UI with root auto-redirect (`GET / -> /swagger`)
- Verified solution compiles cleanly (`0 Warnings, 0 Errors`) and EF Core migrations (`InitialCreate`) execute successfully

### Day-13 (18 August 2026)

#### Topics Covered:
- Advanced Backend Development — Dependency Injection Deep-Dive, Routing, Reverse Proxy & CORS
- Dependency Injection Deep-Dive: Service Lifecycles (`Transient`, `Scoped`, `Singleton`), Lifecycle Tracking, Clean Extension Registration
- Routing Configuration: Route Constraints (`int:min(1)`, `regex`, `range`, `datetime`), Optional Parameters (`{role?}`), Route Prefixes & Token Replacement
- Reverse Proxy Concepts: `ForwardedHeadersOptions` (`X-Forwarded-For`, `X-Forwarded-Proto`, `X-Forwarded-Host`), Reverse Proxy Header Forwarding Middleware (`UseForwardedHeaders`), Client IP Resolution
- CORS (Cross-Origin Resource Sharing): Named Policies (`FundooFrontendPolicy`, `AllowAll`), Middleware (`UseCors`), Controller-Level `[EnableCors]`
- 4-Tier Clean Architecture for **Fundoo Notes App — Authentication & Authorization Module (Groundwork)**

#### Completed:
- Scaffolded `Day-13/FundooNotesApp` 4-tier solution (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `FundooNotesApp`)
- Extended `User` entity model with `Role` column (supporting `"User"` and `"Admin"` roles, default `"User"`)
- Created updated DTOs (`UserRegisterDto` with `Role`, `UserLoginDto`, `AuthResponseDto`, `UserResponseDto`, `ClaimsDebugDto`)
- Created `FundooDbContext` and generated EF Core Migrations (`InitialCreate`) applying schema updates to SQL Server (`FundooNotesDb_Day13`)
- Implemented Dependency Injection Deep-Dive services (`ITransientLifecycleService`, `IScopedLifecycleService`, `ISingletonLifecycleService`, `IDiLifecycleTracker`) and modular registration extension `AddFundooApplicationServices`
- Implemented `DiDemoController` (`GET /api/DiDemo/inspect`, `GET /api/DiDemo/summary`) demonstrating lifecycle behaviors across HTTP requests
- Implemented `RoutingDemoController` demonstrating route constraints (`int:min(1)`, regex code format, range, datetime, and optional parameters)
- Configured Reverse Proxy `ForwardedHeadersOptions` & `UseForwardedHeaders` middleware with `ProxyDemoController` (`GET /api/ProxyDemo/echo`)
- Configured CORS policies in `Program.cs` (`FundooFrontendPolicy` with restricted origins, credentials, and methods; `AllowAll` for public access)
- Implemented Authentication & Authorization groundwork:
  - Custom `GroundworkAuthHandler` handling Bearer authentication headers and producing `ClaimsPrincipal`
  - Authorization policies (`AdminOnly`, `UserOnly`)
  - `IAuthService`/`AuthService` handling registration, credential verification, and groundwork token generation/validation
  - `ICurrentUserService`/`CurrentUserService` resolving authenticated user context from `HttpContext`
  - `AuthController` with endpoints:
    - `POST /api/auth/register` — Register account with role assignment
    - `POST /api/auth/login` — Authenticate credentials and return Groundwork Token
    - `GET /api/auth/me` — Retrieve current authenticated user profile (`[Authorize]`)
    - `GET /api/auth/claims` — Inspect resolved claims and authentication identity (`[Authorize]`)
    - `GET /api/auth/admin-only` — Role-restricted endpoint (`[Authorize(Roles = "Admin")]`)
    - `GET /api/auth/user-only` — User/Admin authorized endpoint (`[Authorize(Roles = "User,Admin")]`)
    - `POST /api/auth/forgot-password` & `POST /api/auth/reset-password` — Password recovery flow
  - `UserController` with role-aware CRUD and route constraints:
    - `GET /api/User` — Restricted to `Admin` role
    - `GET /api/User/{id:int:min(1)}` — Authenticated user access (admins or self)
    - `PUT /api/User/{id:int:min(1)}` — Authenticated profile update
    - `PATCH /api/User/{id:int:min(1)}/email` — Authenticated email update
    - `DELETE /api/User/{id:int:min(1)}` — Restricted to `Admin` role
    - `GET /api/User/quote` — Public external quote API consumption via `HttpClient`
- Configured Swagger UI with Groundwork Bearer Token security definition and root auto-redirect (`GET / -> /swagger`)
- Verified solution compiles cleanly (`0 Warnings, 0 Errors`) and all automated tests in `verify_day13.ps1` execute successfully

### Day-14 (19 August 2026)

#### Topics Covered:
- Advanced Backend Development — Notes Management & JWT Authentication Integration
- Securing Endpoints with `[Authorize]` and JWT Claims extraction
- Entity Framework Relationships (User -> Notes)
- 4-Tier Clean Architecture for **Fundoo Notes App — Notes Module**

#### Completed:
- Scaffolded `Day-14/FundooNotesApp` 4-tier solution (`ModelLayer`, `RepositoryLayer`, `BusinessLayer`, `FundooNotesApp`)
- Implemented `Note` entity model
- Created DTOs: `CreateNoteDto`
- Implemented `INoteService`/`NoteService` handling note creation, retrieval, and deletion with ownership validation
- Built `NotesController` with Action Methods covering:
  - `POST /api/notes` — Create note (UserId and Email extracted securely from JWT claims)
  - `GET /api/notes` — Retrieve all notes for the authenticated user
  - `DELETE /api/notes/{id}` — Delete a note by Id (with ownership validation)
- Integrated JWT token extraction via `ICurrentUserService` to map `sub` claim to `UserId` and `email` claim to `Email`
- Enforced data security and ownership — users can only view and delete their own notes
- Verified solution compiles cleanly (`0 Warnings, 0 Errors`)