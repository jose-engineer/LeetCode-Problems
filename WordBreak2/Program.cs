using System;
using System.Collections.Generic;

namespace WordBreak2 {
//Given a string s and a dictionary of strings wordDict, add spaces in s to construct a sentence where each word is a valid dictionary word.
//Return all such possible sentences in any order.

//Note that the same word in the dictionary may be reused multiple times in the segmentation.

//Example 1:
//Input: s = "catsanddog", wordDict = ["cat", "cats", "and", "sand", "dog"]
//Output: ["cats and dog","cat sand dog"]

//Example 2:
//Input: s = "pineapplepenapple", wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
//Output: ["pine apple pen apple","pineapple pen apple","pine applepen apple"]
//Explanation: Note that you are allowed to reuse a dictionary word.

//Example 3:
//Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
//Output: []

    class Program {

        Dictionary<string, List<string>> hMap = new Dictionary<string, List<string>>(); //cache

        static void Main(string[] args) {                                    
            var lst1 = (List<string>)WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            var lst2 = (List<string>)WordBreak("pineapplepenapple", new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" });
            var lst3 = (List<string>)WordBreak("catsandog", new List<string>() { "cats", "dog", "sand", "and", "cat" });

            lst1.ForEach(x => Console.WriteLine(x)); //Expected: ["cats and dog","cat sand dog"]
            Console.WriteLine();
            lst2.ForEach(x => Console.WriteLine(x)); //Expected: ["pine apple pen apple","pineapple pen apple","pine applepen apple"]
            Console.WriteLine();
            lst3.ForEach(x => Console.WriteLine(x)); //Expected: []
        }

        public static IList<string> WordBreak(string s, IList<string> wordDict) {
            return helper(s, wordDict);
        }

        private static List<string> helper(string s, IList<string> wordDict) {
            List<string> results = new List<string>();

            if (string.IsNullOrEmpty(s)) {
                results.Add("");
                return results;
            }

            foreach (var word in wordDict) {

                if (s.StartsWith(word)) {
                    string sub = s.Substring(word.Length);
                    List<string> subStrings = helper(sub, wordDict);

                    foreach (var item in subStrings) {
                        string optionalSpace = string.IsNullOrEmpty(item) ? "" : " ";
                        results.Add(word + optionalSpace + item);
                    }
                }

            }

            return results;
        }

        public IList<string> WordBreak2(string s, IList<string> wordDict) {
            return helper2(s, wordDict);
        }

        private List<string> helper2(string s, IList<string> wordDict) { //using Hash Map as a cache (dynamic programing))

            if (hMap.ContainsKey(s)) //base case
                return hMap[s];

            List<string> results = new List<string>();

            if (string.IsNullOrEmpty(s)) {
                results.Add("");
                return results;
            }

            foreach (var word in wordDict) {

                if (s.StartsWith(word)) {
                    string sub = s.Substring(word.Length);
                    List<string> subStrings = helper2(sub, wordDict);

                    foreach (var item in subStrings) {
                        string optionalSpace = string.IsNullOrEmpty(item) ? "" : " ";
                        results.Add(word + optionalSpace + item);
                    }
                }

            }

            hMap[s] = results; //Adding to cache
            return results;
        }
    }
}
