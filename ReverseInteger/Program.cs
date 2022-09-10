using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    //Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer
    //range [-231, 231 - 1], then return 0.
    //Assume the environment does not allow you to store 64-bit integers(signed or unsigned).

//Example 1:
//Input: x = 123
//Output: 321

//Example 2:
//Input: x = -123
//Output: -321

//Example 3:
//Input: x = 120
//Output: 21

    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(Reverse(123)); //Expected: 321
            Console.WriteLine(Reverse(-123)); //Expected: -321
            Console.WriteLine(Reverse(120)); //Expected: 21
            Console.WriteLine(Reverse(1534236469)); //Expected: 0
            Console.ReadKey();            
        }

        static int Reverse(int x)
        {
            int result = 0;

            while (x != 0) {
                int tail = x % 10;
                int newResult = result * 10 + tail;

                if ((newResult - tail) / 10 != result) {
                    return 0;
                }

                result = newResult;
                x = x / 10;
            }

            return result;
        }

        public static int Reverse(int x) {
            StringBuilder sb = new StringBuilder();
            string input = x.ToString();

            for (int i = input.Length - 1; i >= 0; i--) {
                if (x < 0 && i == input.Length - 1)
                    sb.Append('-').ToString();
                if (char.IsDigit(input[i]))
                    sb.Append(input[i].ToString());
            }

            long total = Int64.Parse(sb.ToString());

            return Math.Abs(total) < Int32.MaxValue ? (int)total : 0;
        }
    }
}
