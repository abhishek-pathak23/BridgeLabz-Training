/* ======================================================
   HEALTH CLINIC DATABASE PROJECT
====================================================== */

CREATE DATABASE HealthClinicDB;
GO
USE HealthClinicDB;
GO

/* =======================
   SPECIALTIES
======================= */
CREATE TABLE Specialties(
 specialty_id INT IDENTITY PRIMARY KEY,
 specialty_name VARCHAR(100) UNIQUE NOT NULL
);

/* =======================
   PATIENTS
======================= */
CREATE TABLE Patients(
 patient_id INT IDENTITY PRIMARY KEY,
 name VARCHAR(150),
 dob DATE,
 phone VARCHAR(15) UNIQUE,
 address VARCHAR(255),
 blood_group VARCHAR(10)
);

/* =======================
   DOCTORS
======================= */
CREATE TABLE Doctors(
 doctor_id INT IDENTITY PRIMARY KEY,
 name VARCHAR(150),
 contact VARCHAR(15),
 consultation_fee DECIMAL(10,2),
 specialty_id INT,
 is_active BIT DEFAULT 1,
 FOREIGN KEY(specialty_id)
 REFERENCES Specialties(specialty_id)
);

/* =======================
   APPOINTMENTS
======================= */
CREATE TABLE Appointments(
 appointment_id INT IDENTITY PRIMARY KEY,
 patient_id INT,
 doctor_id INT,
 appointment_date DATE,
 appointment_time TIME,
 status VARCHAR(50) DEFAULT 'SCHEDULED',
 FOREIGN KEY(patient_id) REFERENCES Patients(patient_id),
 FOREIGN KEY(doctor_id) REFERENCES Doctors(doctor_id)
);

/* =======================
   VISITS
======================= */
CREATE TABLE Visits(
 visit_id INT IDENTITY PRIMARY KEY,
 appointment_id INT UNIQUE,
 diagnosis VARCHAR(255),
 notes VARCHAR(500),
 visit_date DATETIME DEFAULT GETDATE(),
 FOREIGN KEY(appointment_id)
 REFERENCES Appointments(appointment_id)
);

/* =======================
   PRESCRIPTIONS
======================= */
CREATE TABLE Prescriptions(
 prescription_id INT IDENTITY PRIMARY KEY,
 visit_id INT,
 medicine_name VARCHAR(100),
 dosage VARCHAR(50),
 duration VARCHAR(50),
 FOREIGN KEY(visit_id)
 REFERENCES Visits(visit_id)
);

/* =======================
   BILLS
======================= */
CREATE TABLE Bills(
 bill_id INT IDENTITY PRIMARY KEY,
 visit_id INT UNIQUE,
 total_amount DECIMAL(10,2),
 payment_status VARCHAR(50) DEFAULT 'UNPAID',
 FOREIGN KEY(visit_id)
 REFERENCES Visits(visit_id)
);

/* =======================
   AUDIT LOG
======================= */
CREATE TABLE Audit_Log(
 audit_id INT IDENTITY PRIMARY KEY,
 table_name VARCHAR(100),
 action_type VARCHAR(50),
 action_time DATETIME DEFAULT GETDATE()
);

/* =======================
   INDEXES
======================= */
CREATE INDEX idx_patient_phone ON Patients(phone);
CREATE INDEX idx_appointment_date ON Appointments(appointment_date);

/* =======================
   TRIGGER
======================= */
GO
CREATE TRIGGER trg_AppointmentAudit
ON Appointments
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
 INSERT INTO Audit_Log(table_name,action_type)
 VALUES('Appointments','DATA_CHANGED');
END;
GO

/* =======================
   SAMPLE DATA INSERTS
======================= */

INSERT INTO Specialties VALUES
('Cardiology'),
('Neurology'),
('Orthopedic'),
('Dermatology'),
('General Physician');

INSERT INTO Patients(name,dob,phone,address,blood_group) VALUES
('Rahul Sharma','1998-05-10','9876543210','Delhi','B+'),
('Aman Verma','1995-02-02','9876500000','Noida','O+'),
('Priya Singh','2000-09-12','9876501111','Lucknow','A+'),
('Neha Kapoor','1992-01-25','9876502222','Kanpur','AB+'),
('Rohit Gupta','1988-07-30','9876503333','Agra','O-');

INSERT INTO Doctors(name,contact,consultation_fee,specialty_id)
VALUES
('Dr Mehta','9999999999',500,1),
('Dr Gupta','8888888888',600,2),
('Dr Arjun','7777777777',400,3),
('Dr Sneha','6666666666',450,4),
('Dr Rakesh','5555555555',350,5);

INSERT INTO Appointments(patient_id,doctor_id,appointment_date,appointment_time)
VALUES
(1,1,'2026-02-10','10:00'),
(2,2,'2026-02-10','11:00'),
(3,3,'2026-02-11','09:30'),
(4,4,'2026-02-11','12:00'),
(5,5,'2026-02-12','14:00');

/* =======================
   TRANSACTIONS
======================= */

BEGIN TRANSACTION;

INSERT INTO Visits(appointment_id,diagnosis,notes)
VALUES
(1,'Fever','Take rest'),
(2,'Migraine','Reduce screen time'),
(3,'Fracture','Apply cast');

INSERT INTO Bills(visit_id,total_amount)
VALUES
(1,700),
(2,900),
(3,1200);

COMMIT;

/* =======================
   PRESCRIPTIONS
======================= */
INSERT INTO Prescriptions(visit_id,medicine_name,dosage,duration)
VALUES
(1,'Paracetamol','2 times/day','5 days'),
(2,'Painkiller','1 time/day','7 days'),
(3,'Calcium','2 times/day','15 days');

/* =======================
   INDUSTRY QUERIES
======================= */

/* ALL PATIENTS */
SELECT * FROM Patients;

/* ALL DOCTORS */
SELECT * FROM Doctors;

/* DAILY APPOINTMENT SCHEDULE */
SELECT a.appointment_id,
p.name AS Patient,
d.name AS Doctor,
a.appointment_date,
a.appointment_time
FROM Appointments a
JOIN Patients p ON a.patient_id=p.patient_id
JOIN Doctors d ON a.doctor_id=d.doctor_id;

/* PATIENT MEDICAL HISTORY */
SELECT p.name,v.diagnosis,v.visit_date
FROM Visits v
JOIN Appointments a ON v.appointment_id=a.appointment_id
JOIN Patients p ON a.patient_id=p.patient_id;

/* DOCTORS BY SPECIALTY */
SELECT d.name,s.specialty_name
FROM Doctors d
JOIN Specialties s ON d.specialty_id=s.specialty_id;

/* OUTSTANDING BILLS */
SELECT * FROM Bills WHERE payment_status='UNPAID';

/* TOTAL REVENUE */
SELECT SUM(total_amount) AS TotalRevenue
FROM Bills;

/* PRESCRIPTION DETAILS */
SELECT p.name,pr.medicine_name,pr.dosage
FROM Prescriptions pr
JOIN Visits v ON pr.visit_id=v.visit_id
JOIN Appointments a ON v.appointment_id=a.appointment_id
JOIN Patients p ON a.patient_id=p.patient_id;

/* AUDIT LOG CHECK */
SELECT * FROM Audit_Log;
