namespace Arrays.Problems
{
    public class ZeroesAndOnes
    {
        public void SortArrayIntoZerosOnesTwos(int [] arr)
        {
            var low = 0; //keep track of where our 0s are at
            var mid = 0; //keeps track of 1s
            var high = arr.Length - 1; //keeps track of 2s
            var tmp = 0;
            while (mid <= high)
            {
                switch (arr[mid])
                {
                    case 0:
                        tmp = arr[low];
                        arr[low] = 0; //move 0 to start
                        arr[mid] = tmp;
                        low++;
                        mid++;
                        break;
                    case 1:
                        mid++; //perfect, leave it in middle
                        break;
                    case 2:
                        tmp = arr[high];
                        arr[high] = 2; //move two to end
                        arr[mid] = tmp;
                        high--;
                        break;
                }
            }
        }

        public int SubArrWithEqualZeroAndOne(int [] arr)
        {

        }
    }
}
