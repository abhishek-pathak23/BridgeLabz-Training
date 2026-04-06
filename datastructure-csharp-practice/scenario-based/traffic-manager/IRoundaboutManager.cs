namespace TrafficManager;

// Interface defining the core operations for managing roundabout traffic
public interface IRoundaboutManager
{
    // Adds a vehicle to the roundabout
    void EnterVehicle(int vehicleNo);

    // Removes a vehicle from the roundabout
    void ExitVehicle();

    // Displays current state of the roundabout and waiting queue
    void ShowTrafficStatus();
}
