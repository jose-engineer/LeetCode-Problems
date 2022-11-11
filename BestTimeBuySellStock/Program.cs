using System;
using System.Diagnostics;
using System.Linq;
using System.Transactions;

namespace BestTimeBuySellStock {

//You are given an array prices where prices[i] is the price of a given stock on the ith day.
//You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
//Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.

//Example 1:
//Input: prices = [7, 1, 5, 3, 6, 4]
//Output: 5
//Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
//Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

//Example 2:
//Input: prices = [7,6,4,3,1]
//    Output: 0
//Explanation: In this case, no transactions are done and the max profit = 0.

    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })); //Expected: 5
            Console.WriteLine(MaxProfit(new int[] { 7, 6, 4, 3, 1 })); //Expected: 0
        }

        public static int MaxProfit(int[] prices) {
            int maxProfit = 0;
            int min = prices.Max();

            for (int i = 0; i < prices.Length; i++) {
                if (prices[i] < min) {
                    min = prices[i];
                }

                int profit = prices[i] - min; //calculating profit if sold today by, Buy - sell

                if (profit > maxProfit) { //maxProfit = Math.Max(maxProfit, profit);
                    maxProfit = profit;
                }
            }

            return maxProfit;
        }        

        public static int MaxProfit2(int[] prices) {
            int maxProfit = 0;

            for (int i = 0; i < prices.Length - 1; i++) {
                for (int j = i + 1; j < prices.Length; j++) {
                    
                    int profit = prices[j] - prices[i];

                    if (profit > maxProfit) {
                        maxProfit = profit;
                    }                        
                }
            }

            return maxProfit;
        }

        public int MaxProfit4(int[] prices) {
            int start = 0, end = 1;
            int maxProfit = 0;

            while (end < prices.Length) {

                if (prices[start] < prices[end]) {
                    int profit = prices[end] - prices[start];
                    maxProfit = Math.Max(maxProfit, profit);
                } else {
                    start = end;
                }

                end++;
            }

            return maxProfit;
        }

    }
}
