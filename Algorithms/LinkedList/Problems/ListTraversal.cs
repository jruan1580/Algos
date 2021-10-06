using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Problems
{
    public class ListTraversal
    {
        public int GetMiddleElement(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return -1;
            }

            var fasterPter = head;
            var slowerPter = head;

            while(fasterPter != null && fasterPter.Next != null)
            {
                fasterPter = fasterPter.Next.Next;
                slowerPter = slowerPter.Next;
            }

            return slowerPter.Value;
        }
    }
}
