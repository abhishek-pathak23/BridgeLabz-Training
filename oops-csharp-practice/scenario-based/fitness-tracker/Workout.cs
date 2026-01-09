using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.fitness_tracker
{
    // Abstract class for different workouts
    public abstract class Workout : ITrackable
    {
        protected int durationMinutes; // workout duration in minutes

        public int DurationMinutes
        {
            get { return durationMinutes; }
            set { durationMinutes = value; }
        }

        public abstract void TrackWorkout();  // track workout details
        public abstract int CalculateCalories();  // calculate calories burned
    }
}
