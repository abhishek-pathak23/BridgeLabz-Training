USE healthappdb;
GO

CREATE TABLE Patients
(
    PatientID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10)
        CHECK (Gender IN ('Male', 'Female', 'Other')),
    Phone VARCHAR(15) UNIQUE
);

SELECT * FROM Patients;


CREATE TABLE Doctors
(
    DoctorID INT PRIMARY KEY IDENTITY(1,1),
    DoctorName VARCHAR(100) NOT NULL,
    Specialization VARCHAR(100),
    Phone VARCHAR(15) UNIQUE,
    ExperienceYears INT
        CHECK (ExperienceYears >= 0)
);

SELECT * FROM Doctors;


CREATE TABLE Appointments
(
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),

    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,

    AppointmentDate DATETIME NOT NULL,

    Status VARCHAR(20)
        DEFAULT 'Scheduled'
        CHECK (Status IN ('Scheduled', 'Completed', 'Cancelled')),

    FOREIGN KEY (PatientID)
        REFERENCES Patients(PatientID),

    FOREIGN KEY (DoctorID)
        REFERENCES Doctors(DoctorID)
);

SELECT * FROM Appointments;



