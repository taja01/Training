namespace Training.CodeWars._2025.May
{
    public class Kata
    {
        //https://www.codewars.com/kata/56e2f59fb2ed128081001328/train/csharp
        /*
         * Input: Array of elements
         * ["h","o","l","a"]
         * 
         * Output: String with comma delimited elements of the array in th same order.
         * 
         * "h,o,l,a"
         * 
         * Note: if this seems too simple for you try the next level
         * Note2: the input data can be: boolean array, array of objects, array of string arrays, array of number arrays... 😕
         */
        public static string PrintArray(object[] array)
        {
            //var list = new List<string>();

            //foreach (var item in array)
            //{
            //    if (item is object[] nestedArray)
            //    {
            //        foreach (var nestedItem in nestedArray)
            //        {
            //            list.Add(nestedItem.ToString());
            //        }
            //    }
            //    else
            //    {
            //        list.Add(item.ToString());
            //    }
            //}

            //return string.Join(",", list);

            return string.Join(",", array.Select(x => x.GetType().IsArray ? string.Join(",", (object[])x) : x));
        }

        /*
         Given an array of integers.
        Return an array, where the first element is the count of positives numbers and the second element is sum of negative numbers. 0 is neither positive nor negative.
        If the input is an empty array or is null, return an empty array.*/
        public static int[] CountPositivesSumNegatives(int[] input)
        {
            return input?.Length > 0 ? [input.Count(x => x > 0), input.Where(x => x < 0).Sum()] : [];
        }

        /*
         * Given an integer (1 <= n <= 100) representing a person's age, return their minimum and maximum age range.
         * This equation doesn't work when the age <= 14, so if the age <= 14, use this equation instead:
         * 
         * min = age - 0.10 * age
         * max = age + 0.10 * age
         * You should floor all your answers so that an integer is given instead of a float (which doesn't represent age). Return your answer in the form "[min]-[max]"

            Examples:
            age = 27   =>   "20-40"
            age = 5    =>   "4-5"
            age = 17   =>   "15-20"
         */
        public static string DatingRange(int age)
        {
            var d = (double)age;
            var min = age > 14 ? Math.Floor((d / 2) + 7) : Math.Floor(d - 0.1 * d);
            var max = age > 14 ? Math.Floor(2 * (d - 7)) : Math.Floor(d + 0.1 * d);


            return $"{min}-{max}";
        }
    }
}