using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Spiral
    {
        public void PrintInSpiral(int [,] matrix)
        {
            var k = 0; //start of row
            var m = matrix.GetLength(0) - 1; //end of row
            var l = 0; //start of col
            var n = matrix.GetLength(1) - 1; //end of col
            
            while (k < m && l < n)
            {
                //print first row
                for (var i = k; i <= n; i++)
                {
                    Console.Write(matrix[k, i] + " ");
                }
                k++; //go to next row

                //print last col
                for(var i = k; i <= m; i++)
                {
                    Console.Write(matrix[i, m] + " ");
                }
                n--;//go to next column

                //print last row
                if (k < m)
                {
                    for (var i = n; i >= l; i--)
                    {
                        Console.Write(matrix[m, i] + " ");
                    }
                    m--; //move next row
                }
                
                if (l < n)
                {
                    for (var i = m; i > k; i--)
                    {
                        Console.Write(matrix[i, l] + " ");
                    }

                    l++;//move to next col
                }
            }
        }
    }
}
