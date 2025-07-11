using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Dequeue returns items in order of highest priority (higher number = higher priority)
    // Defect(s) Found: None
    public void TestPriorityQueue_HighestPriorityDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same priority
    // Expected Result: Items with same priority are dequeued in FIFO order
    // Defect(s) Found: None
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 7);
        pq.Enqueue("B", 7);
        pq.Enqueue("C", 7);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyDequeueThrows()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            pq.Dequeue();
        });
    }

    [TestMethod]
    // Scenario: Mix of items with different and same priorities
    // Expected Result: Highest priority comes first, ties broken by order of arrival
    // Defect(s) Found: None
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 2);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5);
        pq.Enqueue("W", 3);

        Assert.AreEqual("Y", pq.Dequeue()); // Highest priority, came before Z
        Assert.AreEqual("Z", pq.Dequeue()); // Same priority as Y, next in line
        Assert.AreEqual("W", pq.Dequeue()); // Priority 3
        Assert.AreEqual("X", pq.Dequeue()); // Lowest
    }
}
