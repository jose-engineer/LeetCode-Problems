using System;

namespace SumOfSquareNumbers {
    //Given a non-negative integer c, decide whether there're two integers a and b such that a2 + b2 = c.
    //
    //Example 1:
    //Input: c = 5
    //Output: true
    //Explanation: 1 * 1 + 2 * 2 = 5
    //
    //Example 2:
    //Input: c = 3
    //Output: false
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(JudgeSquareSum(5)); //Expected: true
            Console.WriteLine(JudgeSquareSum(3)); //Expected: false
        }

        public static bool JudgeSquareSum(int c) {
            if (c < 0) {
                return false;
            }

            int left = 0, right = (int)Math.Sqrt(c);

            while (left <= right) {
                int cur = left * left + right * right;
                if (cur < c) {
                    left++;
                } else if (cur > c) {
                    right--;
                } else {
                    return true;
                }
            }

            return false;
        }
    }
}
