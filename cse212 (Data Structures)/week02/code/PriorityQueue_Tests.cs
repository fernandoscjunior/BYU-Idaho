using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Can I add an item (data and priority) to the back of the queue?
    // Expected Result: Both items are added to the queue, returns the value of item2
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var item = new PriorityItem("test", 1);
        var item2 = new PriorityItem("test2", 2);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(item.Value, item.Priority);
        priorityQueue.Enqueue(item2.Value, item2.Priority);
        
        var result = priorityQueue.Dequeue();

        Assert.AreEqual(item2.Value, result);
        
    }

    [TestMethod]
    // Scenario: Does the dequeue function remove the item with highest priority
    // Expected Result: It should return the value of the highest priority dequeued item "test"/10
    // Defect(s) Found: For loop in dequeue was not iterating through all values. FIXED
    public void TestPriorityQueue_2()
    {
    
        var item = new PriorityItem("test", 10);
        var item2 = new PriorityItem("test2", 2);
        var item3 = new PriorityItem("test3", 3);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(item.Value, item.Priority);
        priorityQueue.Enqueue(item2.Value, item2.Priority);
        priorityQueue.Enqueue(item3.Value, item3.Priority);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(item.Value, result);
    }

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Expected Result: It should return the value of the dequeued item that had the highest priority and was closer to the front of the queue
    // Defect(s) Found: When comparing priority >= was considered, the = sign made the next same priority item to override the previous, making the closest to the queue's back to be removed. FIXED
    public void TestPriorityQueue_3()
    {
        var item = new PriorityItem("test", 1);
        var item2 = new PriorityItem("test2", 3);
        var item3 = new PriorityItem("test3", 3);
        var item4 = new PriorityItem("test4", 2);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(item.Value, item.Priority);
        priorityQueue.Enqueue(item2.Value, item2.Priority);
        priorityQueue.Enqueue(item3.Value, item3.Priority);
        priorityQueue.Enqueue(item4.Value, item4.Priority);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(item2.Value, result);
    }

    [TestMethod]
    // Scenario: If dequeue is called andthe queue is empty, then an error exception shall be thrown. This exception should be an InvalidOperationException with a message of "The queue is empty."
    // Expected Result: It should throw an error exception with the message the queue is empty when dequeue is called.
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }

    }
}