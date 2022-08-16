using System;
using System.Collections.Generic;

namespace ValidParentheses {

//Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

//An input string is valid if:

//Open brackets must be closed by the same type of brackets.
//Open brackets must be closed in the correct order.

//Example 1:
//Input: s = "()"
//Output: true

//Example 2:
//Input: s = "()[]{}"
//Output: true

//Example 3:
//Input: s = "(]"
//Output: false
 
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(IsValid("()")); //Expected: true
            Console.WriteLine(IsValid("()[]{}")); //Expected: true
            Console.WriteLine(IsValid("(]")); //Expected: false
            Console.WriteLine(IsValid("(])")); //Expected: false
        }

        public static bool IsValid(string s) {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> hMap = new Dictionary<char, char>();

            hMap['('] = ')';
            hMap['{'] = '}';
            hMap['['] = ']';

            foreach (var item in s) {

                if (item == '(' || item == '{' || item == '[') {
                    stack.Push(item);
                } else {
                    if (stack.Count > 0) {
                        if (item == hMap[stack.Peek()]) {
                            stack.Pop();
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                }

            }

            return stack.Count == 0;
        }
    }
}
