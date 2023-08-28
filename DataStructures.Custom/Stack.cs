namespace DataStructures.Custom;

public class Stack : IStack
{
    // last in, first out
    private const int _defaultSize = 100;
    private int _size = 100;
    private int[] interalStorage = new int[_defaultSize];
    private int pointerToTopStack = 0;

    public int Length => pointerToTopStack;

    public void Push(int value)
    {
        // pushing an item onto the array means we need to store it somewhere accessible on the internal storage
        // try storing at the last item
        interalStorage[pointerToTopStack] = value;
        pointerToTopStack++;

        checkIfResizeRequired2Pointers();
    }

    public int Pop()
    {
        pointerToTopStack--;
        return interalStorage[pointerToTopStack];
    }

    public int Peek()
    {
        return interalStorage[pointerToTopStack - 1];
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    private void checkIfResizeRequired()
    {
        // at 75% of capacity
        if (pointerToTopStack > _size * 0.75)
        {
            // double the capacity of the internal storage
            _size *= 2;
            int[] expandedStorage = new int[_size];
            // copy all the items over to the new array
            for (int i = 0; i < pointerToTopStack - 1; i++)
            {
                expandedStorage[i] = interalStorage[i];
            }

            // update internal storage to be expanded storage
            interalStorage = expandedStorage;
        }
    }

    private void checkIfResizeRequired2Pointers()
    {
        // at 75% of capacity
        if (pointerToTopStack >= _size * 0.75)
        {
            // double the capacity of the internal storage
            _size *= 2;
            int[] expandedStorage = new int[_size];


            int left = 0,
                right = pointerToTopStack - 1;

            int mid = pointerToTopStack / 2;
            while (left < right)
            {
                expandedStorage[left] = interalStorage[left];
                expandedStorage[right] = interalStorage[right];
                left++;
                right--;
            }

            // if odd number of items
            expandedStorage[mid] = interalStorage[mid];

            // update internal storage to be expanded storage
            interalStorage = expandedStorage;
        }
    }
}