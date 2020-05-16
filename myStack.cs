public class MyStack
{
    private readonly LinkedList Items = new LinkedList();

    public void Push(int value)
    {
        Items.addFirst(value);
    }

    public int Pop()
    {
        if (Items.Head != null)
        {
            int rValue = Items.Head.Value;
            Items.deleteFirst();
            return rValue;
        }
        else
        {
            return 0;
        }
    }

    public int[] ToArray()
    {
        return Items.ToArray();
    }

    public string Print()
    {
        return string.Join(",", ToArray());
    }

    public int Count()
    {
        return Items.Count;
    }

}