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
    }
}
