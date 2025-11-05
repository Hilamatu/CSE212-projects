using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a Queue with the following items and priorities: Task 1 (2), Task 2 (2), Task 3 (3), Task 4 (4), Task 5(5).
    // Expected Result: [task1 , task2, task3, task4, task5]]
    // Defect(s) Found: 
    public void TestPriorityQueue_FIFO()
    {
        var priorityQueue = new PriorityQueue();
        var task1 = new PriorityItem("task 1", 2);
        var task2 = new PriorityItem("task 2", 2);
        var task3 = new PriorityItem("task 3", 3);
        var task4 = new PriorityItem("task 4", 4);
        var task5 = new PriorityItem("task 5", 5);

        priorityQueue.Enqueue(task1.Value, task1.Priority);
        priorityQueue.Enqueue(task2.Value, task2.Priority); 
        priorityQueue.Enqueue(task3.Value, task3.Priority);
        priorityQueue.Enqueue(task4.Value, task4.Priority);
        priorityQueue.Enqueue(task5.Value, task5.Priority);

        var expectedResult = "[task 1 (Pri:2), task 2 (Pri:2), task 3 (Pri:3), task 4 (Pri:4), task 5 (Pri:5)]";
        Assert.AreEqual(expectedResult, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Create a Queue with the following items and priorities: Task 1 (7), Task 2 (6), Task 3 (2), Task 4 (7), Task 5(7).
    // Expected Result: Task 2 is dequeued first.
    // Defect(s) Found: 
    // The loop condition in Dequeue method is incorrect, causing it to ignore the first item and miss the last item in the queue when searching for the highest priority.
    // The comparison is not ensuring FIFO for the same priority.
    //Item removal from the queue was missing after dequeuing.
    //Fixed the condition to start from index 0 and go to the end of the list by removing the -1 in the loop condition.
    // Changed the comparison operator from >= to > to ensure FIFO behavior for items with the same priority.
    // Added the line to remove the item.
    public void TestPriorityQueue_DequeueHighest()
    {
        var priorityQueue = new PriorityQueue();
        var task1 = new PriorityItem("task 1", 7);
        var task2 = new PriorityItem("task 2", 6);
        var task3 = new PriorityItem("task 3", 2);
        var task4 = new PriorityItem("task 4", 7);
        var task5 = new PriorityItem("task 5", 7);

        priorityQueue.Enqueue(task1.Value, task1.Priority);
        priorityQueue.Enqueue(task2.Value, task2.Priority); 
        priorityQueue.Enqueue(task3.Value, task3.Priority);
        priorityQueue.Enqueue(task4.Value, task4.Priority);
        priorityQueue.Enqueue(task5.Value, task5.Priority);

        var expectedResult = task1; // Task 1 should be dequeued first since it was added before Task 4 with the same highest priority.
        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual(expectedResult.Value, dequeuedItem);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty Priority Queue.
    // Expected Result: Throw InvalidOperationException with message "The queue is empty.".
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
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