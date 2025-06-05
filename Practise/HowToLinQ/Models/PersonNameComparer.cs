namespace HowToLinQ.Models
{
    // --- Methods with IEqualityComparer ---
    // Many methods like Distinct, Union, Intersect, Except, Contains, ToDictionary, ToLookup, GroupBy, Join, GroupJoin
    // have overloads that accept an IEqualityComparer<T>.
    // Here's one example with DistinctBy (a more specific version, though Distinct itself also has comparer overloads).

    public class PersonNameComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            return obj?.Name?.GetHashCode() ?? 0;
        }
    }
}
