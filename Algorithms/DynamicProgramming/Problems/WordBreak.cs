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

        public void WordWrap(string sentence, int width)
        {
            var split = sentence.Split(" ");
            var dp = new int[split.Length, split.Length];            

            for(var i = 0; i < dp.GetLength(0); i++)
            {
                for(var j = i; j < dp.GetLength(1); j++)
                {
                    var sen = string.Join(' ', split, i, j - i + 1);
                    if (sen.Length > width)
                    {
                        dp[i, j] = int.MaxValue;
                    }
                    else
                    {
                        var remaining = width - sen.Length;
                        dp[i, j] = remaining * remaining; //square of it
                    }
                }
            }

            var minSpaces = new int[split.Length];            
            var lineBreak = new int[split.Length];
            for(var i = split.Length - 1; i >= 0; i--)
            {                
                minSpaces[i] = dp[i, split.Length - 1];
                lineBreak[i] = split.Length;
                for(var j = split.Length - 1; j < i; j--)
                {
                    if (dp[i, j - 1] == int.MaxValue)
                    {
                        continue;
                    }

                    if (minSpaces[j] + dp[i, j - 1] < minSpaces[i])
                    {
                        minSpaces[i] = minSpaces[j] + dp[i, j - 1];
                        lineBreak[i] = j;
                    }
                }             
            }

            var start = 0;
            var end = 0;
            StringBuilder builder = new StringBuilder();
            do
            {
                end = lineBreak[start];
                for (int k = start; k < end; k++)
                {
                    builder.Append(split[k] + " ");
                }
                builder.Append("\n");
                start = end;
            } while (end < split.Length);
        }

        private void PrintBoard<T>(T [,] board)
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
                        Console.Write(board[row, col].ToString() + " ");
                    }
                    
                }
                Console.WriteLine();
            }            
        }
    }
}
