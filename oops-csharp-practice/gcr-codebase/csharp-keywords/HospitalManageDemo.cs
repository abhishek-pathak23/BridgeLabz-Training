using System;

class Patient
{
    // Static variable shared by all Patient objects
    // Stores the hospital name
    public static string HospitalName;

    // Private static counter to track total patients registered
    private static int count = 0;

    // Public instance variable to store patient name
    public string Name;

    // Public instance variable to store patient age
    public int Age;

    // Public instance variable to store patient's ailment
    public string Ailment;

    // Readonly variable: patient ID cannot be modified after initialization
    public readonly int PatientID;

    // Constructor to initialize patient details
    public Patient(string name, int age, string ailment, int id)
    {
        // Assign constructor parameters to class fields
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        this.PatientID = id;

        // Increment patient count whenever a new object is created
        count++;
    }

    // Static method to display total number of patients
    // Can be called using the class name
    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + count);
    }

    // Instance method to display basic patient information
    public void ShowPatient()
    {
        Console.WriteLine(Name + " - " + Ailment);
    }
}

class HospitalManageDemo
{
    // Main method: program execution starts here
    static void Main()
    {
        // Set hospital name (shared among all patients)
        Patient.HospitalName = "City Hospital";

        // Read patient name from user
        Console.Write("Name: ");
        string n = Console.ReadLine();

        // Read patient age and convert input to integer
        Console.Write("Age: ");
        int a = int.Parse(Console.ReadLine());

        // Read patient's ailment
        Console.Write("Ailment: ");
        string al = Console.ReadLine();

        // Read patient ID
        Console.Write("Patient ID: ");
        int id = int.Parse(Console.ReadLine());

        // Create Patient object and store it in object reference (upcasting)
        object p = new Patient(n, a, al, id);

        // Type-checking using 'is' operator for safe casting
        if (p is Patient)
        {
            // Downcasting to access Patient instance method
            ((Patient)p).ShowPatient();
        }

        // Display total number of patients registered
        Patient.GetTotalPatients();
    }
}
