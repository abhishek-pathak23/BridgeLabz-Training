using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.fitness_tracker
{
    // Represents a user profile in the fitness tracker
    public class UserProfile
    {
        private string userName; // stores the user's name

        public UserProfile(string name)
        {
            userName = name; // set user name when profile is created
        }

        // Performs a workout and displays details
        public void PerformWorkout(Workout workout)
        {
            workout.TrackWorkout(); // call workout tracking

            Console.WriteLine("User: " + userName);
            Console.WriteLine("Duration: " + workout.DurationMinutes + " minutes");
            Console.WriteLine("Calories Burned: " + workout.CalculateCalories());
        }
    }
}
