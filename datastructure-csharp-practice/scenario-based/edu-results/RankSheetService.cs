using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.edu_results
{
        public class RankSheetService
        {
            private readonly MergeSorter sorter = new MergeSorter();

            public List<StudentRecord> GenerateRankSheet(
                Dictionary<string, List<StudentRecord>> districts)
            {
                List<StudentRecord> allStudents = new List<StudentRecord>();

                foreach (var district in districts.Values)
                    allStudents.AddRange(district);

                return sorter.Sort(allStudents);
            }
        }
    }



