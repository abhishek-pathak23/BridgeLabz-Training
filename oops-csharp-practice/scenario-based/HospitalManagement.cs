using System;
//interfaces
interface IPatient
{
    void DisplayInfo();
}

interface IPayable
{
    double CalculateBill();
}
//doctor class
class Doctor
{
    public int DoctorId;
    public string Name;
    public string Specialization;
// Array to hold patients objects
    public Patient[] Patients;
    public int PatientCount;
// Constructor for Doctor
    public Doctor(int id, string name, string spec)
    {
        DoctorId = id;
        Name = name;
        Specialization = spec;
        Patients = new Patient[100]; 
        PatientCount = 0;
    }
//method to add patient
    public void AddPatient(Patient p)
    {
        if (PatientCount < Patients.Length)
        {
            Patients[PatientCount++] = p;
        }
    }
//method to display doctor info
    public void DisplayInfo()
    {
        Console.WriteLine($"Doctor | ID:{DoctorId} Name:{Name} Specialization:{Specialization}");
    }
//method to display patients under the doctor
    public void DisplayPatients()
    {
        Console.WriteLine($"Patients under Dr. {Name}:");
        if (PatientCount == 0)
        {
            Console.WriteLine("No patients assigned.");
            return;
        }
        for (int i = 0; i < PatientCount; i++)
        {
            Patients[i].DisplayInfo();
        }
    }
}

//abstract patient class inheriting IPatient
abstract class Patient : IPatient
{
    public int PatientId;
    public string Name;
    public int Age ;
    public Doctor AssignedDoctor ;
// Constructor for Patient
    protected Patient(int id, string name, int age, Doctor doctor)
    {
        PatientId = id;
        Name = name;
        Age = age;
        AssignedDoctor = doctor;
    }
// Abstract method to display patient info
    public abstract void DisplayInfo();
}

// InPatient class inheriting Patient and IPayable
class InPatient : Patient, IPayable
{
    public int DaysAdmitted;
    public double ChargePerDay = 2000;
// Constructor for InPatient
    public InPatient(int id, string name, int age, int days, Doctor doc)
        : base(id, name, age, doc)
    {
        DaysAdmitted = days;
    }
// Method to calculate bill
    public double CalculateBill()
    {
        return DaysAdmitted * ChargePerDay;
    }
// Method to display patient info
    public override void DisplayInfo()
    {
        Console.WriteLine($"InPatient | ID:{PatientId} Name:{Name} Age:{Age} Days:{DaysAdmitted} Doctor:{AssignedDoctor.Name}");
    }
}

// OutPatient class inheriting Patient and IPayable
class OutPatient : Patient, IPayable
{
    public double ConsultationFee = 500;
// Constructor for OutPatient
    public OutPatient(int id, string name, int age, Doctor doc)
        : base(id, name, age, doc)
    {
    }
// Method to calculate bill
    public double CalculateBill()
    {
        return ConsultationFee;
    }
// Method to display patient info
    public override void DisplayInfo()
    {
        Console.WriteLine($"OutPatient | ID:{PatientId} Name:{Name} Age:{Age} Doctor:{AssignedDoctor.Name}");
    }
}

// Bill class to generate bill
class Bill
{
    // Static method to generate bill
    public static void Generate(IPayable p)
    {
        Console.WriteLine($"Total Bill Amount: {p.CalculateBill()}");
    }
}
// Utility class for input handling
static class Utility
{
    // Method to read integer input
    public static int ReadInt(string msg)
    {
        Console.Write(msg);
        return Convert.ToInt32(Console.ReadLine());
    }
// Method to read string input
    public static string ReadString(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine() ?? "";
    }
}
// Hospital class with Main method
class HospitalManagement
{
    // Arrays to hold doctors and patients
    static Doctor[] doctors = new Doctor[100];
    static int doctorCount = 0;
// Array to hold patients
    static Patient[] patients = new Patient[100];
    static int patientCount = 0;
// Method to select a doctor
    static Doctor SelectDoctor()
    {
        Console.WriteLine("Available Doctors:");
        if (doctorCount == 0)
        {
            Console.WriteLine("No doctors available.");
            return null;
        }
        for (int i = 0; i < doctorCount; i++)
        {
            Console.WriteLine($"{doctors[i].DoctorId} - {doctors[i].Name}");
        }

        int id = Utility.ReadInt("Select Doctor ID: ");
        for (int i = 0; i < doctorCount; i++)
        {
            if (doctors[i].DoctorId == id)
                return doctors[i];
        }
        Console.WriteLine("Doctor not found.");
        return null;
    }
// Method to select a patient
    static Patient SelectPatient()
    {
        if (patientCount == 0)
        {
            Console.WriteLine("No patients available.");
            return null;
        }

        int pid = Utility.ReadInt("Enter Patient ID: ");
        for (int i = 0; i < patientCount; i++)
        {
            if (patients[i].PatientId == pid)
                return patients[i];
        }

        Console.WriteLine("Patient not found.");
        return null;
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Hospital Management System ---");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Add InPatient");
            Console.WriteLine("3. Add OutPatient");
            Console.WriteLine("4. Doctor-wise Patient List");
            Console.WriteLine("5. Generate Patient Bill");
            Console.WriteLine("6. Exit");
            //take the user choice as input from user
            int choice = Utility.ReadInt("Enter choice: ");

            switch (choice)
            {
                case 1:
                    Doctor d = new Doctor(
                        Utility.ReadInt("Doctor ID: "),
                        Utility.ReadString("Name: "),
                        Utility.ReadString("Specialization: ")
                    );
                    if (doctorCount < doctors.Length)
                        doctors[doctorCount++] = d;
                    Console.WriteLine("Doctor added successfully.");
                    break;

                case 2:
                    Doctor doc1 = SelectDoctor();
                    if (doc1 == null) break;

                    InPatient ip = new InPatient(
                        Utility.ReadInt("Patient ID: "),
                        Utility.ReadString("Name: "),
                        Utility.ReadInt("Age: "),
                        Utility.ReadInt("Days Admitted: "),
                        doc1
                    );
                    if (patientCount < patients.Length)
                        patients[patientCount++] = ip;
                    doc1.AddPatient(ip);
                    Console.WriteLine("InPatient added.");
                    break;

                case 3:
                    Doctor doc2 = SelectDoctor();
                    if (doc2 == null) break;

                    OutPatient op = new OutPatient(
                        Utility.ReadInt("Patient ID: "),
                        Utility.ReadString("Name: "),
                        Utility.ReadInt("Age: "),
                        doc2
                    );
                    if (patientCount < patients.Length)
                        patients[patientCount++] = op;
                    doc2.AddPatient(op);
                    Console.WriteLine("OutPatient added.");
                    break;

                case 4:
                    Doctor doc = SelectDoctor();
                    if (doc != null)
                        doc.DisplayPatients();
                    break;

                case 5:
                    Patient p = SelectPatient();
                    if (p is IPayable pay)
                        Bill.Generate(pay);
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}