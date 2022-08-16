using System;
using System.Collections.Generic;

namespace WordBreak {
//Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more
//dictionary words.
//Note that the same word in the dictionary may be reused multiple times in the segmentation.

//Example 1:
//Input: s = "leetcode", wordDict = ["leet", "code"]
//Output: true
//Explanation: Return true because "leetcode" can be segmented as "leet code".

//Example 2:
//Input: s = "applepenapple", wordDict = ["apple", "pen"]
//Output: true
//Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
//Note that you are allowed to reuse a dictionary word.

//Example 3:
//Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
//Output: false

//Constraints:

    class Program {
        
        static Dictionary<string, bool> hMap = new Dictionary<string, bool>(); //cache

        static void Main(string[] args) {
            Console.WriteLine(WordBreak("leetcode", new List<string>() { "leet", "code" })); //Expected: true
            Console.WriteLine(WordBreak("applepenapple", new List<string>() { "apple", "pen" })); //Expected: true
            Console.WriteLine(WordBreak("catsandog", new List<string>() { "cats", "dog", "sand", "and", "cat" })); //Expected: false
        }

        public static bool WordBreak(string s, IList<string> wordDict) {
            HashSet<string> hSet = new HashSet<string>(wordDict);
            return helper(s, hSet);
        }

        private static bool helper(string s, HashSet<string> hSet) {
            if (string.IsNullOrEmpty(s))
                return true;

            if (hMap.ContainsKey(s))
                return hMap[s];

            for (int i = 1; i <= s.Length; i++) {
                string left = s.Substring(0, i);
                string right = s.Substring(i);

                if (hSet.Contains(left) && helper(right, hSet)) {
                    hMap[s] = true;
                    return true;
                }
            }

            hMap[s] = false;
            return false;

        }

    }
}
