using System;
using System.Collections.Generic;
using System.Linq;

namespace ReorderDataInLogFiles {
    //You are given an array of logs. Each log is a space-delimited string of words, where the first word is the identifier.
    //There are two types of logs:
    //  - Letter-logs: All words(except the identifier) consist of lowercase English letters.
    //  - Digit-logs: All words(except the identifier) consist of digits.
    //Reorder these logs so that:
    //  1.- The letter-logs come before all digit-logs.
    //  2.- The letter-logs are sorted lexicographically by their contents. If their contents are the same, then sort them
    //      lexicographically by their identifiers.
    //  3.- The digit-logs maintain their relative ordering.
    //Return the final order of the logs.

    //Example:
    //Input: logs = ["dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero"]
    //Output: ["let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6"]
    //Explanation:
    //The letter-log contents are all different, so their ordering is "art can", "art zero", "own kit dig".
    //The digit-logs have a relative order of "dig1 8 1 5 1", "dig2 3 6".
    //4.- Digit logs should maintain their order

    //Example 2:
    //Input: logs = ["a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo"]
    //Output: ["g1 act car", "a8 act zoo", "ab1 off key dog", "a1 9 2 3 1", "zo4 4 7"]

    class Program {
        static void Main(string[] args) {

            Array.ForEach(ReorderLogFiles(new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" }), //"let1 art can" comes first
                        Console.WriteLine);
            Console.WriteLine();
            Array.ForEach(ReorderLogFiles(new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" }), //"g1 act car" comes first
                        Console.WriteLine);
            Console.WriteLine();

            Array.ForEach(ReorderLogFiles(new string[] { "let1 art can", "dig1 8 1 5 1" }), //"let1 art can" comes first
                        Console.WriteLine);
            Console.WriteLine();
            Array.ForEach(ReorderLogFiles(new string[] { "let3 art zero", "let2 own kit dog" }), //"let3 art zero" comes first
                        Console.WriteLine);
            Console.WriteLine();
            Array.ForEach(ReorderLogFiles(new string[] { "let3 leet code", "let2 leet code" }), //"let2 leet code" comes first
                        Console.WriteLine);
            Console.WriteLine();
            Array.ForEach(ReorderLogFiles(new string[] { "let3 leet code", "let2 4 3 1 9" }), //"let3 leet code" comes first
                        Console.WriteLine);
            Console.WriteLine();
            Array.ForEach(ReorderLogFiles(new string[] { "let3 8 3 5", "let2 4 3 1" }), //"let3 8 3 5" comes first at index 0
                        Console.WriteLine);            
        }        

        public static string[] ReorderLogFiles(string[] logs) {

            return logs
                    .Where(x => !IsDigit(x))
                    .OrderBy(x => x.Split(" ", 2)[1])
                    .ThenBy(x => x.Split(" ", 2)[0])
                    .Union(logs.Where(x => IsDigit(x)))
                    .ToArray();

        }

        private static bool IsDigit(string log) {

            int index = log.IndexOf(" ") + 1;
            return char.IsDigit(log[index]);

        }


        //  log1 > log2 -> 1    log2 go first
        //  log1 == log2 -> 0
        //  log1 < log2 -> -1   log1 go first
        //
        //(letterLog, digitLog) return -1
        //(digitLog, letterLog) return +1
        //(digitLog, digitLog)  return 0
        //(letterLog, letterLog) if letterLog1 = letterLog2 then idLog1.CompareTo(idLog2) else letterLog1.CompareTo(letterLog2) 
        public static string[] ReorderLogFiles2(string[] logs) {

            List<string> _letterLogs = new List<string>();
            List<string> _digiLogs = new List<string>();

            for (int i = 0; i < logs.Length; i++) {
                var parts = logs[i].Split(' ');
                if (char.IsDigit(parts[1][0]))
                    _digiLogs.Add(logs[i]);
                else
                    _letterLogs.Add(logs[i]);
            }

            _letterLogs.Sort(new customComp()); //_letterLogs.Sort((log1, log2) => { ... });
            _letterLogs.AddRange(_digiLogs);

            return _letterLogs.ToArray();      
        }

        private class customComp : IComparer<string> {
            public int Compare(string log1, string log2) {
                //2 is the maximum number of elements in the array
                string[] arr1 = log1.Split(" ", 2); //int index1 = log1.IndexOf(" ");
                string[] arr2 = log2.Split(" ", 2); //string id1 = log1.Substring(0, index1);
                                                    //string main1 = log1.Substring(index1 + 1);
                string identifier1 = arr1[0];
                string identifier2 = arr2[0];

                string logs1 = arr1[1];
                string logs2 = arr2[1];

                bool isDigit1 = char.IsDigit(logs1[0]);
                bool isDigit2 = char.IsDigit(logs2[0]);

                if (!isDigit1 && !isDigit2) {
                    int position = logs1.CompareTo(logs2);
                    if (position == 0) {
                        return identifier1.CompareTo(identifier2);
                    }
                    return position;
                }

                if (isDigit1) {
                    if (isDigit2) { //if true means both digit logs so order is not changed
                        return 0;
                    }
                    return 1; //means logs1(digit) > logs2(letter), so logs2(letter) is lesser so should be orderer first
                }

                return -1;
            }
        }
    }
    
}
