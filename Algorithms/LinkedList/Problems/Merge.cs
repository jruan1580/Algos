using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Merge
    {
        public ListNode<int> MergeAltPosition(ListNode<int> head1, ListNode<int> head2)
        {
            var current1 = head1;
            var current2 = head2;
            var i = 0;
            ListNode<int> newListHead = null;
            ListNode<int> tmp = null;

            while(current1 != null && current2 != null)
            {
                if (i % 2 == 0)
                {
                    if (newListHead == null)
                    {
                        newListHead = head1;
                        tmp = newListHead;
                    }
                    else
                    {
                        tmp.Next = current1;
                        tmp = tmp.Next;
                    }

                    current1 = current1.Next;
                }
                else
                {
                    tmp.Next = current2;
                    tmp = tmp.Next;
                    current2 = current2.Next;
                }

                i++;
            }

            while(current1 != null && current2 == null)
            {
                //if this is still null, that means second list is empty, just return first list as is
                if (newListHead == null)
                {
                    return head1;
                }
                else
                {
                    //add the rest of first list
                    tmp.Next = current1;
                    tmp = tmp.Next;
                    current1 = current1.Next;
                }
            }

            while(current1 == null && current2 != null)
            {
                //if this is still null, that means first list is empty, return second list as is
                if (newListHead == null)
                {
                    return head2;
                }
                else
                {
                    //add the rest of second list
                    tmp.Next = current2;
                    tmp = tmp.Next;
                    current2 = current2.Next;
                }
            }

            return newListHead;
        }
    }
}
