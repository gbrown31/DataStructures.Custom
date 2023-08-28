namespace DataStructures.Custom.Test;

public class ArrayList_Test
{
    private readonly ArrayList<int> arrayList;

    public ArrayList_Test()
    {
        this.arrayList = new ArrayList<int>();
    }
    [Fact]
    public void ArrayList_CanAdd()
    {
        arrayList.Add(1);

        Assert.Equal(1, arrayList.Count);
    }

    [Fact]
    public void ArrayList_CanRemove()
    {
        arrayList.Add(1);
        Assert.Equal(1, arrayList.Count);

        bool result = arrayList.Remove(1);

        Assert.True(result);
        Assert.Equal(0, arrayList.Count);
    }

    [Fact]
    public void ArrayList_CanCheckEmpty()
    {
        bool result = arrayList.Count == 0;
        Assert.True(result);
        Assert.Equal(0, arrayList.Count);

        arrayList.Add(1);
        result = arrayList.Count == 0;
        Assert.False(result);
    }

    [Fact]
    public void ArrayList_MultipleAddRemove()
    {
        arrayList.Add(1);
        arrayList.Add(2);
        arrayList.Add(3);
        arrayList.Add(4);
        arrayList.Add(5);

        bool firstItem = arrayList.Remove(1),
            secondItem = arrayList.Remove(2),
            thirdItem = arrayList.Remove(3),
            fourthItem = arrayList.Remove(4),
            fifthItem = arrayList.Remove(5);

        Assert.True(fifthItem);
        Assert.True(fourthItem);
        Assert.True(thirdItem);
        Assert.True(secondItem);
        Assert.True(firstItem);
    }

    [Fact]
    public void ArrayList_CanResize()
    {
        Random rng = new Random(0);

        for (int i = 0; i < 101; i++)
        {
            arrayList.Add(rng.Next(int.MinValue, int.MaxValue));
        }

        Assert.Equal(101, arrayList.Count);
    }

    [Fact]
    public void ArrayList_CanHandleLargeNumberOfValues()
    {
        Random rng = new Random(0);

        double loops = Math.Pow(2, 11);

        for (int i = 0; i < loops; i++)
        {
            arrayList.Add(rng.Next(int.MinValue, int.MaxValue));
        }

        Assert.Equal(loops, arrayList.Count);
    }
    
    [Fact]
    public void ArrayList_CanAvoidResize()
    {
        Random rng = new Random(0);

        for (int i = 0; i < 101; i++)
        {
            int rn = rng.Next(int.MinValue, int.MaxValue);
            arrayList.Add(rn);
            if (i % 2 > 0)
            {
                arrayList.Remove(rn);
            }
        }

        Assert.Equal(51, arrayList.Count);
    }
}