using System.Collections.Generic;

public class QueueUsingStack
{

    // Queue
    // Dequeue

    private Stack<int> _stack1 = new Stack<int>();


    public void Enqueue(int value)
    {
        _stack1.Push(value);
    }

    public int Dequeue()
    {

        if (_stack1.Count == 0)
            throw new System.Exception("The queue is empty");

        Stack<int> tempStack = new Stack<int>();

        while (_stack1.Count > 0)
            tempStack.Push(_stack1.Pop());

        int rValue = tempStack.Pop();

        _stack1.Clear();
        while (tempStack.Count > 0)
            _stack1.Push(tempStack.Pop());

        return rValue;
        /*
                int[] array = _items.ToArray();
                int rValue = array[_items.Count - 1];
                _items.Clear();
                if (array.Length > 1)
                {
                    for (var i = array.Length - 2; i >= 0; i--)
                        _items.Push(array[i]);
                }

       
        return rValue; */
    }

    public override string ToString()
    {
        return string.Join(",", _stack1.ToArray());
    }

}