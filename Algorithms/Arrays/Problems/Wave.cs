using System;


namespace Arrays.Problems
{
    public class Wave
    {
        public void SortArrayInWaveWithSort(int [] arr)
        {
            Array.Sort(arr);

            for (var i = 0; i < arr.Length; i += 2)
            {
                var tmp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = tmp;
            }
        }

        public void SortArrayInWaveWithoutSort(int [] arr)
        {
            for (int i = 0; i < arr.Length; i+= 2)
            {
                if (i == 0)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        var tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                    }
                }
                else
                {
                    if (arr[i] < arr[i - 1])
                    {
                        var tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
                    }

                    if (arr[i] < arr[i + 1])
                    {
                        var tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                    }
                }
            }
        }

        public int LongestAlternatingSubsequence(int [] arr, int n)
        {
            int[,] las = new int[n, 2];

            /* Initialize all values from 1 */
            for (int i = 0; i < n; i++)
                las[i, 0] = las[i, 1] = 1;

            // Initialize result
            int res = 1;

            /* Compute values in
            bottom up manner */
            for (int i = 1; i < n; i++)
            {
                // Consider all elements as
                // previous of arr[i]
                for (int j = 0; j < i; j++)
                {
                    // If arr[i] is greater, then
                    // check with las[j][1]
                    if (arr[j] < arr[i] &&
                        las[i, 0] < las[j, 1] + 1)
                        las[i, 0] = las[j, 1] + 1;

                    // If arr[i] is smaller, then
                    // check with las[j][0]
                    if (arr[j] > arr[i] &&
                    las[i, 1] < las[j, 0] + 1)
                        las[i, 1] = las[j, 0] + 1;
                }

                /* Pick maximum of both
                values at index i */
                if (res < Math.Max(las[i, 0],
                                   las[i, 1]))
                    res = Math.Max(las[i, 0],
                                   las[i, 1]);
            }

            return res;
        }
    }
}
