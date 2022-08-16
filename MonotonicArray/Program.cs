using System;

namespace MonotonicArray {
//An array is monotonic if it is either monotone increasing or monotone decreasing.
//An array nums is monotone increasing if for all i <= j, nums[i] <= nums[j].
//An array nums is monotone decreasing if for all i <= j, nums[i] >= nums[j].
//Given an integer array nums, return true if the given array is monotonic, or false otherwise.

//Example 1:
//Input: nums = [1, 2, 2, 3]
//Output: true

//Example 2:
//Input: nums = [6, 5, 4, 4]
//Output: true

//Example 3:
//Input: nums = [1, 3, 2]
//Output: false

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(IsMonotonic(new int[] { 1,2,3,3 })); //Expected: true
            Console.WriteLine(IsMonotonic(new int[] { 6, 5, 4, 4 })); //Expected: true
            Console.WriteLine(IsMonotonic(new int[] { 1, 3, 2 })); //Expected: false            
        }

        public static bool IsMonotonic(int[] nums) {

            bool increase = true, decrease = true;

            for (int i = 1; i < nums.Length; i++) {
                if (nums[i - 1] > nums[i]) {
                    increase = false;
                }

                if (nums[i] > nums[i - 1]) {
                    decrease = false;
                }

            }

            return decrease || increase;
        }

        public static bool IsMonotonic2(int[] nums) {

            bool increase = true, decrease = true;

            for (int i = 1; i < nums.Length; i++) {
                if (!(nums[i] >= nums[i - 1])) {
                    increase = false;
                }

                if (!(nums[i - 1] >= nums[i])) {
                    decrease = false;
                }
            }

            return decrease || increase;
        }
    }
}
