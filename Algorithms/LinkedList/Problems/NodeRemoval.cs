using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class NodeRemoval
    {
        //public ListNode<int> RemoveNodeThatEqualsToZero(ListNode<int> head)
        //{
        //    if (head == null)
        //    {
        //        return null;
        //    }

        //    var sum = head.Data;
        //    var tmp = head.Next;

        //    while
        //}

        public ListNode<int> DeleteMiddle(ListNode<int> head)
        {
            if (head == null || head.Next == null)
            {
                return null;
            }            

            var fasterPtr = head;
            var slowerPtr = head;
            ListNode<int> prev = null;

            while(fasterPtr != null && fasterPtr.Next != null)
            {
                prev = slowerPtr;
                fasterPtr = fasterPtr.Next.Next;
                slowerPtr = slowerPtr.Next;
            }

            prev.Next = slowerPtr.Next;

            return head;
        }

        public ListNode<int> DeleteDuplicateInSortedList(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.Next == null)
            {
                return head;
            }

            var currVal = head.Data;
            var newListHead = head;
            var tmp = head.Next;
            var prev = newListHead;
            
            while(tmp != null)
            {
                //find the next not duplicate value
                if (tmp.Data == currVal)
                {
                    tmp = tmp.Next;
                    continue;
                }

                //found next new valuse
                currVal = tmp.Data;
                prev.Next = tmp;
                prev = prev.Next;
            }

            prev.Next = null;

            return newListHead;
        }
    }
}
