using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.fitness_tracker
{
    // Interface to enforce tracking and calorie calculation for workouts
    public interface ITrackable
    {
        void TrackWorkout();       // method to track workout details
        int CalculateCalories();   // method to calculate calories burned
    }
}
