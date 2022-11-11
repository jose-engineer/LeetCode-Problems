using System;
using System.Collections.Generic;

namespace FibonacciNumber {
//    The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the
//    two preceding ones, starting from 0 and 1. That is,

//F(0) = 0, F(1) = 1
//F(n) = F(n - 1) + F(n - 2), for n > 1.

//Given n, calculate F(n). 

//Example 1:
//Input: n = 2
//Output: 1
//Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.

//Example 2:
//Input: n = 3
//Output: 2
//Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.

//Example 3:
//Input: n = 4
//Output: 3
//Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.

//Constraints:
//0 <= n <= 30

    internal class Program {

        public static Dictionary<int, int> hMap = new Dictionary<int, int>() { { 0, 0 }, { 1, 1 } }; //memory, cache

        static void Main(string[] args) {
            Console.WriteLine(Fib(2)); //Expected: 1
            Console.WriteLine(Fib(3)); //Expected: 2
        }

        public static int Fib(int n) {
            if (hMap.ContainsKey(n))
                return hMap[n];

            int result = Fib(n - 1) + Fib(n - 2);
            hMap[n] = result;

            return result;
        }

        public static int Fib2(int n) {
            if (n <= 1)
                return n;

            return Fib2(n - 1) + Fib2(n - 2);
        }

        public static int Fib3(int n) {
            List<int> arr = new List<int>(new int[n]); //int[] arr = new int[n];

            if (n == 0)
                return 0;

            if (n == 1 || n == 2)
                return 1;

            arr[0] = 1;
            arr[1] = 1;

            for (int i = 2; i < n; i++) {
                arr[i] = arr[i - 2] + arr[i - 1];
            }

            return arr[n - 1];
        }        

    }
}
