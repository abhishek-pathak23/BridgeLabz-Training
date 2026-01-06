using System;
using System.Collections.Generic;

// Interface that defines medical record operations
// Any patient having medical records must implement this
interface IMedicalRecord
{
    void AddRecord(string record);   // Adds a medical note or record
    void ViewRecords();              // Displays all stored records
}

// Abstract class representing a generic patient
// Contains common patient-related data
abstract class Patient
{
    // Private fields to ensure data safety
    private int patientId;
    private string name = "";

    // Public property for patient ID
    public int PatientId
    {
        get => patientId;
        set => patientId = value;
    }

    // Public property for patient name
    public string Name
    {
        get => name;
        set => name = value;
    }

    // Forces subclasses to implement bill calculation logic
    public abstract double CalculateBill();

    // Displays basic patient information
    public void GetPatientDetails()
    {
        Console.WriteLine($"ID: {PatientId}, Name: {Name}");
    }
}

// InPatient class extends Patient and supports medical records
class InPatient : Patient, IMedicalRecord
{
    private List<string> records = new List<string>();

    // Returns fixed billing amount for in-patients
    public override double CalculateBill()
    {
        return 5000;
    }

    // Adds a medical record for the patient
    public void AddRecord(string record)
    {
        records.Add(record);
        Console.WriteLine("Medical record added");
    }

    // Displays all medical records
    public void ViewRecords()
    {
        Console.WriteLine("\n--- Medical Records ---");
        if (records.Count == 0)
        {
            Console.WriteLine("No records available");
            return;
        }

        foreach (var r in records)
        {
            Console.WriteLine("- " + r);
        }
    }
}

// Program execution starts here
class HospitalManagementSystem
{
    static void Main()
    {
        InPatient patient = new InPatient();
        bool exit = false;

        // Taking patient details
        Console.Write("Enter Patient ID: ");
        patient.PatientId = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Patient Name: ");
        patient.Name = Console.ReadLine()!;

        // Menu-driven system
        while (!exit)
        {
            Console.WriteLine("\n--- Hospital Menu ---");
            Console.WriteLine("1. View Patient Details");
            Console.WriteLine("2. Add Medical Record");
            Console.WriteLine("3. View Medical Records");
            Console.WriteLine("4. Calculate Bill");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    patient.GetPatientDetails();
                    break;

                case 2:
                    Console.Write("Enter Medical Record: ");
                    string record = Console.ReadLine()!;
                    patient.AddRecord(record);
                    break;

                case 3:
                    patient.ViewRecords();
                    break;

                case 4:
                    Console.WriteLine($"Total Bill: ₹{patient.CalculateBill()}");
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Exiting Hospital System");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
