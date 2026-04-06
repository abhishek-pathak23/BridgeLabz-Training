using System;

public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        int[] result = new int[nums1.Length];

        for (int i = 0; i < nums1.Length; i++) {
            int nextGreater = -1;
            bool found = false;

            for (int j = 0; j < nums2.Length; j++) {
                if (nums2[j] == nums1[i]) {
                    found = true;
                }
                else if (found && nums2[j] > nums1[i]) {
                    nextGreater = nums2[j];
                    break;
                }
            }

            result[i] = nextGreater;
        }

        return result;
    }
}
