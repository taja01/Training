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
    }
}