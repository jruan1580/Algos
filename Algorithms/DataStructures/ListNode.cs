namespace DataStructures
{
    public class ListNode<T>
    {
        public ListNode(T data, ListNode<T> next)
        {
            Data = data;
            Next = next;
        }

        public T Data { get; set; }

        public ListNode<T> Next { get; set; }
    }
}
