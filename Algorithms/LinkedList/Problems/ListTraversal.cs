using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class ListTraversal
    {
        public int GetMiddleElement(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return -1;
            }

            var fasterPter = head;
            var slowerPter = head;

            while(fasterPter != null && fasterPter.Next != null)
            {
                fasterPter = fasterPter.Next.Next;
                slowerPter = slowerPter.Next;
            }

            return slowerPter.Value;
        }

        public int NthFromLastElement(ListNode<int> head, int n)
        {
            if (head == null)
            {
                return -1;
            }

            var fasterPtr = head;
            var slowerPtr = head;

            var counter = 0;
            while(counter < n && fasterPtr != null)
            {
                fasterPtr = fasterPtr.Next;
                counter++;
            }

            //hit the end of the list meaning list len is less than n
            if (fasterPtr == null)
            {
                return -1;
            }

            while(fasterPtr != null)
            {
                slowerPtr = slowerPtr.Next;
                fasterPtr = fasterPtr.Next;
            }

            return slowerPtr.Data;
        }
    }
}
