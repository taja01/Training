using HowToLinQ.Models;

namespace HowToLinQ;

public class SpecialMethodsExampleTests : BaseTests
{
    [Test]
    public void DefaultIfEmpty_ReturnsDefaultValueIfSequenceIsEmpty()
    {
        // Example 1: Empty list of ints, provide default value 100
        var emptyInts = new List<int>();
        var resultInts = emptyInts.DefaultIfEmpty(100).ToList();
        Assert.That(resultInts, Is.EqualTo(new[] { 100 }));

        // Example 2: Empty list of strings, default is null (for string)
        // but DefaultIfEmpty without parameter uses default(T)
        var emptyStrings = new List<string>();
        var resultStrings1 = emptyStrings.DefaultIfEmpty().ToList(); // default(string) is null
        Assert.That(resultStrings1, Is.EqualTo(new string[] { null }));

        var resultStrings2 = emptyStrings.DefaultIfEmpty("N/A").ToList();
        Assert.That(resultStrings2, Is.EqualTo(new[] { "N/A" }));

        // Example 3: Non-empty list, DefaultIfEmpty has no effect
        var nonEmptyNumbers = new List<int> { 1, 2, 3 };
        var resultNonEmpty = nonEmptyNumbers.DefaultIfEmpty(99).ToList();
        Assert.That(resultNonEmpty, Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void SequenceEqual_ChecksIfTwoSequencesAreEqual()
    {
        var listA1 = new List<int> { 1, 2, 3 };
        var listA2 = new List<int> { 1, 2, 3 };
        var listB = new List<int> { 1, 2, 4 };
        var listC = new List<int> { 1, 2 };

        // Example 1: Equal sequences
        Assert.That(listA1.SequenceEqual(listA2));

        // Example 2: Different element value
        Assert.That(listA1.SequenceEqual(listB), Is.False);

        // Example 3: Different length
        Assert.That(listA1.SequenceEqual(listC), Is.False);
        Assert.That(listC.SequenceEqual(listA1), Is.False);

        // Example 4: With custom objects (uses default Equals or provided IEqualityComparer)
        var peopleSet1 = new List<Person> { new Person { Name = "X", Age = 1 }, new Person { Name = "Y", Age = 2 } };
        var peopleSet2 = new List<Person> { new Person { Name = "X", Age = 1 }, new Person { Name = "Y", Age = 2 } };
        var peopleSet3 = new List<Person> { new Person { Name = "X", Age = 1 }, new Person { Name = "Z", Age = 3 } };
        Assert.That(peopleSet1.SequenceEqual(peopleSet2)); // Relies on Person.Equals
        Assert.That(peopleSet1.SequenceEqual(peopleSet3), Is.False);
    }

    [Test]
    public void Zip_AppliesFunctionToCorrespondingElements() // .NET 4.0+
    {
        var numbers1 = new[] { 1, 2, 3 };
        var words1 = new[] { "one", "two", "three", "four" }; // words1 is longer

        // Example 1: Combine numbers and words
        var zipped1 = numbers1.Zip(words1, (num, word) => $"{num}: {word}").ToList();
        Assert.That(zipped1, Is.EqualTo(new[] { "1: one", "2: two", "3: three" })); // Stops at shortest sequence length

        var numbers2 = new[] { 10, 20, 30, 40 }; // numbers2 is longer
        var words2 = new[] { "ten", "twenty", "thirty" };

        // Example 2: Second sequence is shorter
        var zipped2 = numbers2.Zip(words2, (num, word) => $"{word} ({num})").ToList();
        Assert.That(zipped2, Is.EqualTo(new[] { "ten (10)", "twenty (20)", "thirty (30)" }));

        // Example 3: Zipping three sequences (using tuple for result, .NET 4.7.1+ or custom Zip for 3)
        // Standard Zip is for two. For three, you can chain or use .NET 6 Zip that takes 3.
        // This example shows standard two-sequence Zip.
        var listOne = new List<int> { 1, 2 };
        var listTwo = new List<string> { "A", "B" };
        var zippedThree = listOne.Zip(listTwo).ToList(); // .NET 6 Tuple Zip
        Assert.That(zippedThree[0], Is.EqualTo(new ValueTuple<int, string>(1, "A")));
        Assert.That(zippedThree[1], Is.EqualTo(new ValueTuple<int, string>(2, "B")));
    }

    // Append and Prepend (.NET Core 2.0+ / .NET Standard 2.1+)
    [Test]
    public void Append_AddsElementToEnd()
    {
        // Example 1: Append to numbers
        var appendedNumbers = Numbers.Append(100).ToList();
        Assert.That(appendedNumbers, Has.Count.EqualTo(12));
        Assert.That(appendedNumbers.Last(), Is.EqualTo(100));
        Assert.That(appendedNumbers, Is.EqualTo(Numbers.Concat(new[] { 100 })));

        // Example 2: Append to empty list
        var emptyList = Enumerable.Empty<string>();
        var appendedToEmpty = emptyList.Append("first").ToList();
        Assert.That(appendedToEmpty, Is.EqualTo(new[] { "first" }));

        // Example 3: Append person
        var newPerson = new Person { Name = "New", Age = 1 };
        var appendedPeople = People.Append(newPerson).ToList();
        Assert.That(appendedPeople.Count, Is.EqualTo(People.Count + 1));
        Assert.That(appendedPeople.Last(), Is.EqualTo(newPerson));
    }

    [Test]
    public void Prepend_AddsElementToBeginning()
    {
        // Example 1: Prepend to numbers
        var prependedNumbers = Numbers.Prepend(0).ToList();
        Assert.That(prependedNumbers, Has.Count.EqualTo(12));
        Assert.That(prependedNumbers.First(), Is.EqualTo(0));
        Assert.That(prependedNumbers, Is.EqualTo(new[] { 0 }.Concat(Numbers)));


        // Example 2: Prepend to empty list
        var emptyList = Enumerable.Empty<string>();
        var prependedToEmpty = emptyList.Prepend("first").ToList();
        Assert.That(prependedToEmpty, Is.EqualTo(new[] { "first" }));

        // Example 3: Prepend person
        var newPerson = new Person { Name = "Starter", Age = 99 };
        var prependedPeople = People.Prepend(newPerson).ToList();
        Assert.That(prependedPeople.Count, Is.EqualTo(People.Count + 1));
        Assert.That(prependedPeople.First(), Is.EqualTo(newPerson));
    }



    [Test]
    public void DistinctBy_WithCustomComparer_OrKeySelector() // .NET 6+ for built-in DistinctBy
    {
        var peopleWithSameName = new List<Person>
        {
            new Person { Name = "Alice", Age = 30, City = "New York" },
            new Person { Name = "Bob", Age = 25, City = "London" },
            new Person { Name = "Alice", Age = 35, City = "Paris" }, // Same name as first Alice
            new Person { Name = "Charlie", Age = 30, City = "Paris" }
        };

        // Example 1: Distinct people by name (using key selector)
        var distinctByName = peopleWithSameName.DistinctBy(p => p.Name).ToList();
        Assert.That(distinctByName, Has.Count.EqualTo(3)); // Alice (first one), Bob, Charlie
        Assert.That(distinctByName.Any(p => p.Name == "Alice" && p.Age == 30));
        Assert.That(distinctByName.Any(p => p.Name == "Alice" && p.Age == 35), Is.False);

        // Example 2: Distinct by Age
        var distinctByAge = peopleWithSameName.DistinctBy(p => p.Age).ToList();
        // Ages: 30, 25, 35. (Second 30 from Charlie is distinct from first 30 from Alice based on Age key)
        Assert.That(distinctByAge, Has.Count.EqualTo(3)); // Alice (30), Bob (25), Alice (35, different age) OR Charlie (30)
                                                          // Order matters for which element is picked.
                                                          // distinctByAge will be: Alice (30), Bob (25), Alice (35)

        // Example 3: Using the IEqualityComparer with Distinct (general case)
        // For this, our PersonNameComparer will make Distinct act like DistinctBy Name
        var distinctUsingComparer = peopleWithSameName.Distinct(new PersonNameComparer()).ToList();
        Assert.That(distinctUsingComparer, Has.Count.EqualTo(3));
        Assert.That(distinctUsingComparer.Any(p => p.Name == "Alice" && p.Age == 30)); // First Alice
    }
}
