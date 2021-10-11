using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Rotate
    {
        public ListNode<int> RotateRight(ListNode<int> head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var current = head;
            

            while (current.Next != null)
            {
                current = current.Next;
            }

            var tail = current;
            current = head;
            ListNode<int> next = current;

            var count = 0;
            while(count < k && next != null)
            {
                next = current.Next;                
                tail.Next = current;
                current.Next = null;
                tail = tail.Next;
                current = next;
                count++;
            }

            return (current == null) ? head : current;
        }
    }
}
