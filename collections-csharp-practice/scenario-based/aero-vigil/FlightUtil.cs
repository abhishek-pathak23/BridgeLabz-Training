using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class FlightUtil
{
    private Dictionary<string, int> passengerCapacity = new Dictionary<string, int>()
    {
        {"SpiceJet", 396},
        {"Vistara", 615},
        {"IndiGo", 230},
        {"Air Arabia", 130}
    };

    private Dictionary<string, double> fuelCapacity = new Dictionary<string, double>()
    {
        {"SpiceJet", 200000},
        {"Vistara", 300000},
        {"IndiGo", 250000},
        {"Air Arabia", 150000}
    };

    public bool ValidateFlightNumber(string flightNumber)
    {
        if (!Regex.IsMatch(flightNumber, @"^FL-[1-9][0-9]{3}$"))
            throw new InvalidFlightException("The flight number " + flightNumber + " is invalid");

        return true;
    }

    public bool ValidateFlightName(string flightName)
    {
        if (!passengerCapacity.ContainsKey(flightName))
            throw new InvalidFlightException("The flight name " + flightName + " is invalid");

        return true;
    }

    public bool ValidatePassengerCount(int passengerCount, string flightName)
    {
        int maxCapacity = passengerCapacity[flightName];

        if (passengerCount <= 0 || passengerCount > maxCapacity)
            throw new InvalidFlightException("The passenger count " + passengerCount + " is invalid for " + flightName);

        return true;
    }

    public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuel = fuelCapacity[flightName];

        if (currentFuelLevel < 0 || currentFuelLevel > maxFuel)
            throw new InvalidFlightException("Invalid fuel level for " + flightName);

        return maxFuel - currentFuelLevel;
    }
}
