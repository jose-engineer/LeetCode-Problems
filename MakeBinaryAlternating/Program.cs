using System;
using System.Linq;

namespace MakeBinaryAlternating {
    //Given a binary string s, return the minimum number of character swaps to make it alternating, or -1 if it is impossible. The string is called
    //alternating if no two adjacent characters are equal.For example, the strings "010" and "1010" are alternating, while the string "0100" is not.
    //Any two characters may be swapped, even if they are not adjacent.

    //Example 1:
    //Input: s = "111000"
    //Output: 1
    //Explanation: Swap positions 1 and 4: "111000" -> "101010"
    //The string is now alternating.

    //Example 2:
    //Input: s = "010"
    //Output: 0
    //Explanation: The string is already alternating, no swaps are needed.

    //Example 3:
    //Input: s = "1110"
    //Output: -1

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(MinSwaps("111000")); //Expected: 1
            Console.WriteLine(MinSwaps("010")); //Expected: 0
            Console.WriteLine(MinSwaps("1110")); //Expected: -1
            Console.WriteLine();
            Console.WriteLine(MinSwaps("111000")); //Expected: 1
            Console.WriteLine(MinSwaps("100")); //Expected: 1
            Console.WriteLine(MinSwaps("1001")); //Expected: 1
            Console.WriteLine(MinSwaps("0100")); //Expected: -1
            Console.WriteLine(MinSwaps("01010")); //Expected: 0
            Console.WriteLine(MinSwaps("0010111")); //Expected: 1
            Console.WriteLine(MinSwaps("110000110")); //Expected: 2
            Console.WriteLine(MinSwaps("0")); //Expected: 0
            Console.WriteLine(MinSwaps("11100000001000010101001010100001010101010010000011101010000101111011000001111100010001110101111011000011000" +
                "0100110010101111010001111110000000010001111101111011111101111011101010011110101111111110110110010101011000001111011010010111100010" +
                "0000001100000")); //Expected: 60
        }

        //10101
        //01010
        //101010 - 111000
        //010101
        public static int MinSwaps(String s) {            
            int ones = 0, zeros = 0;            

            foreach (var item in s) {   //int ones = s.Where(x => x == '1').Count();                
                if (item == '1') {      //int zeros = s.Where(x => x == '0').Count();
                    ++ones;
                } else {
                    ++zeros;
                }                    
            }

            if (Math.Abs(ones - zeros) > 1)
                return -1;

            if (ones > zeros) {
                return helper(s, '1');
            }                
            else if (zeros > ones) {
                return helper(s, '0');
            }
                
            return Math.Min(helper(s, '1'), helper(s, '0')); // else if(zeros == ones){
        }

        private static int helper(String s, char c) {
            int swaps = 0;
            foreach (var item in s) {
                if (item != c) {
                    ++swaps;
                }
                c = c == '1' ? '0' : '1';
            }

            return swaps / 2;
        }
        
    }
}
