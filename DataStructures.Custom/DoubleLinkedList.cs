namespace DataStructures.Custom;

public class DoubleLinkedList<T> : IMyList<T>
    where T : IEquatable<T>
{
    private int _numberOfNodes = 0;
    public int Count => _numberOfNodes;
    private DoubleLinkedListNode<T> Head { get; set; }
    private DoubleLinkedListNode<T> Tail { get; set; }

    public DoubleLinkedList() { }
    public DoubleLinkedList(T[] data)
    {
        if (data.Length == 1)
        {
            Head = new DoubleLinkedListNode<T>(data[0]);
            // 1 node so tail is equal to head
            Tail = Head;
            _numberOfNodes++;
        }
        else
        {
            // 2,4,3,6
            Head = new DoubleLinkedListNode<T>(data[0]);
            _numberOfNodes++;
            
            DoubleLinkedListNode<T> current = Head;
            DoubleLinkedListNode<T> prev = null;
            for (int i = 1; i < data.Length; i++)
            {
                current.Next = new DoubleLinkedListNode<T>(data[i]);
                current.Prev = prev;
                
                prev = current;
                current = current.Next;

                Tail = current;
                _numberOfNodes++;
            }
            // at the end of the loop the current prev node will be null
            current.Prev = prev;
        }
    }

    public void AddFirst(T value)
    {
        DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);
        if (Head == null)
        {
            Head = node;
            Tail = Head;
        }
        else
        {
            DoubleLinkedListNode<T> allOtherNodes = Head;
            node.Next = allOtherNodes;
            allOtherNodes.Prev = node;
            
            Head = node;
        }

        _numberOfNodes++;
    }

    public void AddLast(T value)
    {
        DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);
        if (Head == null)
        {
            Head = node;
            Tail = Head;
        }
        else
        {
            DoubleLinkedListNode<T> prev = getLastNode();
            prev.Next = node;
            node.Prev = prev;
            
            // update tail to be latest node
            Tail = node;
        }

        _numberOfNodes++;
    }

    public T RemoveFirst()
    {
        T currentHeadValue = Head.Value;
        if (_numberOfNodes == 1)
        {
            Clear();
        }
        else
        {

            DoubleLinkedListNode<T> allOtherNodes = Head.Next;
            Head = allOtherNodes;
            _numberOfNodes--;
        }

        return currentHeadValue;
    }

    public T RemoveLast()
    {
        T oldTailValue = Tail.Value;
        if (_numberOfNodes == 1)
        {
            Clear();
        }
        else
        {
            DoubleLinkedListNode<T> secondLast = Tail.Prev;
            secondLast.Next = null;
            _numberOfNodes--;

            Tail = secondLast;
        }

        return oldTailValue;
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
        return getIndexOfTwoPointers(value);
    }

    public void InsertAt(int index, T value)
    {
        checkValidIndex(index);
        if (index == 0)
        {
            AddFirst(value);
        }
        else if (index == _numberOfNodes - 1)
        {
            AddLast(value);
        }
        else
        {
            // loop through the array to the index
            // add the new node
            DoubleLinkedListNode<T> current = Head;
            bool nodeAdded = false;
            int pointer = 0;
            while (current != null && !nodeAdded)
            {
                // find the node 1 before the index
                if (pointer == index - 1)
                {
                    DoubleLinkedListNode<T> nodeToAdd = new DoubleLinkedListNode<T>(value);
                    
                    // this is where we add the node
                    DoubleLinkedListNode<T> allOtherNodes = current.Next;
                    
                    // set the previous node of the remaining nodes to be the new node
                    allOtherNodes.Prev = nodeToAdd;
                    
                    // add the new node
                    current.Next = nodeToAdd;
                    // add the rest of the nodes
                    current.Next.Next = allOtherNodes;
                    
                    // maintain double link
                    current.Next.Prev = current;

                    _numberOfNodes++;
                    nodeAdded = true;
                }
                current = current.Next;
                pointer++;
            }
        }
    }
    public T RemoveAt(int index)
    {
        checkValidIndex(index);
        if (index == 0)
        {
            return RemoveFirst();
        }
        else if (index == _numberOfNodes - 1)
        {
            return RemoveLast();
        }
        else
        {
            T value = default(T);
            // loop through the nodes
            // find the node 1 before the index
            int pointer = 0;
            DoubleLinkedListNode<T> current = Head;
            while (current != null && value.Equals(default(T)))
            {
                if (pointer == index - 1)
                {
                    // node to remove is current.Next
                    if (current.Next != null)
                    {
                        value = current.Next.Value;
                        DoubleLinkedListNode<T> allRemainingNodes = current.Next.Next;
                        current.Next = allRemainingNodes;
                        
                        // set the prev to maintain double link
                        allRemainingNodes.Prev = current;
                        
                        _numberOfNodes--;
                    }
                }

                pointer++;
                current = current.Next;
            }

            return value;
        }
    }

    private void Clear()
    {
        Head = null;
        Tail = null;
        _numberOfNodes = 0;
    }
    private int getIndexOfTwoPointers(T value)
    {
        // can we iterate from the start and the end?
        DoubleLinkedListNode<T> start = Head,
            end = Tail;
        int startPointer = 0,
            endPointer = _numberOfNodes - 1;
        while (start != null && end != null)
        {
            if (value.Equals(start.Value))
            {
                return startPointer;
            }
            else if (value.Equals(end.Value))
            {
                return endPointer;
            }

            //update start and end to be next and prev
            start = start.Next;
            end = end.Prev;
            
            //update pointers
            startPointer++;
            endPointer--;
        }

        return -1;
    }
    private DoubleLinkedListNode<T> getLastNode()
    {
        return Tail;
    }
    private void checkValidIndex(int index)
    {
        if (index < 0 || index > _numberOfNodes)
        {
            // invalid index
            throw new IndexOutOfRangeException();
        }
    }
}