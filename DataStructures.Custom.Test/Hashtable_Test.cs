namespace DataStructures.Custom.Test;

public class Hashtable_Test
{
    private readonly Hashtable<int> hashtable;

    public Hashtable_Test()
    {
        this.hashtable = new Hashtable<int>();
    }

    [Fact]
    public void CanHashObjects()
    {
        hashtable.Insert(1, 10);
        hashtable.Insert(2, 20);
        hashtable.Insert(3, 30);
        hashtable.Insert(4, 40);

        Assert.Equal(4, hashtable.Count);
    }
    [Fact]
    public void CanRetrieveObjects()
    {
        CanHashObjects();

        int result = hashtable.Get(2);
        Assert.Equal(20, result);
    }
    [Fact]
    public void CanRetrieveObjects2()
    {
        CanHashObjects();

        int result = hashtable.Get(1);
        Assert.Equal(10, result);
    }
    [Fact]
    public void CanCheckForObjects()
    {
        CanHashObjects();

        int result = hashtable.Get(1);
        bool contains = hashtable.Contains(4, 40);
        Assert.Equal(10, result);
        Assert.True(contains);

        bool notContains = hashtable.Contains(5, 40);
        Assert.False(notContains);
    }
}