namespace HowToLinQ;

public class ConversionExampleTests : BaseTests
{
    [Test]
    public void ToArray_ConvertsSequenceToArray()
    {
        // Example 1: Convert numbers to array
        var numberArray = Numbers.ToArray();
        Assert.That(numberArray, Is.InstanceOf<int[]>());
        Assert.That(numberArray, Is.EqualTo(Numbers));

        // Example 2: Convert filtered people to array
        var newYorkersArray = People.Where(p => p.City == "New York").ToArray();
        Assert.That(newYorkersArray, Has.Length.EqualTo(2));
        Assert.That(newYorkersArray[0].Name, Is.EqualTo("Alice"));
    }

    [Test]
    public void ToList_ConvertsSequenceToList()
    {
        // Example 1: Convert numbers (which is already a list, but for demo)
        var numberList = Numbers.Select(n => n * 2).ToList(); // Create a new sequence first
        Assert.That(numberList, Is.InstanceOf<List<int>>());
        Assert.That(numberList, Is.EqualTo(new[] { 2, 4, 6, 8, 10, 10, 12, 14, 16, 18, 20 }));

        // Example 2: Convert an array to a list
        string[] wordArray = { "one", "two" };
        var wordList = wordArray.ToList();
        Assert.That(wordList, Is.InstanceOf<List<string>>());
        Assert.That(wordList, Is.EqualTo(wordArray));
    }

    [Test]
    public void ToDictionary_ConvertsSequenceToDictionary()
    {
        // Example 1: People to dictionary by Name
        var peopleDictByName = People.ToDictionary(p => p.Name);
        Assert.That(peopleDictByName, Has.Count.EqualTo(5));
        Assert.That(peopleDictByName["Alice"].Age, Is.EqualTo(30));

        // Example 2: People to dictionary by Name, storing Age as value
        var peopleAgeDict = People.ToDictionary(p => p.Name, p => p.Age);
        Assert.That(peopleAgeDict["Bob"], Is.EqualTo(25));

        // Example 3: Throws if duplicate key
        // Numbers has duplicate 5. Creating a dictionary with number as key will fail.
        var uniqueNumbersForDict = Numbers.Distinct().ToList(); // {1,2,3,4,5,6,7,8,9,10}
        var numDict = uniqueNumbersForDict.ToDictionary(n => n, n => $"Value_{n}");
        Assert.That(numDict[5], Is.EqualTo("Value_5"));
        Assert.Throws<ArgumentException>(() => Numbers.ToDictionary(n => n)); // Duplicate key '5'
    }

    [Test]
    public void ToLookup_ConvertsSequenceToLookup()
    {
        // Example 1: Group people by City into a Lookup
        var peopleLookupByCity = People.ToLookup(p => p.City);
        Assert.That(peopleLookupByCity["New York"].Count(), Is.EqualTo(2));
        Assert.That(peopleLookupByCity["London"].Count(), Is.EqualTo(2));
        Assert.That(peopleLookupByCity["Paris"].Count(), Is.EqualTo(1));
        Assert.That(peopleLookupByCity["Berlin"].Any(), Is.False); // Returns empty sequence for non-existent key

        // Example 2: Group numbers by even/odd
        var numbersLookup = Numbers.ToLookup(n => n % 2 == 0 ? "Even" : "Odd");
        Assert.That(numbersLookup["Even"], Is.EquivalentTo(new[] { 2, 4, 6, 8, 10 }));
        Assert.That(numbersLookup["Odd"], Is.EquivalentTo(new[] { 1, 3, 5, 5, 7, 9 }));

        // Example 3: Lookup with element selector
        var cityToNamesLookup = People.ToLookup(p => p.City, p => p.Name);
        Assert.That(cityToNamesLookup["New York"], Is.EquivalentTo(new[] { "Alice", "David" }));
    }

    [Test]
    public void Cast_CastsElementsToSpecifiedType()
    {
        var objectList = new List<object> { "apple", "banana", "cherry" };

        // Example 1: Cast object list to IEnumerable<string>
        var stringEnumerable = objectList.Cast<string>().ToList();
        Assert.That(stringEnumerable, Is.EquivalentTo(new[] { "apple", "banana", "cherry" }));

        // Example 2: Cast with mixed types (will throw)
        var mixedObjectList = new List<object> { "hello", 123, "world" };
        Assert.Throws<InvalidCastException>(() => mixedObjectList.Cast<string>().ToList());

        // Example 3: Cast from ArrayList (non-generic)
        System.Collections.ArrayList arrayList = new System.Collections.ArrayList { 1, 2, 3 };
        var intListFromArrayList = arrayList.Cast<int>().ToList();
        Assert.That(intListFromArrayList, Is.EquivalentTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void AsEnumerable_ReturnsTypedAsIEnumerable()
    {
        // Example 1: Treat List as IEnumerable (often implicit, but can be explicit)
        IEnumerable<int> numEnumerable = Numbers.AsEnumerable();
        Assert.That(numEnumerable, Has.Count.EqualTo(11));

        // Example 2: Useful for choosing between extension methods if ambiguous
        // (e.g., if a custom collection implemented its own 'Where' differently)
        var filtered = Numbers.AsEnumerable().Where(n => n > 5).ToList();
        Assert.That(filtered, Is.EquivalentTo(new[] { 6, 7, 8, 9, 10 }));

        // Example 3: Works on arrays
        int[] numArray = { 1, 2, 3 };
        IEnumerable<int> arrayAsEnum = numArray.AsEnumerable();
        Assert.That(arrayAsEnum.First(x => x == 3), Is.EqualTo(3));
    }
}
