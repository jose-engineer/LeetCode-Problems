using System;

namespace TriangularSum {
    //You are given a 0-indexed integer array nums, where nums[i] is a digit between 0 and 9 (inclusive).
    //The triangular sum of nums is the value of the only element present in nums after the following process terminates:

    //1. Let nums comprise of n elements.If n == 1, end the process.Otherwise, create a new 0-indexed integer array newNums of
    //length n - 1.
    //2. For each index i, where 0 <= i<n - 1, assign the value of newNums[i] as (nums[i] + nums[i + 1]) % 10, where % denotes
    //modulo operator.
    //3. Replace the array nums with newNums.
    //4. Repeat the entire process starting from step 1.

    //Return the triangular sum of nums.

    //Example 1:
    //Input: nums = [1,2,3,4,5]
    //Output: 8
    //Explanation:
    //The above diagram depicts the process from which we obtain the triangular sum of the array.

    //Example 2:
    //Input: nums = [5]
    //Output: 5
    //Explanation:
    //Since there is only one element in nums, the triangular sum is the value of that element itself.

    //https://leetcode.com/problems/find-triangular-sum-of-an-array/

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(TriangularSum(new int[] { 1, 2, 3, 4, 5 })); //Expected: 8
            Console.WriteLine(TriangularSum(new int[] { 5 })); //Expected: 5
            Console.WriteLine(TriangularSum(new int[] { 2, 6, 6, 5, 5, 3, 3, 8, 6, 4, 3, 3, 5, 1, 0, 1, 3, 6, 9 })); //Expected: 0
        }

        public static int TriangularSum(int[] nums) {
            if (nums.Length == 1) {
                return nums[0];
            }

            int[] newNums = new int[nums.Length];
            int sum = 0;
            int n = nums.Length - 1;

            while (n > 0) {
                for (int i = 1; i < nums.Length; i++) {
                    sum = (nums[i - 1] + nums[i]) % 10;
                    newNums[i - 1] = sum;
                }

                nums = newNums;
                n--;
            }

            return nums[0];
        }

    }
}
