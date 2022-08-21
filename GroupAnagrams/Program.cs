using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupAnagrams {
//    Given an array of strings strs, group the anagrams together.You can return the answer in any order.
//An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters
//exactly once.

//Example 1:
//Input: strs = ["eat","tea","tan","ate","nat","bat"]
//    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

//Example 2:
//Input: strs = [""]
//    Output: [[""]]

//Example 3:
//Input: strs = ["a"]
//    Output: [["a"]]

    class Program {
        static void Main(string[] args) {

            List<IList<string>> lst1 = (List<IList<string>>)GroupAnagrams(new string[]{"eat","tea","tan","ate","nat","bat"});
            List<IList<string>> lst2 = (List<IList<string>>)GroupAnagrams(new string[] { "" });
            List<IList<string>> lst3 = (List<IList<string>>)GroupAnagrams(new string[] { "a" });

            lst1.ForEach(x => x.ToList().ForEach(y => Console.WriteLine(y))); //Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
            lst2.ForEach(x => x.ToList().ForEach(y => Console.WriteLine(y))); //Output: [[""]]
            lst3.ForEach(x => x.ToList().ForEach(y => Console.WriteLine(y))); //Output: [["a"]]

        }

        public static IList<IList<string>> GroupAnagrams(string[] strs) {

            List<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> hMap = new Dictionary<string, List<string>>();

            foreach (var item in strs) {
                var ordered = item.OrderBy(x => x).ToArray();
                string key = new string(ordered);

                if (hMap.ContainsKey(key)) {
                    hMap[key].Add(item);
                } else {
                    hMap[key] = new List<string>() { item };
                }
                
            }

            foreach (var item in hMap.Values) {
                result.Add(item);
            }

            return result;
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs) {
            if (strs.Length == 0) {
                return new List<IList<string>>();
            }

            List<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> hMap = new Dictionary<string, List<string>>();

            foreach (var item in strs) {

                char[] arr = item.ToCharArray(); 
                Array.Sort(arr);    
                string current = new string(arr);


                if (!hMap.ContainsKey(current)) {
                    hMap[current] = new List<string>();
                }

                hMap[current].Add(item); // This means: "list.Add(item)"

            }

            foreach (var item in hMap.Values) {
                result.Add(item);
            }

            return result;
        }
        
    }
}
