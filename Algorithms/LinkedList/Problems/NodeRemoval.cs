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

        public ListNode<int> RemoveLastOccurrence(ListNode<int> head, int n)
        {
            if (head == null)
            {
                return head;
            }

            if (head.Next == null && head.Data == n)
            {
                return null;
            }

            var current = head;
            ListNode<int> prev = null;
            ListNode<int> nodeBeforeLastAppearance = null;
            ListNode<int> nodeAfterLastAppearance = null;

            while (current != null)
            {
                if (current.Data == n)
                {
                    if (prev != null)
                    {
                        nodeBeforeLastAppearance = prev;
                    }                    

                    nodeAfterLastAppearance = current.Next;

                }
         
                prev = current;
                current = current.Next;                                
            }

            //element cannot be found
            if (nodeBeforeLastAppearance == null && nodeAfterLastAppearance == null)
            {
                return head;
            }
            
            //element was found at the beginning
            if (nodeBeforeLastAppearance == null && nodeAfterLastAppearance != null)
            {
                return nodeAfterLastAppearance; //return node after last appearance as new head.
            }
            
            nodeBeforeLastAppearance.Next = nodeAfterLastAppearance;
            
            return head;
        }

        public void DeleteGivenNode(ListNode<int> nodeToDelete)
        {
            var tmp = nodeToDelete;
            ListNode<int> prev = null;
            while(tmp.Next != null)
            {
                tmp.Data = tmp.Next.Data;

                prev = tmp;
                tmp = tmp.Next;
            }

            prev.Next = null;
        }
    }
}
