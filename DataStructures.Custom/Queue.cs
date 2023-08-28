namespace DataStructures.Custom;

/// <summary>
/// Refactor this class and Stack to extract an arrayList class
/// </summary>
public class Queue : IQueue
{
    private const int DefaultSize = 100;

    private double _size = 100;

    // first in first out
    private int[] _internalStorage = new int[DefaultSize];
    private int _backOfTheQueue = 0;
    private int _frontOfTheQueue = 0;
    public int Length => _backOfTheQueue - _frontOfTheQueue;

    public void Enqueue(int value)
    {
        _internalStorage[_backOfTheQueue] = value;
        _backOfTheQueue++;

        checkIfReallocateRequired();
        checkIfResizeRequired();
    }

    public int Dequeue()
    {
        _frontOfTheQueue++;
        return _internalStorage[_frontOfTheQueue - 1];
    }

    public int Peek()
    {
        return _internalStorage[_frontOfTheQueue];
    }

    public bool IsEmpty()
    {
        return _backOfTheQueue == _frontOfTheQueue;
    }

    private void checkIfResizeRequired()
    {
        // at 75% of capacity
        if (Length >= _size * 0.75)
        {
            createExpandedStorage();
        }
    }

    private void checkIfReallocateRequired()
    {
        if (_frontOfTheQueue > 0 && _backOfTheQueue >= _size * 0.75)
        {
            int emptySpaces = _frontOfTheQueue - 1;
            // loop over the array and move each item to the empty spaces
            for (int i = 0; i < Length - 1; i++)
            {
                _internalStorage[i] = _internalStorage[_frontOfTheQueue];

                _frontOfTheQueue--;
                _backOfTheQueue--;
            }
        }
    }

    private void createExpandedStorage()
    {
        // double the capacity of the internal storage
        _size *= 1.5;
        int[] expandedStorage = new int[Convert.ToInt32(_size)];


        int left = 0,
            right = Length - 1;

        int mid = Length / 2;
        while (left < right)
        {
            expandedStorage[left] = _internalStorage[left];
            expandedStorage[right] = _internalStorage[right];
            left++;
            right--;
        }

        // if odd number of items
        expandedStorage[mid] = _internalStorage[mid];

        // update internal storage to be expanded storage
        _internalStorage = expandedStorage;
    }
}