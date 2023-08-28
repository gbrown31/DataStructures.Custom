namespace DataStructures.Custom;

public class LinkedList<T> : IMyList<T>
    where T : IEquatable<T>
{
    private int NumberOfNodes = 0;
    public int Count => NumberOfNodes;
    private LinkedListNode<T> Head { get; set; }

    public LinkedList()
    {
    }

    public LinkedList(T[] data)
    {
        if (data.Length == 1)
        {
            Head = new LinkedListNode<T>(data[0]);
            NumberOfNodes++;
        }
        else
        {
            Head = new LinkedListNode<T>(data[0]);
            LinkedListNode<T> current = Head;
            NumberOfNodes++;
            for (int i = 1; i < data.Length; i++)
            {
                current.Next = new LinkedListNode<T>(data[i]);
                current = current.Next;
                NumberOfNodes++;
            }
        }
    }

    public void AddFirst(T value)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(value);
        if (Head == null)
        {
            Head = node;
        }
        else
        {
            LinkedListNode<T> allOtherNodes = Head;
            node.Next = allOtherNodes;
            Head = node;
        }

        NumberOfNodes++;
    }

    public void AddLast(T value)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(value);
        if (Head == null)
        {
            Head = node;
        }
        else
        {
            LinkedListNode<T> prev = getLastNode();
            prev.Next = node;
        }

        NumberOfNodes++;
    }

    public T RemoveFirst()
    {
        T currentHeadValue = Head.Value;

        LinkedListNode<T> allOtherNodes = Head.Next;
        Head = allOtherNodes;
        NumberOfNodes--;

        return currentHeadValue;
    }

    public T RemoveLast()
    {
        // 2, 3, 4
        LinkedListNode<T> current = Head;
        LinkedListNode<T> prev = null;
        // loop through the nodes
        // at the end the prev node will be the 2nd las node in the list
        while (current != null && current.Next != null)
        {
            prev = current;
            current = current.Next;
        }

        T lastNodeValue = prev.Next.Value;
        //current is last node
        //prev is now the 2nd last node
        prev.Next = null;
        NumberOfNodes--;
        return lastNodeValue;
    }

    public T GetFirst()
    {
        return Head.Value;
    }

    public T GetLast()
    {
        return getLastNode().Value;
    }

    public int GetIndexOf(T value)
    {
        int index = 0;
        // loop through the linked list to find where the value matches
        LinkedListNode<T> current = Head;
        bool valueFound = false;
        while (current != null && !valueFound)
        {
            if (current.Value.Equals(value))
            {
                valueFound = true;
            }

            current = current.Next;
            index++;
        }

        return valueFound ? index - 1 : -1;
    }

    public void InsertAt(int index, T value)
    {
        checkValidIndex(index);
        
        // loop through the array to the index
        // add the new node
        LinkedListNode<T> current = Head;
        bool nodeAdded = false;
        int pointer = 0;
        while (current != null && !nodeAdded)
        {
            // find the node 1 before the index
            if (pointer == index - 1)
            {
                // this is where we add the node
                LinkedListNode<T> allOtherNodes = current.Next;
                LinkedListNode<T> nodeToAdd = new LinkedListNode<T>(value);
                current.Next = nodeToAdd;
                current.Next.Next = allOtherNodes;
                NumberOfNodes++;
                nodeAdded = true;
            }

            current = current.Next;
            pointer++;
        }
    }
    public T RemoveAt(int index)
    {
        checkValidIndex(index);
        T value = default(T);
        // loop through the nodes
        // find the node 1 before the index
        int pointer = 0;
        LinkedListNode<T> current = Head;
        while (current != null && value.Equals(default(T)))
        {
            if (pointer == index - 1)
            {
                // node to remove is current.Next
                if (current.Next != null)
                {
                    value = current.Next.Value;
                    LinkedListNode<T> allRemainingNodes = current.Next.Next;
                    current.Next = allRemainingNodes;
                    NumberOfNodes--;
                }
            }

            pointer++;
            current = current.Next;
        }

        return value;
    }

    private LinkedListNode<T> getLastNode()
    {
        LinkedListNode<T> current = Head;
        LinkedListNode<T> prev = null;
        // loop through the nodes
        // at the end the prev node will be the last node in the list
        while (current != null)
        {
            prev = current;
            current = current.Next;
        }

        return prev;
    }
    private void checkValidIndex(int index)
    {
        if (index < 0 || index > NumberOfNodes)
        {
            // invalid index
            throw new IndexOutOfRangeException();
        }
    }
}