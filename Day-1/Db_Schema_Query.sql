use healthappdb;
CREATE TABLE Patients
(
    PatientID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    Phone VARCHAR(15)
);

select * from Patients

CREATE TABLE Doctors
(
    DoctorID INT PRIMARY KEY IDENTITY(1,1),
    DoctorName VARCHAR(100) NOT NULL,
    Specialization VARCHAR(100),
    Phone VARCHAR(15),
    ExperienceYears INT
);

select * from Doctors

CREATE TABLE Appointments
(
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),

    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,

    AppointmentDate DATETIME NOT NULL,
    Status VARCHAR(20),

    FOREIGN KEY (PatientID)
    REFERENCES Patients(PatientID),

    FOREIGN KEY (DoctorID)
    REFERENCES Doctors(DoctorID)
);

select * from Appointments
