using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.

    //Example 1:
    //Input: nums = [2, 7, 11, 15], target = 9
    //Output: [0, 1]
    //Output: Because nums[0] +nums[1] == 9, we return [0, 1].

    //Example 2:
    //Input: nums = [3, 2, 4], target = 6
    //Output: [1, 2]
    
    //Example 3:
    //Input: nums = [3, 3], target = 6
    //Output: [0, 1]

    //Constraints:
    //            2 <= nums.length <= 104
    //            - 109 <= nums[i] <= 109
    //            - 109 <= target <= 109
    //Only one valid answer exists.

    class Program
    {
        static void Main(string[] args)
        {            
            Array.ForEach(TwoSum(new int[] { 2, 7, 11, 15 }, 9), Console.WriteLine); // Expected: [0, 1]
            Console.WriteLine();
            Array.ForEach(TwoSum(new int[] { 3, 2, 4 }, 6), Console.WriteLine); // Expected: [1, 2]
            Console.WriteLine();
            Array.ForEach(TwoSum(new int[] { 3, 3 }, 6), Console.WriteLine); // Expected: [0, 1]
            Console.ReadKey();            
        }

        public static int[] TwoSum(int[] nums, int target) {

            Dictionary<int, int> hMap = new Dictionary<int, int>(); // hMap<num, index>

            for (int i = 0; i < nums.Length; i++) {

                int current = nums[i];
                int complement = target - current;

                if (hMap.ContainsKey(complement)) {
                    return new int[] { hMap[complement], i };
                } else {
                    hMap[current] = i; // [number, index] - [2, 0] - myDictionary[myKey] = myNewValue; - Assigns input number as a key and index as a value
                }

            }

            return new int[] { };
        }

        static int[] TwoSum2(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new Exception("Not found");
        }        

        static int[] TwoSum3(int[] nums, int target) {
            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if ((nums[i] + nums[j]) == target) {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }

            throw new Exception("Not found");
        }
    }
}


