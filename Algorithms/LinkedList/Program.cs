using DataStructures;
using LinkedList.Problems;
using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var traversal = new ListTraversal();

            //var linkedList = new LinkedList<int>();
            //linkedList.AddLast(1);
            //linkedList.AddLast(2);
            //linkedList.AddLast(3);
            //linkedList.AddLast(4);
            //linkedList.AddLast(5);

            //Console.WriteLine(traversal.GetMiddleElement(linkedList.First));

            //linkedList.AddLast(6);

            //Console.WriteLine(traversal.GetMiddleElement(linkedList.First));

            //var flattenNode = new SpecialFlattenNode();
            //flattenNode.Data = 5;
            //var f2 = new SpecialFlattenNode();
            //f2.Data = 7;
            //flattenNode.Down = f2;
            //var f3 = new SpecialFlattenNode();
            //f3.Data = 8;
            //f2.Down = f3;
            //var f4 = new SpecialFlattenNode();
            //f4.Data = 30;
            //f3.Down = f4;

            //var f5 = new SpecialFlattenNode();
            //f5.Data = 10;
            //flattenNode.Right = f5;
            //var f6 = new SpecialFlattenNode();
            //f6.Data = 20;
            //f5.Down = f6;

            //var f7 = new SpecialFlattenNode();
            //f7.Data = 19;
            //f5.Right = f7;
            //var f8 = new SpecialFlattenNode();
            //f8.Data = 22;
            //f7.Down = f8;
            //var f9 = new SpecialFlattenNode();
            //f9.Data = 50;
            //f8.Down = f9;

            //var f10 = new SpecialFlattenNode();
            //f10.Data = 28;
            //f7.Right = f10;
            //var f11 = new SpecialFlattenNode();
            //f11.Data = 35;
            //f10.Down = f11;
            //var f12 = new SpecialFlattenNode();
            //f12.Data = 40;
            //f11.Down = f12;
            //var f13 = new SpecialFlattenNode();
            //f13.Data = 45;
            //f12.Down = f13;


            //var flatten = new Flatten();
            //var flattenList = flatten.FlatteningList(flattenNode);
            //var tmp = flattenList;
            //while(tmp != null)
            //{
            //    Console.Write(tmp.Data + " ");
            //    tmp = tmp.Next;
            //}

            //var head = new ListNode<int>(1, new ListNode<int>(2, new ListNode<int>(3, new ListNode<int>(4, new ListNode<int>(5, new ListNode<int>(6, null))))));

            //var removal = new NodeRemoval();
            //var modList = removal.DeleteMiddle(head);

            //var tmp = modList;
            //while(tmp != null)
            //{
            //    Console.Write(tmp.Data + " ");
            //    tmp = tmp.Next;
            //}

            var list = new ListNode<int>(2, new ListNode<int>(2, new ListNode<int>(2, new ListNode<int>(2, null))));
            var noDupList = new NodeRemoval().DeleteDuplicateInSortedList(list);
            var tmp = noDupList;
            while (tmp != null)
            {
                Console.Write(tmp.Data + " ");
                tmp = tmp.Next;
            }
        }
    }
}
