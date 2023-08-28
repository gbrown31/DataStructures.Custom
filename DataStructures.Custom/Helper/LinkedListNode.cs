namespace DataStructures.Custom;

public class LinkedListNode<T>
{
    public LinkedListNode<T> Next { get; set; }
    public T Value { get; }

    public LinkedListNode(T element)
    {
        Value = element;
    }
}