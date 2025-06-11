namespace ThreadSafety
{
    internal class Program
    {
        private static int Counter = 0;

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
            for (int i = 0; i < 1000; i++)
            {
                Counter++; // Race condition occurs here
            }
        }
    }
}
