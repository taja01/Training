namespace PreventRaceCondition
{
    internal class Program
    {
        private static int Counter = 0;
        private static object LockObject = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(Increment);
            Thread t2 = new Thread(Increment);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Final Counter Value: {Counter}");
        }

        static void Increment()
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (LockObject) // Use the lock to synchronize threads
                {
                    Counter++;
                }
            }
        }
    }
}
