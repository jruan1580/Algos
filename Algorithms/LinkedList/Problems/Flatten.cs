using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Flatten
    {
        public ListNode<int> FlatteningList(SpecialFlattenNode head)
        {
            if (head == null)
            {
                return null;
            }

            var sortedListHead = FlatteningList(head.Right);
            
            var newSortedList = Merge(head, sortedListHead);

            return newSortedList;
        }

        private ListNode<int> Merge(SpecialFlattenNode l1, ListNode<int> l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            var head1 = l1;
            var head2 = l2;

            ListNode<int> newListHead = null;
            ListNode<int> newListTail = null;

            //merge the two
            while (head1 != null && head2 != null)
            {
                var newNode = (head1.Data <= head2.Data) ? new ListNode<int>(head1.Data, null) : new ListNode<int>(head2.Data, null);
                
                //no head yet meaning list is empty
                if (newListHead == null)
                {
                    newListHead = newNode;
                    newListTail = newListHead;
                }
                else
                {
                    newListTail.Next = newNode;
                    newListTail = newListTail.Next;
                }

                if (head1.Data <= head2.Data)
                {
                    head1 = head1.Down;
                }
                else
                {
                    head2 = head2.Next;
                }
            }

            //add rest of first list
            while (head1 != null && head2 == null)
            {
                if (newListHead == null)
                {
                    newListHead = new ListNode<int>(head1.Data, null);
                    newListTail = newListHead;
                }
                else
                {
                    newListTail.Next = new ListNode<int>(head1.Data, null);
                    newListTail = newListTail.Next;
                }

                head1 = head1.Down;
            }

            //add rest of second list
            while (head2 != null && head1 == null)
            {
                if (newListHead == null)
                {
                    newListHead = new ListNode<int>(head2.Data, null);
                    newListTail = newListHead;
                }
                else
                {
                    newListTail.Next = new ListNode<int>(head2.Data, null);
                    newListTail = newListTail.Next;
                }

                head2 = head2.Next;
            }

            return newListHead;
        }
    }
}
