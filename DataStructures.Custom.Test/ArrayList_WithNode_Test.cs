namespace DataStructures.Custom.Test;

public class ArrayList_WithNode_Test
{
    private readonly ArrayList<DoubleLinkedList<int>> collection;

    public ArrayList_WithNode_Test()
    {
        this.collection = new ArrayList<DoubleLinkedList<int>>();
    }

    [Fact]
    public void CanStoreMultipleNumbersAtIndex()
    {
        DoubleLinkedList<int> numbersToStore = new DoubleLinkedList<int>();
        numbersToStore.AddFirst(1);
        numbersToStore.AddLast(100);
        
        
        DoubleLinkedList<int> numbersToStore2 = new DoubleLinkedList<int>();
        numbersToStore.AddFirst(2);
        numbersToStore.AddLast(200);

        ArrayList<DoubleLinkedList<int>> array = new ArrayList<DoubleLinkedList<int>>();
        array.Add(numbersToStore);
        array.Add(numbersToStore2);

        Assert.True(array.Count == 2);
    }
}