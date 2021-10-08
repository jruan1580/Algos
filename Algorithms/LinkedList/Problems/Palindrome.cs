using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Palindrome
    {
        public bool IsPalindrome(ListNode<int> l1)
        {
            var reverse = new Reverse();

            var reverseList = reverse.ReverseIteratively(l1);

            var tmp1 = l1;
            var tmp2 = reverseList;

            while(tmp1 != null && tmp2 != null)
            {
                if (tmp1.Data != tmp2.Data)
                {
                    return false;
                }

                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }

            return true;
        }
    }
}
