using System;

namespace MinMovesToEqualArray2 {
//Given an integer array nums of size n, return the minimum number of moves required to make all array elements equal.
//In one move, you can increment or decrement an element of the array by 1.

//Test cases are designed so that the answer will fit in a 32-bit integer.

//Example 1:
//Input: nums = [1, 2, 3]
//Output: 2
//Explanation:
//Only two moves are needed (remember each move increments or decrements one element):
//[1,2,3]  =>  [2,2,3]  =>  [2,2,2]

//Example 2:
//Input: nums = [1,10,2,9]
//    Output: 16
 
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(MinMoves2(new int[] { 1, 2, 3 })); //Expected: 2
            Console.WriteLine(MinMoves2(new int[] { 1, 10, 2, 9 })); //Expected: 16
            Console.WriteLine(MinMoves2(new int[] { 1, 2, 5, 8, 0 })); //Expected: 12
            Console.WriteLine(MinMoves2(new int[] { 1 })); //Expected: 0
            Console.WriteLine(MinMoves2(new int[] { 1, 2 })); //Expected: 1
            Console.WriteLine(MinMoves2(new int[] { 1, 1, 1 })); //Expected: 0           
            Console.WriteLine(MinMoves2(new int[] { 1, 1, 2 })); //Expected: 1
            Console.WriteLine(MinMoves2(new int[] { 1, 0, 0, 8, 6 })); //Expected: 14            
        }

        public static int MinMoves2(int[] nums) {
            int target = 0, count = 0;

            Array.Sort(nums);

            target = nums[nums.Length / 2]; //median, number at the middle position

            foreach (var item in nums) {
                count += Math.Abs(target - item);
            }

            return count;
        }

        public static int MinMoves2_2(int[] nums) {
            int start = 0, end = nums.Length - 1, count = 0;

            Array.Sort(nums);

            while (start < end) {
                count += Math.Abs(nums[end] - nums[start]);
                start++;
                end--;
            }

            return count;
        }

        public static int MinMoves2_3(int[] nums) {
            int target = 0, count = 0, n = nums.Length;

            Array.Sort(nums);

            if (nums.Length % 2 == 0) {
                target = (nums[n / 2] + nums[n / 2 - 1]) / 2;
            } else {
                target = nums[n / 2];
            }
            foreach (var item in nums) {
                count += Math.Abs(target - item);
            }

            return count;
        }

        public static int MinMoves2_4(int[] nums) {
            int minSteps = 0, totalEle = nums.Length;

            Array.Sort(nums);

            int midElement = nums[totalEle / 2];

            for (int i = 0; i < totalEle; ++i)
                minSteps += Math.Abs(nums[i] - midElement);

            if (totalEle % 2 == 0) {
                int tempCost = 0;

                midElement = nums[(totalEle / 2) - 1];

                for (int i = 0; i < totalEle; ++i)
                    tempCost += Math.Abs(nums[i] - midElement);

                minSteps = Math.Min(minSteps, tempCost);
            }

            return minSteps;
        }
    }
}
