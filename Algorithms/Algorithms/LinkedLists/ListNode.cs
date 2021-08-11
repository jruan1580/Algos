namespace Algorithms.LinkedLists
{
    public class ListNode<T>
    {
        public ListNode(T data, ListNode<T> next){
            Data = data;
            Next = Next;
        }

        public T Data { get; set; }
        public ListNode<T> Next { get; set; }        
    }
}
