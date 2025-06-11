using System.Collections.Concurrent;

namespace TaskExampleAdvanced
{
    internal class Program
    {
        static void Main()
        {
            // Create a blocking collection with a bounded capacity to limit the queue size
            var testQueue = new BlockingCollection<string>(boundedCapacity: 5);

            // Start the Producer thread (adds test cases to the queue)
            Task producer = Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"[Producer] Adding TestCase-{i} to queue...");
                    testQueue.Add($"TestCase-{i}");
                    Thread.Sleep(300); // Simulate test discovery delay
                }
                testQueue.CompleteAdding(); // Signal that no more items will be added
            });

            // Start the Consumer thread (processes and executes test cases)
            Task consumer = Task.Run(() =>
            {
                foreach (var testCase in testQueue.GetConsumingEnumerable()) // Waits safely for new items
                {
                    Console.WriteLine($"[Consumer] Executing {testCase}...");
                    Thread.Sleep(500); // Simulate test execution time
                    Console.WriteLine($"[Consumer] Completed {testCase}.");
                }
            });

            // Wait for both producer and consumer to finish
            Task.WaitAll(producer, consumer);

            Console.WriteLine("All tests processed.");

        }
    }
}

/* The program demonstrates the interaction between a Producer (adding tasks to the queue) and a Consumer (processing tasks from the queue). Here's what you can expect to happen when you run the example:
 * 
 * Behavior Overview:
 * The Producer generates some workload (e.g., test cases or tasks) and pushes them into the BlockingCollection. You’ll see logs like Producing: X.
 * 
 * The Consumer takes items from the BlockingCollection and processes them, printing Consuming: X.
 * 
 * If the BlockingCollection is full (bounded capacity is set), the Producer waits until space is available again.
 * 
 * Processing tasks happens concurrently but in a controlled, thread-safe manner.
 * 
 * When the Producer is done, it calls CompleteAdding(), signaling that no more items will be added to the queue.
 * 
 * The Consumer gracefully finishes processing remaining items and exits.
 */
