namespace DataStructures.Custom;

public class DoubleLinkedListNode<T>
    where T : IEquatable<T>
{
    public DoubleLinkedListNode<T> Next { get; set; }
    public DoubleLinkedListNode<T> Prev { get; set; }
    public T Value { get; }

    public DoubleLinkedListNode(T element)
    {
        Value = element;
    }
}