using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.fitness_tracker
{
    // Represents a cardio workout
    public class CardioWorkout : Workout
    {
        public override void TrackWorkout()
        {
            Console.WriteLine("Cardio workout selected."); // simple tracking message
        }

        public override int CalculateCalories()
        {
            return durationMinutes * 8; // calculate calories based on cardio intensity
        }
    }
}
