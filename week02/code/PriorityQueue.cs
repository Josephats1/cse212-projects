using System;
using System.Collections.Generic;

/// <summary>
/// A priority queue that returns items with higher priority first.
/// If multiple items share the same highest priority, they are dequeued in FIFO order.
/// </summary>
public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; }
        public int Priority { get; }

        public QueueItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    private readonly List<QueueItem> _items = new();

    /// <summary>
    /// Adds an item with the specified priority to the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _items.Add(new QueueItem(value, priority));
    }

    /// <summary>
    /// Removes and returns the value with the highest priority.
    /// If multiple items share the highest priority, the one that was enqueued first is returned.
    /// </summary>
    public string Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        int highestPriority = int.MinValue;
        int indexToRemove = -1;

        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Priority > highestPriority)
            {
                highestPriority = _items[i].Priority;
                indexToRemove = i;
            }
        }

        string value = _items[indexToRemove].Value;
        _items.RemoveAt(indexToRemove);
        return value;
    }
}
