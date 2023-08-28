using DataStructures.Custom.Base;
namespace DataStructures.Custom;

public class StackArrayList<T> : BaseArrayList<T>, IStack<T>
{
    private int pointerToTopStack = 0;

    public int Length => pointerToTopStack;

    public void Push(T value)
    {
        // pushing an item onto the array means we need to store it somewhere accessible on the internal storage
        // try storing at the last item
        base[pointerToTopStack] = value;
        pointerToTopStack++;

        base.checkIfResizeRequired(pointerToTopStack);
    }

    public T Pop()
    {
        pointerToTopStack--;
        return base[pointerToTopStack];
    }

    public T Peek()
    {
        return base[pointerToTopStack - 1];
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

}
