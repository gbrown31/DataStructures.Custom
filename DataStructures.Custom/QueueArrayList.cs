using DataStructures.Custom.Base;

namespace DataStructures.Custom;

/// <summary>
/// Refactor this class and Stack to extract an arrayList class
/// </summary>
public class QueueArrayList<T> : BaseArrayList<T>, IQueue<T>
{
    private int _backOfTheQueue = 0;
    private int _frontOfTheQueue = 0;
    public int Length => _backOfTheQueue - _frontOfTheQueue;

    public void Enqueue(T value)
    {
        base[_backOfTheQueue] = value;
        _backOfTheQueue++;

        checkIfReallocateRequired();
        base.checkIfResizeRequired(Length);
    }

    public T Dequeue()
    {
        _frontOfTheQueue++;
        return base[_frontOfTheQueue - 1];
    }

    public T Peek()
    {
        return base[_frontOfTheQueue];
    }

    public bool IsEmpty()
    {
        return _backOfTheQueue == _frontOfTheQueue;
    }


    private void checkIfReallocateRequired()
    {
        if (_frontOfTheQueue > 0 && _backOfTheQueue >= base.Size * 0.75)
        {
            int emptySpaces = _frontOfTheQueue - 1;
            // loop over the array and move each item to the empty spaces
            for (int i = 0; i < Length - 1; i++)
            {
                base[i] = base[_frontOfTheQueue];

                _frontOfTheQueue--;
                _backOfTheQueue--;
            }
        }
    }
}