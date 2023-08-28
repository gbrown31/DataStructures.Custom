namespace DataStructures.Custom.Test;

public class LinkedList_Test
{
    private readonly LinkedList<int> myLinkedList;

    public LinkedList_Test()
    {
        this.myLinkedList = new LinkedList<int>(new int[] {2, 4, 3, 6});
    }

    [Fact]
    public void CanSeedFromArray()
    {
        Assert.Equal(2, myLinkedList.GetFirst());
        Assert.Equal(4, myLinkedList.Count);
    }
    [Fact]
    public void CanAddFirst()
    {
        myLinkedList.AddFirst(10);

        Assert.Equal(10, myLinkedList.GetFirst());
        Assert.Equal(5, myLinkedList.Count);
    }
    [Fact]
    public void CanAddLast()
    {
        myLinkedList.AddLast(10);

        Assert.Equal(2, myLinkedList.GetFirst());
        Assert.Equal(10, myLinkedList.GetLast());
        Assert.Equal(5, myLinkedList.Count);
    }
    [Fact]
    public void CanRemoveFirst()
    {
        int result = myLinkedList.RemoveFirst();

        Assert.Equal(2, result);
        Assert.Equal(3, myLinkedList.Count);
        Assert.Equal(4, myLinkedList.GetFirst());
    }
    [Fact]
    public void CanRemoveLast()
    {
        int result = myLinkedList.RemoveLast();

        Assert.Equal(6, result);
        Assert.Equal(3, myLinkedList.Count);
        Assert.Equal(3, myLinkedList.GetLast());
    }
    [Fact]
    public void RemoveFromEmptyThrowsException()
    {
        LinkedList<int> emptyList = new LinkedList<int>();
        Assert.ThrowsAny<Exception>(() => emptyList.RemoveFirst());
        Assert.ThrowsAny<Exception>(() => emptyList.RemoveLast());
    }
    [Fact]
    public void CanFindIndex()
    {
        int result = myLinkedList.GetIndexOf(3);

        Assert.Equal(2, result);
    }
    [Fact]
    public void CanInsertAtIndex()
    {
        myLinkedList.InsertAt(2, 10);

        Assert.Equal(5, myLinkedList.Count);
        Assert.Equal(2, myLinkedList.GetIndexOf(10));
    }
    [Fact]
    public void CanRemoveAtIndex()
    {
        // 2, 4, 3, 6
        int result = myLinkedList.RemoveAt(3);

        Assert.Equal(6, result);
        Assert.Equal(3, myLinkedList.Count);
    }
    [Fact]
    public void CanSupportMultipleOperations()
    {
        // 2, 4, 3, 6
        int result = myLinkedList.RemoveAt(3);
        // 2, 4, 3
        myLinkedList.AddLast(10);
        // 2, 4, 3, 10
        myLinkedList.AddFirst(99);
        // 99, 2, 4, 3, 10
        myLinkedList.InsertAt(2, 101);
        // 99, 2, 101, 4, 3, 10

        Assert.Equal(6, myLinkedList.Count);

        Assert.Equal(0, myLinkedList.GetIndexOf(99));
        Assert.Equal(1, myLinkedList.GetIndexOf(2));
        Assert.Equal(2, myLinkedList.GetIndexOf(101));
        Assert.Equal(3, myLinkedList.GetIndexOf(4));
        Assert.Equal(4, myLinkedList.GetIndexOf(3));
        Assert.Equal(5, myLinkedList.GetIndexOf(10));
    }

    [Fact]
    public void ThrowsIndexOutOfRange()
    {
        Assert.Throws<IndexOutOfRangeException>(() => myLinkedList.RemoveAt(-100));

        Assert.Throws<IndexOutOfRangeException>(() => myLinkedList.InsertAt(-1, 10));

    }

    [Fact]
    public void ReturnsNegativeForIndexNotFound()
    {
        int indexNotFound = myLinkedList.GetIndexOf(-100);
        Assert.Equal(-1, indexNotFound);
    }
}