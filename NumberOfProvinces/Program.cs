using System;

namespace NumberOfProvinces {
    //There are n cities. Some of them are connected, while some are not. If city 'a' is connected directly with city 'b',
    //and city 'b' is connected directly with city 'c', then city a is connected indirectly with city 'c'.
    //A province is a group of directly or indirectly connected cities and no other cities outside of the group.
    //You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly
    //connected, and isConnected[i][j] = 0 otherwise.
    //Return the total number of provinces.
    //Example 1:
    //Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
    //Output: 2
    //
    //Example 2:
    //Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
    //Output: 3

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(FindCircleNum(new int[][] { new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 }, new int[] { 0, 0, 1 } })); //Expected: 2
            Console.WriteLine(FindCircleNum(new int[][] { new int[] { 1, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 } })); //Expected: 3
        }

        //[1,1,0]       [1,0,0]
        //[1,1,0]       [0,1,0]
        //[0,0,1]       [0,0,1]
        public static int FindCircleNum(int[][] isConnected) {  //we use dfs (depth first search) algorithm            

            int[] visited = new int[isConnected.Length];
            int count = 0;

            for (int i = 0; i < isConnected.Length; i++) {
                if (visited[i] == 0) {
                    helper(isConnected, visited, i);
                    count++;
                }
            }
            return count;
        }

        public static void helper(int[][] isConnected, int[] visited, int i) {            
            for (int j = 0; j < isConnected.Length; j++) {

                if (isConnected[i][j] == 1 && visited[j] == 0) {
                    visited[j] = 1;
                    helper(isConnected, visited, j);
                }
            }
        }

    }
}
