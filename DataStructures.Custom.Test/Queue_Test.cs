namespace DataStructures.Custom.Test;

public class Queue_Test
{
    private readonly Queue myQueue;

    public Queue_Test()
    {
        this.myQueue = new Queue();
    }

    [Fact]
    public void MyQueue_CanEnqueue()
    {
        myQueue.Enqueue(1);

        Assert.Equal(1, myQueue.Length);
    }

    [Fact]
    public void MyQueue_CanDequeue()
    {
        myQueue.Enqueue(1);
        Assert.Equal(1, myQueue.Length);

        int result = myQueue.Dequeue();

        Assert.Equal(1, result);
        Assert.Equal(0, myQueue.Length);
    }

    [Fact]
    public void MyQueue_CanPeek()
    {
        myQueue.Enqueue(1);
        Assert.Equal(1, myQueue.Length);

        int result = myQueue.Peek();
        Assert.Equal(1, myQueue.Length);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MyQueue_CanCheckEmpty()
    {
        bool result = myQueue.IsEmpty();
        Assert.True(result);
        Assert.Equal(0, myQueue.Length);

        myQueue.Enqueue(1);
        result = myQueue.IsEmpty();
        Assert.False(result);
    }

    [Fact]
    public void MyQueue_FirstInFirstOut()
    {
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);
        myQueue.Enqueue(4);
        myQueue.Enqueue(5);

        int firstItem = myQueue.Dequeue(),
            secondItem = myQueue.Dequeue(),
            thirdItem = myQueue.Dequeue(),
            fourthItem = myQueue.Dequeue(),
            fifthItem = myQueue.Dequeue();

        Assert.Equal(5, fifthItem);
        Assert.Equal(4, fourthItem);
        Assert.Equal(3, thirdItem);
        Assert.Equal(2, secondItem);
        Assert.Equal(1, firstItem);
    }

    [Fact]
    public void MyQueue_CanResize()
    {
        Random rng = new Random(0);

        for (int i = 0; i < 101; i++)
        {
            myQueue.Enqueue(rng.Next(int.MinValue, int.MaxValue));
        }

        Assert.Equal(101, myQueue.Length);
    }

    [Fact]
    public void MyQueue_CanHandleLargeNumberOfValues()
    {
        Random rng = new Random(0);

        double loops = Math.Pow(2, 11);

        for (int i = 0; i < loops; i++)
        {
            myQueue.Enqueue(rng.Next(int.MinValue, int.MaxValue));
        }

        Assert.Equal(loops, myQueue.Length);
    }
    
    [Fact]
    public void MyQueue_CanAvoidResize()
    {
        Random rng = new Random(0);

        for (int i = 0; i < 101; i++)
        {
            myQueue.Enqueue(rng.Next(int.MinValue, int.MaxValue));
            if (i % 2 > 0)
            {
                myQueue.Dequeue();
            }
        }

        Assert.Equal(51, myQueue.Length);
    }
}