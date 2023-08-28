namespace DataStructures.Custom.Test;

public class DoubleLinkedList_Test
{
    private readonly DoubleLinkedList<int> DoubleLinkedList;

    public DoubleLinkedList_Test()
    {
        this.DoubleLinkedList = new DoubleLinkedList<int>(new int[] {2, 4, 3, 6});
    }

    [Fact]
    public void CanSeedFromArray()
    {
        Assert.Equal(2, DoubleLinkedList.GetFirst());
        Assert.Equal(4, DoubleLinkedList.Count);
    }
    [Fact]
    public void CanAddFirst()
    {
        DoubleLinkedList.AddFirst(10);

        Assert.Equal(10, DoubleLinkedList.GetFirst());
        Assert.Equal(5, DoubleLinkedList.Count);
    }
    [Fact]
    public void CanAddLast()
    {
        DoubleLinkedList.AddLast(10);

        Assert.Equal(2, DoubleLinkedList.GetFirst());
        Assert.Equal(10, DoubleLinkedList.GetLast());
        Assert.Equal(5, DoubleLinkedList.Count);
    }
    [Fact]
    public void CanRemoveFirst()
    {
        int result = DoubleLinkedList.RemoveFirst();

        Assert.Equal(2, result);
        Assert.Equal(3, DoubleLinkedList.Count);
        Assert.Equal(4, DoubleLinkedList.GetFirst());
    }
    [Fact]
    public void CanRemoveLast()
    {
        int result = DoubleLinkedList.RemoveLast();

        Assert.Equal(6, result);
        Assert.Equal(3, DoubleLinkedList.Count);
        Assert.Equal(3, DoubleLinkedList.GetLast());
    }
    [Fact]
    public void RemoveFromEmptyThrowsException()
    {
        DoubleLinkedList<int> emptyList = new DoubleLinkedList<int>();
        Assert.ThrowsAny<Exception>(() => emptyList.RemoveFirst());
        Assert.ThrowsAny<Exception>(() => emptyList.RemoveLast());
    }
    [Fact]
    public void CanFindIndex()
    {
        int result = DoubleLinkedList.GetIndexOf(3);

        Assert.Equal(2, result);
    }
    [Fact]
    public void CanInsertAtIndex()
    {
        DoubleLinkedList.InsertAt(2, 10);

        Assert.Equal(5, DoubleLinkedList.Count);
        Assert.Equal(2, DoubleLinkedList.GetIndexOf(10));
    }
    [Fact]
    public void CanRemoveAtIndex()
    {
        // 2, 4, 3, 6
        int result = DoubleLinkedList.RemoveAt(3);

        Assert.Equal(6, result);
        Assert.Equal(3, DoubleLinkedList.Count);
    }
    [Fact]
    public void CanSupportMultipleOperations()
    {
        // 2, 4, 3, 6
        int result = DoubleLinkedList.RemoveAt(3);
        // 2, 4, 3
        DoubleLinkedList.AddLast(10);
        // 2, 4, 3, 10
        DoubleLinkedList.AddFirst(99);
        // 99, 2, 4, 3, 10
        DoubleLinkedList.InsertAt(2, 101);
        // 99, 2, 101, 4, 3, 10

        Assert.Equal(6, DoubleLinkedList.Count);

        Assert.Equal(0, DoubleLinkedList.GetIndexOf(99));
        Assert.Equal(1, DoubleLinkedList.GetIndexOf(2));
        Assert.Equal(2, DoubleLinkedList.GetIndexOf(101));
        Assert.Equal(3, DoubleLinkedList.GetIndexOf(4));
        Assert.Equal(4, DoubleLinkedList.GetIndexOf(3));
        Assert.Equal(5, DoubleLinkedList.GetIndexOf(10));
    }

    [Fact]
    public void ThrowsIndexOutOfRange()
    {
        Assert.Throws<IndexOutOfRangeException>(() => DoubleLinkedList.RemoveAt(-100));

        Assert.Throws<IndexOutOfRangeException>(() => DoubleLinkedList.InsertAt(-1, 10));

    }

    [Fact]
    public void ReturnsNegativeForIndexNotFound()
    {
        List<int[]> l = new List<int[]>();
        int indexNotFound = DoubleLinkedList.GetIndexOf(-100);
        Assert.Equal(-1, indexNotFound);
    }
}