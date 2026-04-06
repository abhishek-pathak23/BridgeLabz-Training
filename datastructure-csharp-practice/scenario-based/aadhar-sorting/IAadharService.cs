using System;

public interface IAadharService
{
    // Display all Aadhar records
    void DisplayAll();

    // Sort Aadhar records
    void SortAadhar();

    // Search for a specific Aadhar record by number
    void SearchAadhar(long key);
}
