using DataStructures.Custom.Base;

namespace DataStructures.Custom;

public class Hashtable<T> where T : IEquatable<T> 
{
    private int numOfItems = 0;
    public int Count => numOfItems;
    private ArrayList<DoubleLinkedList<T>> internalStorage = new ArrayList<DoubleLinkedList<T>>();

    public Hashtable()
    {
    }

    public void Insert(int key, T element)
    {
        int hashIndex = getHashCode(key);
        
        // if index is null create new storage
        if (internalStorage[hashIndex] == null)
        {
            DoubleLinkedList<T> chain = new DoubleLinkedList<T>();
            chain.AddFirst(element);
            internalStorage[hashIndex] = chain;
        }
        else
        {
            // else add to storage
            internalStorage[hashIndex].AddFirst(element);
        }

        numOfItems++;
    }

    public T Get(int key)
    {
        int hashIndex = getHashCode(key);
        return internalStorage[hashIndex].GetFirst();
    }

    public bool Contains(int key, T item)
    {
        int hashIndex = getHashCode(key);
        if (internalStorage[hashIndex] != null)
        {
            return internalStorage[hashIndex].GetIndexOf(item) > -1;
        }

        return false;
    }

    private int getHashCode(int key)
    {
        return key % 20;
    }
}