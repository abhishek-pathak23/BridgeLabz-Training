using System;
using System.Collections.Generic;

namespace HospitalManagement
{
    // Represents a patient in the hospital
    class Patient
    {
        public string Name { get; set; }

        public Patient(string name)
        {
            Name = name;
        }
    }

    // Represents a doctor in the hospital
    class Doctor
    {
        public string Name { get; set; }

        public Doctor(string name)
        {
            Name = name;
        }

        // Simulate a consultation between doctor and patient
        public void Consult(Patient patient)
        {
            Console.WriteLine($"Doctor {Name} is consulting patient {patient.Name}");
        }
    }

    // Represents the hospital itself
    class Hospital
    {
        public string Name { get; set; }

        // List of doctors working in the hospital
        public List<Doctor> Doctors { get; set; }

        // List of patients registered in the hospital
        public List<Patient> Patients { get; set; }

        public Hospital(string name)
        {
            Name = name;
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
        }

        // Add a doctor to the hospital
        public void AddDoctor(Doctor doctor) => Doctors.Add(doctor);

        // Add a patient to the hospital
        public void AddPatient(Patient patient) => Patients.Add(patient);
    }

    // Main program to simulate hospital management
    class HospDoctorPatient
    {
        static void Main()
        {
            // Input hospital name
            Console.WriteLine("Enter the Hospital Name:");
            string hospitalName = Console.ReadLine();
            Hospital hospital = new Hospital(hospitalName);

            // Input doctors
            Console.WriteLine("Enter total number of doctors:");
            int totalDoctors = int.Parse(Console.ReadLine());
            for (int i = 0; i < totalDoctors; i++)
            {
                Console.WriteLine($"Enter name of Doctor {i + 1}:");
                string doctorName = Console.ReadLine();
                hospital.AddDoctor(new Doctor(doctorName));
            }

            // Input patients
            Console.WriteLine("Enter total number of patients:");
            int totalPatients = int.Parse(Console.ReadLine());
            for (int i = 0; i < totalPatients; i++)
            {
                Console.WriteLine($"Enter name of Patient {i + 1}:");
                string patientName = Console.ReadLine();
                hospital.AddPatient(new Patient(patientName));
            }

            // Simulate consultations
            Console.WriteLine("\nScheduling Consultations:");
            foreach (var doctor in hospital.Doctors)
            {
                foreach (var patient in hospital.Patients)
                {
                    Console.WriteLine($"Should Doctor {doctor.Name} consult Patient {patient.Name}? (yes/no)");
                    string response = Console.ReadLine().ToLower();
                    if (response == "yes")
                        doctor.Consult(patient); // Perform consultation
                }
            }

            Console.WriteLine("\nAll consultations completed. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
