using System;
using System.Collections.Generic;

public class HashTable
{

    private class Entry
    {
        public int Key { get; private set; }
        public string Value { get; set; }
        public Entry(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    private readonly LinkedList<Entry>[] _entries;

    public HashTable(int tableSize)
    {
        _entries = new LinkedList<Entry>[tableSize];
    }

    public void Put(int key, string value)
    {
        // If the key alredy exists, update the value
        var currentEntry = GetEntry(key);
        if (currentEntry != null)
        {
            currentEntry.Value = value;
            return;
        }

        var index = GetHashIndex(key);
        if (_entries[index] == null)
            _entries[index] = new LinkedList<Entry>();

        _entries[index].AddLast(new Entry(key, value));

    }

    private Entry GetEntry(int key)
    {
        var bucket = GetBucket(key);
        if (bucket != null)
            foreach (var entry in bucket)
                if (entry.Key == key)
                    return entry;

        return null;
    }

    private LinkedList<Entry> GetBucket(int key)
    {
        return _entries[GetHashIndex(key)];
    }

    public string Get(int key)
    {
        var entry = GetEntry(key);
        if (entry != null)
            return entry.Value;

        return null;

    }

    public void Delete(int key)
    {
        var bucket = GetBucket(key);
        var entry = GetEntry(key);
        if (entry != null)
            bucket.Remove(entry);

    }

    private int GetHashIndex(int key)
    {
        return key % _entries.Length;
    }
}