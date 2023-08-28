namespace DataStructures.Custom;

public interface IMyList<T> 
{
    void AddFirst(T value);
    void AddLast(T value);

    T RemoveFirst();
    T RemoveLast();

    T GetFirst();
    T GetLast();

    int GetIndexOf(T value);
    void InsertAt(int index, T value);

    T RemoveAt(int index);
}