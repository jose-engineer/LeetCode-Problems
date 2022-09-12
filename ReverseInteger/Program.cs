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

        public static int Reverse(int x) { //321
            int end = 0, result = 0;

            while (x != 0) {
                if (Math.Abs(result) > Int32.MaxValue / 10) //compare the result before the last number is added with the MaxValue without last number
                    return 0;

                end = x % 10; //1
                x = x / 10; //32 - so we get 32 in x for the next iteration
                //result * 10 to add 0 at the end, to move the number to the right (on 120 we move to the right 12, so we can add 3 at the end
                result = (result * 10) + end; //0*10 + 1 = 1, next iteration will be: 1*10 + 2 = 10 + 2 = 12, next: 12*10 + 3 = 120 + 3 = 123
            }

            return result;
        }

        static int Reverse2(int x)
        {
            int result = 0;

            while (x != 0) {
                int end = x % 10;
                int newResult = result * 10 + end;
                //if 'newResult' in the line above return a out of range number(normally a number that not make sense) this condition will fail
                if ((newResult - end) / 10 != result) { //(result * 10 + end) should be equal to ((newResult - end) / 10) if we are not out of range
                    return 0;
                }

                result = newResult;
                x = x / 10;
            }

            return result;
        }

        public static int Reverse3(int x) {
            string input = x.ToString();
            StringBuilder sb = new StringBuilder();            

            for (int i = input.Length - 1; i >= 0; i--) {
                if (x < 0 && i == input.Length - 1)
                    sb.Append('-').ToString();

                if (char.IsDigit(input[i]))
                    sb.Append(input[i].ToString());
            }

            long total = Int64.Parse(sb.ToString());

            return Math.Abs(total) < Int32.MaxValue ? (int)total : 0;
        }

        public static int Reverse4(int x) {
            var sb = new StringBuilder();
            string input = x.ToString();
            Queue<char> queue = new Queue<char>();

            for (int i = input.Length - 1; i >= 0; i--) {
                queue.Enqueue(input[i]);
            }

            while (queue.Count > 0) {
                if (x < 0 && queue.Count == input.Length)
                    sb.Append('-').ToString();

                if (char.IsDigit(queue.Peek())) {
                    sb.Append(queue.Dequeue().ToString());
                } else {
                    queue.Dequeue().ToString(); //if not digit is the last character '-' so deque to make the ahile condition valid
                }
            }

            var total = Int64.Parse(sb.ToString());

            return Math.Abs(total) < Int32.MaxValue ? (int)total : 0;
        }
    }
}
