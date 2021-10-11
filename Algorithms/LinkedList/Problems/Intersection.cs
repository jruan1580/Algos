using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class Intersection
    {
        public bool HasIntersection(ListNode<int> head1, ListNode<int> head2)
        {            
            if ((head1 == null && head2 == null) || (head1 != null && head2 == null) || (head1 == null && head2 != null))
            {
                return false;
            }

            var len1 = 0;
            var curr1 = head1;
            while(curr1 != null)
            {
                len1++;
                curr1 = curr1.Next;
            }

            var curr2 = head2;
            var len2 = 0;
            while(curr2 != null)
            {
                len2++;
                curr2 = curr2.Next;
            }

            var diff = Math.Abs(len1 - len2);
            curr1 = head1;
            curr2 = head2;
            var count = 0;
            while(count < diff)
            {
                if (len1 >= len2)
                {
                    curr1 = curr1.Next;
                }
                else
                {
                    curr2 = curr2.Next;
                }
                count++;
            }       
            
            while(curr1 != null && curr2 != null)
            {
                if (curr1 == curr2)
                {
                    return true;
                }

                curr1 = curr1.Next;
                curr2 = curr2.Next;
            }

            return false;
        }
    }
}
