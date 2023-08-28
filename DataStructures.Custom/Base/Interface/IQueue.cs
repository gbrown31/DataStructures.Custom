namespace DataStructures.Custom;

public interface IQueue
{
    void Enqueue(int value);
    int Dequeue();
    int Peek();
    bool IsEmpty();
}
public interface IQueue<T>
{
    void Enqueue(T value);
    T Dequeue();
    T Peek();
    bool IsEmpty();
}