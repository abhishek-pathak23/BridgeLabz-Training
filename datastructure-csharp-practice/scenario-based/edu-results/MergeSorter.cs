using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections_csharp_practice.scenario_based.edu_results
{
        public class MergeSorter
        {
            public List<StudentRecord> Sort(List<StudentRecord> data)
            {
                if (data.Count <= 1)
                    return data;

                int mid = data.Count / 2;

                var left = Sort(data.GetRange(0, mid));
                var right = Sort(data.GetRange(mid, data.Count - mid));

                return Merge(left, right);
            }

            private List<StudentRecord> Merge(
                List<StudentRecord> left,
                List<StudentRecord> right)
            {
                List<StudentRecord> result = new List<StudentRecord>();
                int i = 0, j = 0;

                while (i < left.Count && j < right.Count)
                {
                    // DESC order
                    if (left[i].Score >= right[j].Score)
                        result.Add(left[i++]);
                    else
                        result.Add(right[j++]);
                }

                while (i < left.Count) result.Add(left[i++]);
                while (j < right.Count) result.Add(right[j++]);

                return result;
            }
        }
    }



