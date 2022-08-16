using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostCommonWord {
    //Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.
    //It is guaranteed there is at least one word that is not banned, and that the answer is unique.
    //The words in paragraph are case-insensitive and the answer should be returned in lowercase.
    //
    //Example 1:
    //Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
    //Output: "ball"
    //Explanation: 
    //"hit" occurs 3 times, but it is a banned word.
    //"ball" occurs twice(and no other word does), so it is the most frequent non-banned word in the paragraph.
    //Note that words in the paragraph are not case sensitive,
    //that punctuation is ignored (even if adjacent to words, such as "ball,"), 
    //and that "hit" isn't the answer even though it occurs more because it is banned.
    //
    //Example 2:
    //Input: paragraph = "a.", banned = []
    //Output: "a"

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.",
                new string[] { "hit" })); //Expected: "ball"
            Console.WriteLine(MostCommonWord("a.", new string[] { "" })); //Expected: "a"         
            Console.WriteLine(MostCommonWord("a, a, a, a, b,b,b,c, c", new string[] { "a" })); //Expected: "b"               
            Console.WriteLine(MostCommonWord("Bob. hIt, baLl", new string[] { "bob", "hit" } )); //Expected: "ball"            
            Console.WriteLine(MostCommonWord("j.t ? T.z! R, v, F' x! L; l! W. M; S. y? r! n; O. q; I? h; w. t; y; X? y, p. k! k, " +
                "h, J, r? w! U! V; j' u; R! z.s.T' k. P? M' I' j! y. P, T! e; X. w? M! Y, X; G; d, X? S' F, K? V, r' v, v, D, w, " +
                "K! S? Q! N. n. V. v. t? t' x! u.j; m; n! F, V' Y! h; c! V, v, X' X' t? n; N' r; x.W' P? W; p' q, S' X, J; R. x; " +
                "z; z! G, U; m. P; o. P! Y; I, I' l' J? h; Q; s? U, q, x. J, T! o. z, N, L; u, w! u, S. Y! V; S? y' E! O; p' X, " +
                "w. p' M, h! R; t? K? Y' z? T? w; u. q' R, q, T.R? I. R! t, X, s? u; z.u, Y, n' U; m; p? g' P? y' v, o? K? R. Q? " +
                "I! c, X, x. r' u! m' y. t. W; x! K? B. v; m, k; k' x; Z! U! p.U? Q, t, u' E' n? S' w. y; W, x? r. p! Y? q, Y. t, " +
                "Z' V, S.q; W.Z, z? x!k, I.n; x? z; V? s!g, U; E' m! Z? y' x? V!t, F.Z? Y' S! z, Y' T? x? v? o!l; d; G' L. L, Z? " +
                "q. w' r? U!E, H.C, Q! O? w!s ? w' D. R, Y? u. w, N. Z? h. M? o, B, g, Z! t! l, W? z, o? z, q! O? u, N; o' o? V; " +
                "S! z; q! q.o, t! q! w! Z? Z? w, F? O' N' U' p? r' J' L; S. M; g' V.i, P, v, v, f; W? L, y!i' z; L? w. v, s! P?", 
                new string[] { 
                    "m", "q", "e", "l", "c", "i", "z", "j", "g", "t", "w", "v", "h", "p", "d", "b", "a", "r", "x", "n"
                }));//Expected: "y"            
        }

        public static string MostCommonWord(string paragraph, string[] banned) {

            HashSet<string> hSet = new HashSet<string>();
            Dictionary<string, int> hMap = new Dictionary<string, int>();
            string max = string.Empty;

            foreach (var item in banned) {
                hSet.Add(item);
            }

            string[] words = paragraph.ToLower().Split(new char[] { '!', '?', '\'', ',', ';', '.', ' ' });
            //string[] words = System.Text.RegularExpressions.Regex.Split(paragraph.ToLower(), @"\W+");                                

            foreach (var item in words) {
                if (item == String.Empty) {
                    continue;
                }

                if (!hSet.Contains(item)) {
                    if (hMap.ContainsKey(item)) {
                        hMap[item]++;
                    } else {
                        hMap[item] = 1;
                    }

                    if (string.IsNullOrEmpty(max))  //max = max == string.Empty ? item : max;                                      
                        max = item;                 //max = string.IsNullOrEmpty(max) ? item : max;                                                                                      

                    if (hMap[item] > hMap[max])
                        max = item;                    
                }
            }

            return max;
        }

        public static string MostCommonWord2(string paragraph, string[] banned) {
            
            StringBuilder sb = new StringBuilder();
            List<string> banLst = new List<string>();

            foreach (var item in banned) {
                banLst.Add(item.ToLower());
            }

            foreach (var item in paragraph) {
                if (item == '!' || item == '?' || item == ',' || item == ';' || item == '.' || item == '\'') {
                    sb.Append(' ');
                } else {
                    sb.Append(char.ToLower(item));
                }
            }

            string[] arr = sb.ToString().Split(' ');

            Dictionary<string, int> hMap = new Dictionary<string, int>();

            foreach (var item in arr) {
                if (item == String.Empty) {
                    continue;
                }

                if (!banLst.Contains(item)) {
                    if (hMap.ContainsKey(item)) {
                        hMap[item]++;
                    } else {
                        hMap[item] = 1;
                    }
                }
            }

            foreach (var item in hMap) {
                if (item.Value == hMap.Max(x => x.Value)) {
                    return item.Key;
                }
            }

            return arr[0];
        }

    }
}
