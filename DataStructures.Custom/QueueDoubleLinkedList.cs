namespace DataStructures.Custom;

public class QueueDoubleLinkedList<T> : IQueue<T>
    where T : IEquatable<T>
{
    private DoubleLinkedList<T> _linkedList;
    public int Length => _linkedList.Count;

    public QueueDoubleLinkedList()
    {
        _linkedList = new DoubleLinkedList<T>();
    }

    public void Enqueue(T value)
    {
        _linkedList.AddFirst(value);
    }

    public T Dequeue()
    {
        return _linkedList.RemoveLast();
    }

    public T Peek()
    {
        return _linkedList.GetLast();
    }

    public bool IsEmpty()
    {
        return _linkedList.Count == 0;
    }
}