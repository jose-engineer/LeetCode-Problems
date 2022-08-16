using System;
using System.Collections.Generic;
using System.Linq;

namespace DecompressRunLength {
    //We are given a list nums of integers representing a list compressed with run-length encoding.
    //Consider each adjacent pair of elements[freq, val] = [nums[2 * i], nums[2 * i + 1]](with i >= 0). For each such pair, there are freq elements
    //with value val concatenated in a sublist.Concatenate all the sublists from left to right to generate the decompressed list.
    //Return the decompressed list.

//Example 1:
//Input: nums = [1,2,3,4]
//Output: [2,4,4,4]
//Explanation: The first pair[1, 2] means we have freq = 1 and val = 2 so we generate the array[2].
//The second pair[3, 4] means we have freq = 3 and val = 4 so we generate[4, 4, 4].
//At the end the concatenation[2] + [4,4,4] is [2,4,4,4].

//Example 2:
//Input: nums = [1,1,2,3]
//Output: [1,3,3]

    class Program {
        static void Main(string[] args) {
            Array.ForEach(DecompressRLElist(new int[] { 1, 2, 3, 4 } ), Console.WriteLine); //Expected: [2,4,4,4]
            Console.WriteLine();
            Array.ForEach(DecompressRLElist(new int[] { 1, 1, 2, 3 } ), Console.WriteLine); //Expected: [1,3,3]
        }

        public static int[] DecompressRLElist(int[] nums) {

            List<int> result = new List<int>();

            for (int i = 1; i < nums.Length; i += 2) {
                int freq = nums[i - 1];
                int val = nums[i];

                while (freq > 0) {  //result.AddRange(Enumerable.Repeat(val, freq).ToList());
                    result.Add(val);
                    freq--;
                }                
            }

            return result.ToArray();
        }

        public int[] DecompressRLElist2(int[] nums) {

            List<int> result = new List<int>();

            for (int i = 0; i < nums.Length - 1; i += 2) {
                int freq = nums[i];
                int val = nums[i + 1];
                
                result.AddRange(Enumerable.Repeat(val, freq).ToList());
            }

            return result.ToArray();
        }
    }
}
