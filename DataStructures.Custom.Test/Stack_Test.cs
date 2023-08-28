namespace DataStructures.Custom.Test;

public class Stack_Test
{
    private readonly Stack myStack;

    public Stack_Test()
    {
        this.myStack = new Stack();
    }

    [Fact]
    public void MyStack_CanPush()
    {
        myStack.Push(2);
        Assert.Equal(1, myStack.Length);
    }
    [Fact]
    public void MyStack_CanPop()
    {
        myStack.Push(2);
        int result = myStack.Pop();

        Assert.Equal(2, result);
        Assert.Equal(0, myStack.Length);
    }
    [Fact]
    public void MyStack_CanPeek()
    {
        myStack.Push(2);
        int result = myStack.Peek();

        Assert.Equal(2, result);
        Assert.Equal(1, myStack.Length);
    }
    [Fact]
    public void MyStack_CanHandleLargeNumberOfValues()
    {
        Random rng = new Random(0);

        for (int i = 0; i < 1000; i++)
        {
            myStack.Push(rng.Next(int.MinValue, int.MaxValue));
        }

        Assert.Equal(1000, myStack.Length);
    }
    [Fact]
    public void MyStack_CanResize()
    {
        Random rng = new Random(0);

        for (int i = 0; i < 101; i++)
        {
            myStack.Push(rng.Next(int.MinValue, int.MaxValue));
        }

        Assert.Equal(101, myStack.Length);
    }

    [Fact]
    public void MyStack_LastInFirstOut()
    {
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);

        int fifthItem = myStack.Pop(),
            fourthItem = myStack.Pop(),
            thirdItem = myStack.Pop(),
            secondItem = myStack.Pop(),
            firstItem = myStack.Pop();
        
        Assert.Equal(5, fifthItem);
        Assert.Equal(4, fourthItem);
        Assert.Equal(3, thirdItem);
        Assert.Equal(2, secondItem);
        Assert.Equal(1, firstItem);
    }

    [Fact]
    public void MyStack_EmptyPopException()
    {
        Assert.ThrowsAny<Exception>(() => myStack.Pop());
    }
    [Fact]
    public void MyStack_EmptyPeekException()
    {
        Assert.ThrowsAny<Exception>(() => myStack.Peek());
    }
}