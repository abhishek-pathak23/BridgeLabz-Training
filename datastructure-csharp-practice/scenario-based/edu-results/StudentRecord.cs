using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.edu_results
{
        public class StudentRecord
        {
            public int RollNumber { get; }
            public string Name { get; }
            public int Score { get; }

            public StudentRecord(int rollNumber, string name, int score)
            {
                RollNumber = rollNumber;
                Name = name;
                Score = score;
            }

            public override string ToString()
            {
                return $"{RollNumber,-5} {Name,-10} {Score}";
            }
        }
    }



