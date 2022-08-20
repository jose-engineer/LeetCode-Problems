using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupAnagrams {
//    Given an array of strings strs, group the anagrams together.You can return the answer in any order.
//An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.



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
            Console.WriteLine("Hello World!");
        }

        public IList<IList<string>> GroupAnagrams(string[] strs) {
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

        public static IList<IList<string>> GroupAnagrams2(string[] strs) {

            List<IList<string>> result = new List<IList<string>>();

            for (int i = 0; i < strs.Length; i++) {

                char[] str1 = strs[i].ToCharArray();
                Array.Sort(str1);

                for (int j = i; j <= strs.Length - 1; j++) {

                    char[] str2 = strs[j].ToCharArray();
                    Array.Sort(str2);

                    if (new string(str1) == new string(str2)) {
                        Console.WriteLine("IN");
                        //result[i][j] = strs[j];                    
                    } else {
                        continue;
                    }

                }
            }

            return result;
        }
    }
}
