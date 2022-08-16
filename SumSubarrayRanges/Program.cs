using System;
using System.Collections.Generic;

namespace SumSubarrayRanges {
    class Program {
        //You are given an integer array nums. The range of a subarray of nums is the difference between the largest and smallest
        //element in the subarray.
        //Return the sum of all subarray ranges of nums.
        //A subarray is a contiguous non-empty sequence of elements within an array.

        //        Example 1:
        //Input: nums = [1,2,3]
        //        Output: 4
        //Explanation: The 6 subarrays of nums are the following:
        //[1], range = largest - smallest = 1 - 1 = 0 
        //[2], range = 2 - 2 = 0
        //[3], range = 3 - 3 = 0
        //[1,2], range = 2 - 1 = 1
        //[2,3], range = 3 - 2 = 1
        //[1,2,3], range = 3 - 1 = 2
        //So the sum of all ranges is 0 + 0 + 0 + 1 + 1 + 2 = 4.

        //Example 2:
        //Input: nums = [1,3,3]
        //        Output: 4
        //Explanation: The 6 subarrays of nums are the following:
        //[1], range = largest - smallest = 1 - 1 = 0
        //[3], range = 3 - 3 = 0
        //[3], range = 3 - 3 = 0
        //[1,3], range = 3 - 1 = 2
        //[3,3], range = 3 - 3 = 0
        //[1,3,3], range = 3 - 1 = 2
        //So the sum of all ranges is 0 + 0 + 0 + 2 + 0 + 2 = 4.

        //Example 3:
        //Input: nums = [4,-2,-3,4,1]
        //        Output: 59
        //Explanation: The sum of all subarray ranges of nums is 59.

        //Constraints:
        //1 <= nums.length <= 1000
        //-109 <= nums[i] <= 109
        //https://leetcode.com/problems/sum-of-subarray-ranges/
        static void Main(string[] args) {
            Console.WriteLine(SubArrayRanges2(new int[] { 1, 2, 3 })); //Expected: 4
            Console.WriteLine(SubArrayRanges(new int[] { 1, 3, 3 })); //Expected: 4
            Console.WriteLine(SubArrayRanges(new int[] { 4, -2, -3, 4, 1 })); //Expected: 59
            Console.WriteLine(SubArrayRanges(new int[] { 3, 1, 2, 4 })); //Expected: 13
        }

        public static long SubArrayRanges(int[] nums) { // [1, 3, 3]

            long rangeSum = 0;

            for (int i = 0; i < nums.Length; i++) {
                int min = nums[i];
                int max = nums[i];
                for (int j = i; j < nums.Length; j++) { //With i=0 and j=0, j=1, j=2         With i=1 and j=1, j=2   With i=2 and j=2                    
                    max = Math.Max(max, nums[j]);       //Max(1, 1), Max(1, 3), Max(3, 3) => Max(3, 3), Max(3, 3) => Max(3, 3)
                    min = Math.Min(min, nums[j]);       //Min(1, 1), Min(1, 3), Min(1, 3) => Min(3, 3), Min(3, 3) => Min(3, 3)
                    rangeSum += max - min;              //(1-1) + (3-1) + (3-1) = 4       => (3-3) + (3-3) = 0    => (3-3) = 0  
                }
            }

            return rangeSum;                            // 4 + 0 + 0 = 4
        }

        public static long SubArrayRanges2(int[] nums) {
            int mid, left; //boundaries
            long res = 0;

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i <= nums.Length; i++) { // i => right boundary

                while (stack.Count != 0 && nums[stack.Peek()] > (i == nums.Length ? int.MinValue : nums[i])) {
                    mid = stack.Pop();
                    left = stack.Count == 0 ? -1 : stack.Peek();
                    res -= (long)nums[mid] * (i - mid) * (mid - left);

                }
                stack.Push(i);
            }

            stack.Clear();
            for (int i = 0; i <= nums.Length; i++) {
                while (stack.Count != 0 && nums[stack.Peek()] < (i == nums.Length ? int.MaxValue : nums[i])) {
                    mid = stack.Pop();
                    left = stack.Count == 0 ? -1 : stack.Peek();
                    res += (long)nums[mid] * (i - mid) * (mid - left);

                }
                stack.Push(i);
            }
            return res;
        }

        public static long SubArrayRangesTest(int[] nums) { // [1, 2, 3]

            long rangeSum = 0;

            for (int i = 0; i < nums.Length; i++) {
                int min = nums[i];
                int max = nums[i];
                for (int j = i; j < nums.Length; j++) { //With i=0 and j=0, j=1, j=2         With i=1 and j=1, j=2   With i=2 and j=2                    
                    max = Math.Max(max, nums[j]);       //Max(1, 1), Max(1, 2), Max(2, 3) => Max(2, 2), Max(2, 3) => Max(3, 3)
                    min = Math.Min(min, nums[j]);       //Min(1, 1), Min(1, 2), Min(1, 3) => Min(2, 2), Min(2, 3) => Min(3, 3)
                    rangeSum += max - min;              //(1-1) + (2-1) + (3-1) = 3       => (2-2) + (3-2) = 1    => (3-3) = 0  
                }
            }

            return rangeSum;                            // 3 + 1 + 0 = 4
        }

        public static long SubArrayRangesTest2(int[] nums) { // [3,1,2,4]

            long rangeSum = 0;

            for (int i = 0; i < nums.Length; i++) {
                int min = nums[i];
                int max = nums[i];
                for (int j = i; j < nums.Length; j++) { //With i=0 and j=0, j=1, j=2, j=3               With i=1 and j=1, j=2, j=3         With i=2 and j=2, j=3    With i=3 and j=3                    
                    max = Math.Max(max, nums[j]);       //Max(3, 3), Max(3, 1), Max(3, 2), Max(3, 4) => Max(1, 1), Max(1, 2), Max(2, 4) => Max(2, 2), Max(2, 4)  => Max(4, 4)
                    min = Math.Min(min, nums[j]);       //Min(3, 3), Min(3, 1), Min(1, 2), Min(1, 4) => Min(1, 1), Min(1, 2), Min(1, 4) => Min(2, 2), Min(2, 4)  => Min(4, 4)
                    rangeSum += max - min;              //(3-3) + (3-1) + (3-1) + (4-1) = 7          => (1-1) + (2-1) + (4-1) = 4       => (2-2), (4-2) = 2      => (4-4) = 0
                }
            }

            return rangeSum;                            // 7 + 4 + 2 = 13
        }
    }
}
