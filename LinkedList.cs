using System;
using System.Collections.Generic;

public class LinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; }

    public int Count { get; set; }
    public void addFirst(int value)
    {
        var node = new Node() { Value = value };

        if (Head != null)
        {
            node.Next = Head;
            node.Previous = node;
        }
        else
            Tail = node;
        Head = node;

        Count++;

    }

    public void addLast(int value)
    {
        var node = new Node() { Value = value };
        if (Tail != null)
        {
            Tail.Next = node;
            node.Previous = Tail;
        }

        if (Head == null)
            Head = node;

        Tail = node;

        Count++;
    }

    public void deleteFirst()
    {
        if (Head == null)
            return;
        if (Head.Next != null)
        {
            Head = Head.Next;
            Head.Previous = null;
        }

        Count--;
    }

    public void deleteLast()
    {
        if (Head == null)
            return;

        // Get the tail previous node
        var previous = Tail.Previous;
        if (previous != null)
            previous.Next = null;

        Tail = previous;

        Count--;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public int indexOf(int value)
    {

        var index = 0;
        var currentNode = Head;
        while (currentNode != null)
        {
            if (currentNode.Value == value)
                return index;

            index++;
            currentNode = currentNode.Next;
        }

        return -1;

    }
    public bool Contains(int value)
    {
        return indexOf(value) > -1;
    }

    public int[] ToArray()
    {
        int index = 0;
        int[] rValue = new int[Count];
        Node currentNode = Head;
        while (currentNode != null)
        {
            rValue[index] = currentNode.Value;
            currentNode = currentNode.Next;
            index++;
        }

        return rValue;
    }

    public void Reverse()
    {

        var currentNode = Head;
        while (currentNode != null)
        {
            var nextNode = currentNode.Next;
            currentNode.Next = currentNode.Previous;
            currentNode.Previous = nextNode;

            currentNode = nextNode;
        }

        var newTail = Head;
        Head = Tail;
        Tail = newTail;

    }

    public int GetKthFromTheEnd(int Kth)
    {

        if (Kth > Count)
            throw new Exception("Kth out of range");

        var currentK = 0;
        var currentNode = Tail;
        var rValue = -1;
        while (currentNode != null)
        {
            rValue = currentNode.Value;
            currentNode = currentNode.Previous;
            currentK++;
            if (currentK == Kth)
                break;
        }

        return rValue;

    }

    public void Print()
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }

    }


    public class Node
    {
        public int Value;
        public Node Next;

        public Node Previous;

    }

}

