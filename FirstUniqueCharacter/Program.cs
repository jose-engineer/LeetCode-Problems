using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstUniqueCharacter {

//Given a string s, find the first non-repeating character in it and return its INDEX. If it does not exist, return -1.

//Example 1:
//Input: s = "leetcode"
//Output: 0

//Example 2:
//Input: s = "loveleetcode"
//Output: 2

//Example 3:
//Input: s = "aabb"
//Output: -1

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(FirstUniqChar("leetcode")); //Expected: 0
            Console.WriteLine(FirstUniqChar("loveleetcode")); //Expected: 2
            Console.WriteLine(FirstUniqChar("aabb")); //Expected: -1
        }

        public static int FirstUniqChar(string s) {

            Dictionary<char, int> hMap = new Dictionary<char, int>();

            foreach (var item in s) {
                if (hMap.ContainsKey(item)) {
                    hMap[item]++;
                } else {
                    hMap[item] = 1;
                }
            }

            for (int i = 0; i < s.Length; i++) {
                if (hMap[s[i]] == 1) {
                    return i;
                }
            }

            return -1;
        }

        public static int FirstUniqChar2(string s) {

            List<char> nonRep = s.GroupBy(x => x).Where(x => x.Count() == 1).SelectMany(x => x).ToList(); //flattening IGrouping using SelectMany

            for (int i = 0; i < s.Length; i++) {
                if (nonRep.Contains(s[i])) {
                    return i;
                }
            }

            return -1;
        }
    }
}
