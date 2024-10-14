namespace Training.CodeWars.October
{
    public class Numbers
    {
        /// <summary>
        /// Task: https://www.codewars.com/kata/5641a03210e973055a00000d/train/csharp
        /// Each number should be formatted that it is rounded to two decimal places. You don't need to check whether the input is a valid number because only valid numbers are used in the tests.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double TwoDecimalPlaces(double number)
        {
            //return double.Round(number, 2, MidpointRounding.AwayFromZero);

            return Math.Round(number, 2);
        }
    }
}
