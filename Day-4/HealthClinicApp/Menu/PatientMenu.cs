using System;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- PATIENT MANAGEMENT ---");
                Console.ResetColor();
                Console.WriteLine(" 1. View All Patients");
                Console.WriteLine(" 2. Register New Patient");
                Console.WriteLine(" 3. Search Patient by ID");
                Console.WriteLine(" 4. Update Patient Details");
                Console.WriteLine(" 5. Delete Patient Record");
                Console.WriteLine(" 0. Back to Main Menu");
                Console.Write(" Select Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllPatients();
                        Pause();
                        break;
                    case "2":
                        RegisterPatient();
                        Pause();
                        break;
                    case "3":
                        SearchPatient();
                        Pause();
                        break;
                    case "4":
                        UpdatePatient();
                        Pause();
                        break;
                    case "5":
                        DeletePatient();
                        Pause();
                        break;
                    case "0":
                        return;
                    default:
                        ShowError("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewAllPatients()
        {
            var patients = _patientService.GetAllPatients();
            Console.WriteLine("\n--- LIST OF REGISTERED PATIENTS ---");
            Console.WriteLine(string.Format("{0,-6} | {1,-20} | {2,-12} | {3,-8} | {4,-15}", "ID", "Name", "DOB", "Gender", "Phone"));
            Console.WriteLine(new string('-', 70));

            foreach (var p in patients)
            {
                Console.WriteLine(string.Format("{0,-6} | {1,-20} | {2,-12:yyyy-MM-dd} | {3,-8} | {4,-15}",
                    p.PatientID, p.FullName, p.DateOfBirth, p.Gender, p.Phone));
            }
        }

        private void RegisterPatient()
        {
            Console.WriteLine("\n--- REGISTER NEW PATIENT ---");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? "";

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Date of Birth (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                ShowError("Invalid Date format!");
                return;
            }

            Console.Write("Gender (Male/Female/Other): ");
            string gender = Console.ReadLine() ?? "Male";

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine() ?? "";

            try
            {
                int newId = _patientService.AddPatient(new Patient
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dob,
                    Gender = gender,
                    Phone = phone
                });
                ShowSuccess($"Patient registered successfully! Assigned Patient ID: {newId}");
            }
            catch (Exception ex)
            {
                ShowError("Error registering patient: " + ex.Message);
            }
        }

        private void SearchPatient()
        {
            Console.Write("\nEnter Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                ShowError($"Patient with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"\n[Patient Found]");
                Console.WriteLine($"ID: {patient.PatientID}");
                Console.WriteLine($"Name: {patient.FullName}");
                Console.WriteLine($"DOB: {patient.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine($"Gender: {patient.Gender}");
                Console.WriteLine($"Phone: {patient.Phone}");
            }
        }

        private void UpdatePatient()
        {
            Console.Write("\nEnter Patient ID to Update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                ShowError("Patient not found!");
                return;
            }

            Console.WriteLine($"Updating Patient: {patient.FullName}");
            Console.Write($"First Name [{patient.FirstName}]: ");
            string fName = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(fName)) patient.FirstName = fName;

            Console.Write($"Last Name [{patient.LastName}]: ");
            string lName = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(lName)) patient.LastName = lName;

            Console.Write($"DOB [{patient.DateOfBirth:yyyy-MM-dd}]: ");
            string dobStr = Console.ReadLine() ?? "";
            if (DateTime.TryParse(dobStr, out DateTime newDob)) patient.DateOfBirth = newDob;

            Console.Write($"Gender [{patient.Gender}]: ");
            string gen = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(gen)) patient.Gender = gen;

            Console.Write($"Phone [{patient.Phone}]: ");
            string ph = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(ph)) patient.Phone = ph;

            bool updated = _patientService.UpdatePatient(patient);
            if (updated)
                ShowSuccess("Patient record updated successfully!");
            else
                ShowError("Failed to update patient record.");
        }

        private void DeletePatient()
        {
            Console.Write("\nEnter Patient ID to Delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            Console.Write($"Are you sure you want to delete patient #{id}? (y/N): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                bool deleted = _patientService.DeletePatient(id);
                if (deleted)
                    ShowSuccess("Patient deleted successfully!");
                else
                    ShowError("Could not delete patient.");
            }
        }

        private static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] " + msg);
            Console.ResetColor();
        }

        private static void ShowSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[SUCCESS] " + msg);
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
