using System;

public class LabController
{
    [PublicAPI("Get list of lab tests")]
    public void GetLabTests() { }

    [RequiresAuth("Admin")]
    public void AddLabTest() { }

    public void DeleteLabTest() { } // Missing annotation
}

public class PatientController
{
    [PublicAPI("Get patient info")]
    public void GetPatientInfo() { }

    [RequiresAuth("Admin")]
    public void UpdatePatientInfo() { }

    public void DeletePatient() { } // Missing annotation
}
