using System.Collections.Generic;

public class PriorityQueue
{

    private Queue<int> queue = new Queue<int>();
    public void Enqueue(int value)
    {
        Queue<int> tempQ = new Queue<int>();
        if (queue.Count == 0)
        {
            tempQ.Enqueue(value);
        }
        else
        {
            var valueAdded = false;
            while (queue.Count > 0)
            {
                var qValue = queue.Dequeue();
                if (!valueAdded && value < qValue)
                {
                    tempQ.Enqueue(value);
                    valueAdded = true;
                }
                tempQ.Enqueue(qValue);
            }
            if (!valueAdded)
                tempQ.Enqueue(value);
        }

        queue.Clear();
        while (tempQ.Count > 0)
            queue.Enqueue(tempQ.Dequeue());

    }

    public int Dequeue()
    {
        if (queue.Count == 0)
            throw new System.Exception("The queue is empty");

        return queue.Dequeue();
    }
    public int Count()
    {
        return queue.Count;
    }

}