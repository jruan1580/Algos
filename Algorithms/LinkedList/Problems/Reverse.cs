using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Reverse
    {
        public ListNode<int> ReverseIteratively(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.Next == null)
            {
                return head;
            }

            var next = head.Next.Next;
            var prev = head;
            head = head.Next;
            prev.Next = null;

            while(next != null)
            {
                head.Next = prev;
                prev = head;
                head = next;
                next = head.Next;
            }

            head.Next = prev;


            return head;
        }

        public ListNode<int> ReverseRecursively(ListNode<int> head)
        {
            if (head.Next == null)
            {
                return head;
            }

            if (head == null)
            {
                return null;
            }

            var headOfReverse = ReverseRecursively(head.Next);
            var tail = headOfReverse;
            while(tail.Next != null)
            {
                tail = tail.Next;
            }

            tail.Next = head;
            head.Next = null;

            return headOfReverse;
        }
    }
}
