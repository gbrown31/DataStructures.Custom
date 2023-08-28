namespace DataStructures.Custom.Base;

public abstract class BaseArrayList<T>
{
    // last in, first out
    private const int _defaultSize = 100;
    private T[] interalStorage = new T[_defaultSize];
    protected int Size = 100;
    protected virtual T this[int index]
    {
        get
        {
            return interalStorage[index];
        }
        set
        {
            interalStorage[index] = value;
        }
    }
    protected void checkIfResizeRequired(int pointer)
    {
        // at 75% of capacity
        if (pointer >= Size * 0.75)
        {
            // double the capacity of the internal storage
            Size *= 2;
            T[] expandedStorage = new T[Size];


            int left = 0,
                right = pointer - 1;

            int mid = pointer / 2;
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