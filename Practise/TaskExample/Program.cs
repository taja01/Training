namespace TaskExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task t1 = Task.Run(() => PrintNumbers(1));
            Task t2 = Task.Run(() => PrintNumbers(2));

            await Task.WhenAll(t1, t2); // Wait for both tasks to complete

            // Use async/await to prevent deadlocks or blocking
            // Use await instead of .Wait() or .Result to avoid deadlocks.
            await DoWorkAsync();


            // Use Parallel class for handling large-scale data processing:
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"Processing {i}");
                Task.Delay(100).Wait(); // Simulate work
            });

            Console.WriteLine("Finished Processing");
            // Parallel.For efficiently distributes work across multiple threads.
        }

        static void PrintNumbers(int taskId)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task {taskId}, Number: {i}");
                Task.Delay(500).Wait(); // Simulate work
            }
        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine("Step 1");
            await Task.Delay(1000); // Simulates async I/O work
            Console.WriteLine("Step 2");
        }
    }
}
