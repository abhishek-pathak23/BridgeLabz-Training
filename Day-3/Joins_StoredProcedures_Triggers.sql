-- Day 3: Joins, Stored Procedures & Triggers
USE healthappdb;
GO

-- 1. SQL JOINS


-- Inner Join: Appointments with patient and doctor info
SELECT a.AppointmentID, p.FirstName, p.LastName, d.DoctorName, d.Specialization,
       a.AppointmentDate, a.Status
FROM Appointments a
INNER JOIN Patients p ON a.PatientID = p.PatientID
INNER JOIN Doctors d ON a.DoctorID = d.DoctorID;

-- Left Join: All patients including those without appointments
SELECT p.PatientID, p.FirstName, p.LastName, a.AppointmentID, a.AppointmentDate, a.Status
FROM Patients p
LEFT JOIN Appointments a ON p.PatientID = a.PatientID;

-- Right Join: All doctors including those with no appointments
SELECT d.DoctorID, d.DoctorName, a.AppointmentID, a.AppointmentDate
FROM Appointments a
RIGHT JOIN Doctors d ON a.DoctorID = d.DoctorID;

-- Full Outer Join: All patients and doctors through appointments
SELECT p.FirstName, p.LastName, d.DoctorName, a.AppointmentDate, a.Status
FROM Patients p
FULL OUTER JOIN Appointments a ON p.PatientID = a.PatientID
FULL OUTER JOIN Doctors d ON a.DoctorID = d.DoctorID;
GO


-- 2. STORED PROCEDURES

-- Book a new appointment with basic validation
CREATE OR ALTER PROCEDURE sp_BookAppointment
    @PatientID INT,
    @DoctorID INT,
    @AppointmentDate DATETIME
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientID = @PatientID)
    BEGIN
        PRINT 'Patient not found'; RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Doctors WHERE DoctorID = @DoctorID)
    BEGIN
        PRINT 'Doctor not found'; RETURN;
    END

    INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, Status)
    VALUES (@PatientID, @DoctorID, @AppointmentDate, 'Scheduled');

    PRINT 'Appointment booked successfully';
END;
GO

-- Update appointment status
CREATE OR ALTER PROCEDURE sp_UpdateAppointmentStatus
    @AppointmentID INT,
    @NewStatus VARCHAR(20)
AS
BEGIN
    UPDATE Appointments SET Status = @NewStatus WHERE AppointmentID = @AppointmentID;

    IF @@ROWCOUNT = 0
        PRINT 'Appointment not found';
    ELSE
        PRINT 'Status updated to ' + @NewStatus;
END;
GO

-- 3. AUDIT TABLES & TRIGGERS


-- Audit table for patient changes
IF OBJECT_ID('PatientAudit', 'U') IS NULL
BEGIN
    CREATE TABLE PatientAudit (
        AuditID     INT PRIMARY KEY IDENTITY(1,1),
        PatientID   INT,
        FirstName   VARCHAR(50),
        LastName    VARCHAR(50),
        Phone       VARCHAR(15),
        Action      VARCHAR(10),
        ActionDate  DATETIME DEFAULT GETDATE(),
        ActionBy    NVARCHAR(128) DEFAULT SYSTEM_USER
    );
END;
GO

-- Audit table for appointment changes (visit history tracking)
IF OBJECT_ID('AppointmentAudit', 'U') IS NULL
BEGIN
    CREATE TABLE AppointmentAudit (
        AuditID         INT PRIMARY KEY IDENTITY(1,1),
        AppointmentID   INT,
        PatientID       INT,
        DoctorID        INT,
        OldStatus       VARCHAR(20),
        NewStatus       VARCHAR(20),
        Action          VARCHAR(10),
        ActionDate      DATETIME DEFAULT GETDATE(),
        ActionBy        NVARCHAR(128) DEFAULT SYSTEM_USER
    );
END;
GO

-- AFTER INSERT: log new patient registration
CREATE OR ALTER TRIGGER trg_Patient_Insert
ON Patients
AFTER INSERT
AS
BEGIN
    INSERT INTO PatientAudit (PatientID, FirstName, LastName, Phone, Action)
    SELECT PatientID, FirstName, LastName, Phone, 'INSERT' FROM inserted;
END;
GO

-- AFTER UPDATE: log patient record changes (saves old values)
CREATE OR ALTER TRIGGER trg_Patient_Update
ON Patients
AFTER UPDATE
AS
BEGIN
    INSERT INTO PatientAudit (PatientID, FirstName, LastName, Phone, Action)
    SELECT PatientID, FirstName, LastName, Phone, 'UPDATE' FROM deleted;
END;
GO

-- AFTER DELETE: log patient removal
CREATE OR ALTER TRIGGER trg_Patient_Delete
ON Patients
AFTER DELETE
AS
BEGIN
    INSERT INTO PatientAudit (PatientID, FirstName, LastName, Phone, Action)
    SELECT PatientID, FirstName, LastName, Phone, 'DELETE' FROM deleted;
END;
GO

-- AFTER INSERT: log new appointment booking
CREATE OR ALTER TRIGGER trg_Appointment_Insert
ON Appointments
AFTER INSERT
AS
BEGIN
    INSERT INTO AppointmentAudit (AppointmentID, PatientID, DoctorID, OldStatus, NewStatus, Action)
    SELECT AppointmentID, PatientID, DoctorID, NULL, Status, 'INSERT' FROM inserted;
END;
GO

-- AFTER UPDATE: log appointment status changes with old and new values
CREATE OR ALTER TRIGGER trg_Appointment_Update
ON Appointments
AFTER UPDATE
AS
BEGIN
    INSERT INTO AppointmentAudit (AppointmentID, PatientID, DoctorID, OldStatus, NewStatus, Action)
    SELECT i.AppointmentID, i.PatientID, i.DoctorID, d.Status, i.Status, 'UPDATE'
    FROM inserted i
    INNER JOIN deleted d ON i.AppointmentID = d.AppointmentID;
END;
GO

-- AFTER DELETE: log appointment removal
CREATE OR ALTER TRIGGER trg_Appointment_Delete
ON Appointments
AFTER DELETE
AS
BEGIN
    INSERT INTO AppointmentAudit (AppointmentID, PatientID, DoctorID, OldStatus, NewStatus, Action)
    SELECT AppointmentID, PatientID, DoctorID, Status, NULL, 'DELETE' FROM deleted;
END;
GO

-- 4. TESTING TRIGGERS


-- Test patient triggers
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, Phone)
VALUES ('Test', 'User', '1995-06-15', 'Male', '9876500001');

UPDATE Patients SET Phone = '9876500002' WHERE FirstName = 'Test' AND LastName = 'User';

DELETE FROM Patients WHERE FirstName = 'Test' AND LastName = 'User';

SELECT * FROM PatientAudit;
GO

-- Test appointment triggers
EXEC sp_BookAppointment @PatientID = 1, @DoctorID = 1, @AppointmentDate = '2026-10-01 09:00';

EXEC sp_UpdateAppointmentStatus @AppointmentID = 1, @NewStatus = 'Completed';

SELECT * FROM AppointmentAudit;
GO
