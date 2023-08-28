using System.Collections;
using DataStructures.Custom.Base;

namespace DataStructures.Custom;

public class ArrayList<T> : BaseArrayList<T>, IList<T>
{
    public int Count { get; private set; }
    public bool IsReadOnly { get; }
    
    public T this[int index]
    {
        get => base[index];
        set => base[index] = value;
    }

    public ArrayList()
    {
        Count = 0;
        IsReadOnly = false;
    }
    
    public void Add(T item)
    {
        this[Count] = item;
        Count++;

        base.checkIfResizeRequired(Count);
    }

    public void Clear()
    {
        Count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Size; i++)
        {
            if (this[i].Equals(item))
            {
                this[i] = default(T);
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < Size; i++)
        {
            if (this[i].Equals(item))
            {
                this[i] = default(T);
                Count--;
                return true;
            }
        }

        return false;
    }
    
    public int IndexOf(T item)
    {
        for (int i = 0; i < Size; i++)
        {
            if (this[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (!this[index].Equals(default(T)))
        {
            Count++;
        }
        this[index] = item;

        base.checkIfResizeRequired(Count);
    }

    public void RemoveAt(int index)
    {
        if (!this[index].Equals(default(T)))
        {
            Count--;
        }
        this[index] = default(T);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}