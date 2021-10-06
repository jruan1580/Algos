using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Sum
    {
        public ListNode<int> SumOfTwoLinkedList(ListNode<int> l1, ListNode<int> l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            if (l1 != null && l2 == null)
            {
                return l1;
            }

            if (l2 != null && l1 == null)
            {
                return l2;
            }

            var reverseAlg = new Reverse();

            var reverseL1 = reverseAlg.ReverseIteratively(l1);
            var reverseL2 = reverseAlg.ReverseIteratively(l2);

            var firstData = reverseL1.Data + reverseL2.Data;
            var carry = firstData / 10;
            var sumHead = new ListNode<int>(firstData % 10, null);
            var sumTail = sumHead;
            reverseL1 = reverseL1.Next;
            reverseL2 = reverseL2.Next;

            while(reverseL1 != null && reverseL2 != null)
            {
                var data = reverseL1.Data + reverseL2.Data + carry;
                carry = data / 10;

                sumTail.Next = new ListNode<int>(data % 10, null);
                sumTail = sumTail.Next;

                reverseL1 = reverseL1.Next;
                reverseL2 = reverseL2.Next;
            }

            //still more to l1
            while(reverseL1 != null && reverseL2 == null)
            {
                var data = reverseL1.Data + carry;
                carry = data / 10;

                sumTail.Next = new ListNode<int>(data % 10, null);
                sumTail = sumTail.Next;

                reverseL1 = reverseL1.Next;
            }

            //more to L2
            while(reverseL2 != null && reverseL1 == null)
            {
                var data = reverseL2.Data + carry;
                carry = data / 10;

                sumTail.Next = new ListNode<int>(data % 10, null);
                sumTail = sumTail.Next;

                reverseL2 = reverseL2.Next;
            }

            if (reverseL1 == null && reverseL2 == null && carry == 0)
            {
                return reverseAlg.ReverseIteratively(sumHead);
            }

            sumTail.Next = new ListNode<int>(carry, null);
            sumTail = sumTail.Next;

            return reverseAlg.ReverseIteratively(sumHead);
        }
    }
}
