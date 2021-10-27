using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class WordBreak
    {
        public bool WordSplit(string str, HashSet<string> dictionary)
        {
            var dp = new bool[str.Length, str.Length];

            //start with len 1, each individual char in the string
            for(var i = 0; i < str.Length; i++)
            {
                dp[i, i] = (dictionary.Contains(str[i].ToString())) ? true : false;
            }

            for(var sl = 2; sl <= str.Length; sl++)
            {
                for (var row = 0; row < str.Length - sl + 1; row++)
                {
                    var col = row + sl - 1;
                    var currWord = str.Substring(row, (col - row) + 1);

                    //if (currWord == "ilike")
                    //{

                    //}
                    if (dictionary.Contains(currWord))
                    {
                        dp[row, col] = true;
                    }
                    else
                    {
                        //break currword up and see if it contains words at each break point                        
                        var firstWordLen = 1;
                        while(firstWordLen < currWord.Length)
                        {
                            if (dp[row, row + firstWordLen - 1] && dp[row + firstWordLen, col])
                            {
                                dp[row, col] = true;
                                break;
                            }
                            else
                            {
                                dp[row, col] = false;
                            }

                            firstWordLen++;                           
                        }
                    }
                }
            }

            //PrintBoard(dp);
            return dp[0, str.Length - 1];
        }

        private void PrintBoard(bool [,] board)
        {
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (col < row)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        var str = (board[row, col]) ? "T" : "F";
                        Console.Write(str + " ");
                    }
                    
                }
                Console.WriteLine();
            }            
        }
    }
}
