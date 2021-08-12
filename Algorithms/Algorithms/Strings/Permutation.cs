﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
{
    public class Permutation
    {
        public void Permute(string str, string permSoFar)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(permSoFar);
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                var currentChar = str[i];
                var leftSub = str.Substring(0, i);
                var rightSub = str.Substring(i + 1);
                Permute(leftSub + rightSub, currentChar + permSoFar);
            }
        }

        public void DistinctPermute(string str, string permSoFar, Dictionary<string, bool> allFinalPerm)
        {
            if (str.Length == 0)
            {
                //seen it, do not print
                if (allFinalPerm.ContainsKey(permSoFar))
                {
                    return;
                }

                //did not see it, print and add to list to tract
                Console.WriteLine(permSoFar);
                allFinalPerm.Add(permSoFar, true);
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                var currentChar = str[i];
                var leftSub = str.Substring(0, i);
                var rightSub = str.Substring(i + 1);
                DistinctPermute(leftSub + rightSub, currentChar + permSoFar, allFinalPerm);
            }
        }

    }
}
