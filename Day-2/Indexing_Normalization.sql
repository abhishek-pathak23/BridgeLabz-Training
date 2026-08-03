-- Day 2 Assignment: Schema Extension & Indexing Analysis

-- 1. Extend schema: Rooms and Doctor-Room relationship
CREATE TABLE rooms (
    room_id INT PRIMARY KEY IDENTITY(1,1),
    room_number VARCHAR(20) NOT NULL UNIQUE,
    floor_number INT NOT NULL
);

CREATE TABLE doctor_room (
    doctor_id INT NOT NULL,
    room_id INT NOT NULL,
    assigned_date DATE NOT NULL,
    PRIMARY KEY (doctor_id, room_id, assigned_date),
    FOREIGN KEY (doctor_id) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (room_id) REFERENCES rooms(room_id)
);


-- 2. EXPLAIN / Execution Plan Analysis Queries

-- Query 1: Filter on non-indexed column (Full Table Scan)
SELECT * FROM Appointments 
WHERE Status = 'Completed';

-- Query 2: Filter using single-column index (Index Seek / Range Scan)
SELECT * FROM Appointments 
WHERE PatientID = 5;

-- Query 3: Filter using composite index
SELECT * FROM Appointments 
WHERE DoctorID = 2 AND AppointmentDate = '2026-08-01';


-- 3. Normalized patient_phones table (1NF, 2NF, 3NF)
CREATE TABLE patient_phones (
    patient_id INT NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    phone_type VARCHAR(20) DEFAULT 'Mobile',
    PRIMARY KEY (patient_id, phone_number),
    FOREIGN KEY (patient_id) REFERENCES Patients(PatientID)
);


-- 4. Covering Index
CREATE INDEX idx_appointments_covering 
ON Appointments(DoctorID, AppointmentDate, Status);

-- Verify covering index (Extra: Using index)
SELECT DoctorID, AppointmentDate, Status 
FROM Appointments 
WHERE DoctorID = 2;

SELECT name, type_desc
FROM sys.indexes
WHERE object_id = OBJECT_ID('Appointments');


----------------------------------INDEXING AND NORMALIZATION------------------------------------
-- Index on PatientID
CREATE INDEX IX_Appointments_PatientID
ON Appointments(PatientID);

-- Index on DoctorID
CREATE INDEX IX_Appointments_DoctorID
ON Appointments(DoctorID);

-- Index on AppointmentDate
CREATE INDEX IX_Appointments_Date
ON Appointments(AppointmentDate);

-- Verifying Index

EXEC sp_helpindex 'Appointments';