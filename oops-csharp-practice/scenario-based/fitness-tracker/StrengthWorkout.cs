using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.fitness_tracker
{
    // Represents a strength-based workout
    public class StrengthWorkout : Workout
    {
        public override void TrackWorkout()
        {
            Console.WriteLine("Strength workout selected."); // simple message for tracking
        }

        public override int CalculateCalories()
        {
            return durationMinutes * 5; // calculate calories based on minutes
        }
    }
}
