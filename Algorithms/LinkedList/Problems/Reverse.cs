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

            var current = head;
            ListNode<int> next = null;
            ListNode<int> prev = null;
            
            while(current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }      

            return prev;
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
            
            head.Next.Next = head;
            head.Next = null;     

            return headOfReverse;
        }

        public ListNode<int> ReverseInKGroup(ListNode<int> head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var count = 0;
            var current = head;
            var currTail = head;
            ListNode<int> next = null;
            ListNode<int> prev = null;

            while (current != null && count < k)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
                count++;
            }

            var nextReverseSet = ReverseInKGroup(current, k);
            currTail.Next = nextReverseSet;

            return prev;
        }

        public ListNode<int> ReverseAltKNodes(ListNode<int> head, int k, bool reverse)
        {
            if (head == null)
            {
                return head;
            }

            var count = 0;
            var current = head;            
            ListNode<int> next = null;
            ListNode<int> prev = null;

            if (reverse)
            {
                while(current != null && count < k)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                    count++;
                }
            }
            else
            {
                while(current != null && count < k)
                {
                    prev = current;
                    current = current.Next;
                    count++;
                }
            }

            var nextKSet = ReverseAltKNodes(current, k, !reverse);
            var currTail = (reverse) ? head : prev;
            currTail.Next = nextKSet;

            if (reverse)
            {
                return prev;
            }

            return head;
        }
    }
}
