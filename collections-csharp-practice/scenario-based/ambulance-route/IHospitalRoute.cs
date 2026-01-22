using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.ambulance_route
{
    public interface IHospitalRoute
    {
        void AddUnit(string name);
        void RemoveUnit(string name);
        void RedirectPatient();
        void DisplayRoute();
        void UpdateAvailability(string name, bool status);
    }

}
