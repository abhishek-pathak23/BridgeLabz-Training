-- Seed Data for Health Clinic Database
-- Run this once after creating all tables from Day-1 and Day-2 scripts
USE healthappdb;
GO

-- Patients
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, Phone) VALUES
('Amit', 'Sharma', '1990-03-15', 'Male', '9876543210'),
('Priya', 'Verma', '1985-07-22', 'Female', '9876543211'),
('Rahul', 'Gupta', '1992-11-08', 'Male', '9876543212'),
('Sneha', 'Patel', '1988-01-30', 'Female', '9876543213'),
('Vikram', 'Singh', '1995-05-12', 'Male', '9876543214');

-- Doctors
INSERT INTO Doctors (DoctorName, Specialization, Phone, ExperienceYears) VALUES
('Dr. Anil Kumar', 'Cardiology', '9988776601', 12),
('Dr. Meena Iyer', 'Dermatology', '9988776602', 8),
('Dr. Rajesh Nair', 'Orthopedics', '9988776603', 15),
('Dr. Sunita Rao', 'Pediatrics', '9988776604', 6);

-- Rooms
INSERT INTO rooms (room_number, floor_number) VALUES
('101', 1),
('102', 1),
('201', 2),
('202', 2);

-- Doctor-Room assignments
INSERT INTO doctor_room (doctor_id, room_id, assigned_date) VALUES
(1, 1, '2026-08-01'),
(2, 2, '2026-08-01'),
(3, 3, '2026-08-01'),
(4, 4, '2026-08-01');

-- Patient phone numbers (normalized table from Day-2)
INSERT INTO patient_phones (patient_id, phone_number, phone_type) VALUES
(1, '9876543210', 'Mobile'),
(1, '0112345678', 'Home'),
(2, '9876543211', 'Mobile'),
(3, '9876543212', 'Mobile'),
(4, '9876543213', 'Mobile'),
(5, '9876543214', 'Mobile'),
(5, '0119876543', 'Home');

-- Appointments
INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, Status) VALUES
(1, 1, '2026-08-04 09:00', 'Completed'),
(2, 2, '2026-08-04 10:00', 'Completed'),
(3, 3, '2026-08-04 11:00', 'Cancelled'),
(4, 1, '2026-08-05 09:00', 'Scheduled'),
(5, 4, '2026-08-05 10:00', 'Scheduled'),
(1, 3, '2026-08-06 14:00', 'Scheduled'),
(2, 1, '2026-08-06 09:00', 'Scheduled');

PRINT 'Seed data inserted successfully.';