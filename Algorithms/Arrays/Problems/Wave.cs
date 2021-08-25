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
    }
}
