namespace Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintNumbers);
            thread.Start(); // Start the thread

            // Main thread continues to execute
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main Thread: {i}");
                Thread.Sleep(500); // Simulate some work
            }
        }

        static void PrintNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Background Thread: {i}");
                Thread.Sleep(1000); // Simulate some work
            }
        }
    }
}
