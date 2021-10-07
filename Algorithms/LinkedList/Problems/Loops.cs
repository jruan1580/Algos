using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Loops
    {
        public ListNode<int> FindBeginningOfLoop(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }

            var slow = head.Next;
            var fast = head.Next?.Next;

            while(slow != fast && fast != null)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;
            }

            //no loop, we've reached an end
            if (fast == null)
            {
                return null;
            }

            slow = head;
            while(slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow; //when they meet is the beginning of the loop.
        }

        public ListNode<int> RemoveLoopInList(ListNode<int> head)
        {
            if (head == null)
            {
                return head;
            }

            var slower = head.Next;
            var faster = head.Next?.Next;

            while(slower != faster && faster != null)
            {
                slower = slower.Next;
                faster = faster.Next?.Next;
            }

            //no loops
            if (faster == null)
            {
                return head;
            }

            slower = head;
            ListNode<int> prev = null;

            while(slower != faster)
            {                
                slower = slower.Next;
                prev = faster;
                faster = faster.Next;
            }

            //currently, faster and slower points to beginning of the loop
            var endOfLoop = slower.Next;
            while(endOfLoop.Next != slower)
            {
                endOfLoop = endOfLoop.Next;
            }

            endOfLoop.Next = null;
         
            return head;
        }
    }
}
