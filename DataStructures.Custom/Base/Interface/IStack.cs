namespace DataStructures.Custom;

public interface IStack
{
    void Push(int value);
    int Pop();
    int Peek();
    bool IsEmpty();
}
public interface IStack<T>
{
    void Push(T value);
    T Pop();
    T Peek();
    bool IsEmpty();
}