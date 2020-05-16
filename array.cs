using System;
using System.Collections.Generic;

public class Array
{

    int[] _items;
    int _lastInsertedIndex = -1;

    public Array(int initialSize)
    {
        _items = new int[initialSize];
    }

    public void Insert(int number)
    {
        _lastInsertedIndex += 1;
        if (_lastInsertedIndex > _items.Length - 1)
        {
            int[] tempArray = new int[_items.Length + 1];
            for (int i = 0; i <= _items.Length - 1; i++)
                tempArray[i] = _items[i];
            _items = tempArray;
        }
        _items[_lastInsertedIndex] = number;
    }

    public void RemoveAt(int indexToRemove)
    {
        if (indexToRemove < 0 || indexToRemove > _items.Length - 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid index");
            return;
        }

        int[] newArray = new int[_items.Length - 1];
        for (int i = 0; i < indexToRemove; i++)
            newArray[i] = _items[i];

        int x = indexToRemove;
        for (int i = indexToRemove + 1; i <= _items.Length - 1; i++)
        {
            newArray[x] = _items[i];
            x += 1;
        }

        _items = newArray;
        _lastInsertedIndex--;

    }

    public int IndexOf(int numberToFind)
    {
        for (int i = 0; i < _items.Length; i++)
            if (_items[i] == numberToFind)
                return i;

        return -1;
    }
    public void Print()
    {
        foreach (var number in _items)
            Console.WriteLine(number);


    }
    public int Max()
    {
        int rValue = 0;
        foreach (var number in _items)
            if (number > rValue)
                rValue = number;

        return rValue;
    }

    public Array Intersect(Array compareArray)
    {
        List<int> values = new List<int>();

        foreach (var number in _items)
        {
            var intersectIndex = compareArray.IndexOf(number);
            if (intersectIndex > -1)
                values.Add(number);
        }

        Array rValue = new Array(values.Count);
        foreach (var number in values)
            rValue.Insert(number);

        return rValue;
    }

    public Array Reverse()
    {
        Array rValue = new Array(_items.Length);
        for (var i = _items.Length - 1; i >= 0; i--)
            rValue.Insert(_items[i]);
        return rValue;
    }

    public void InsertAt(int index, int number)
    {
        int[] newArray = new int[_items.Length + 1];
        int newArrayIndex = 0;
        for (int i = 0; i <= index; i++)
        {
            newArray[newArrayIndex] = _items[i];
            newArrayIndex++;
        }

        newArray[newArrayIndex] = number;
        newArrayIndex++;

        for (int i = index + 1; i < _items.Length; i++)
        {
            newArray[newArrayIndex] = _items[i];
            newArrayIndex++;
        }
        _items = newArray;

    }

}