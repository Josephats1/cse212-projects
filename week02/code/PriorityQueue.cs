using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes the item with the highest priority from the queue.
    /// If multiple items share the highest priority, removes the one closest to the front.
    /// </summary>
    /// <returns>The value of the removed item</returns>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highPriorityIndex = 0;

        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
using System;
using System.Collections.Generic;

/// <summary>
/// PriorityQueue manages a queue where each item has a priority.
/// Higher priority numbers come out first. If two items have the same
/// priority, the one added first comes out first (FIFO for same priorities).
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
    /// Adds an item with a priority to the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _items.Add(new QueueItem(value, priority));
    }

    /// <summary>
    /// Removes and returns the value with the highest priority.
    /// Among equal priorities, returns the earliest inserted.
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

        var item = _items[indexToRemove];
        _items.RemoveAt(indexToRemove);
        return item.Value;
    }
}
