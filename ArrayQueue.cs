public class ArrayQueue
{

    private int[] _items;

    private int _rearIndex = -1;
    private int _frontIndex = 0;

    public ArrayQueue(int arraySize)
    {
        _items = new int[arraySize];
    }

    public void Enqueue(int value)
    {
        if ((_rearIndex + 1) > _items.Length - 1)
            throw new System.Exception("Queue is full");

        _rearIndex++;

        _items[_rearIndex] = value;

    }

    public int Dequeue()
    {
        if (isEmpty())
            throw new System.Exception("The queue is empty");

        int rValue = _items[0];

        int[] newArray = new int[_items.Length];
        for (var i = 1; i <= _rearIndex; i++)
        {
            //System.Console.WriteLine($" {i} {_items[i]}");
            newArray[i - 1] = _items[i];
        }
        _items = newArray;
        _rearIndex--;

        return rValue;

    }

    public int Peek()
    {
        if (isEmpty())
            throw new System.Exception("Queue is empty");
        return _items[0];
    }

    public bool isEmpty()
    {
        return (_rearIndex == -1);
    }

    public bool isFull()
    {
        return (_rearIndex == _items.Length - 1);
    }

    public override string ToString()
    {
        return string.Join(",", _items);
    }

}