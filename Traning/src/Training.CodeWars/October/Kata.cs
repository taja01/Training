namespace Training.CodeWars.October
{
    public class Kata
    {
        /// <summary>
        /// https://www.codewars.com/kata/523b623152af8a30c6000027
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Grow(int[] x)
        {
            return x.Aggregate((a, b) => a * b);
        }

        /// <summary>
        /// https://www.codewars.com/kata/55cbc3586671f6aa070000fb/train/csharp
        /// </summary>
        /// <param name="num"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        public static bool CheckForFactor(int num, int factor)
        {
            return num % factor == 0;
        }

        /// <summary>
        /// https://www.codewars.com/kata/576b93db1129fcf2200001e6/train/csharp
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int Sum(int[] numbers)
        {
            return (numbers == null || numbers.Length < 2) ? 0 : numbers.OrderBy(x => x).Skip(1).SkipLast(1).Sum();



            /* 
             * TODO: write performance tests
              return numbers == null || numbers.Length < 2
                    ? 0
                    : numbers.Sum() - numbers.Max() - numbers.Min();
            */

        }
    }
}
