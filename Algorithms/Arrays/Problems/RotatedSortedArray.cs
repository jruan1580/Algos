namespace Arrays.Problems
{
    public class RotatedSortedArray
    {
        public int SmallestNumInRotatedSortedArray(int [] rotatedSortedArray, int low, int high)
        {
            if (high < low)
            {
                return rotatedSortedArray[0];
            }

            if (low == high)
            {
                return rotatedSortedArray[low];
            }

            var mid = (low + high) / 2;
            //no left side, look right
            if ((mid - 1) < 0)
            {
                //mid is less than right
                if (rotatedSortedArray[mid] < rotatedSortedArray[mid + 1])
                {
                    return rotatedSortedArray[mid];
                }

                //look on right side
                return SmallestNumInRotatedSortedArray(rotatedSortedArray, mid + 1, high);
            }
         
            //right ride side, look left
            else if ((mid + 1) >= rotatedSortedArray.Length)
            {
                if (rotatedSortedArray[mid] < rotatedSortedArray[mid - 1])
                {
                    return rotatedSortedArray[mid];
                }

                //look on right side
                return SmallestNumInRotatedSortedArray(rotatedSortedArray, low, mid - 1);
            }
            //has both sides
            else
            {
                //mid is less than both left and right, smallest is mid
                if (rotatedSortedArray[mid] < rotatedSortedArray[mid - 1] && rotatedSortedArray[mid] < rotatedSortedArray[mid + 1])
                {
                    return rotatedSortedArray[mid];
                }

                //left side is smaller, look on left side
                if (rotatedSortedArray[mid - 1] < rotatedSortedArray[mid])
                {
                    return SmallestNumInRotatedSortedArray(rotatedSortedArray, low, mid - 1);
                }

                //right side is smaller, look at right side
                return SmallestNumInRotatedSortedArray(rotatedSortedArray, mid + 1, high);
            }            
        }
    }
}
