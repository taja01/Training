using HowToLinQ.Models;

namespace HowToLinQ;

public class GenerationExampleTests : BaseTests
{
    [Test]
    public void Range_GeneratesSequenceOfIntegers()
    {
        // Example 1: Generate numbers from 1 to 5
        var range1to5 = Enumerable.Range(1, 5).ToList();
        Assert.That(range1to5, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5 }));

        // Example 2: Generate 3 numbers starting from 10
        var range10for3 = Enumerable.Range(10, 3).ToList();
        Assert.That(range10for3, Is.EqualTo(new[] { 10, 11, 12 }));


        // Example 3: Generate 0 numbers (count is 0)
        var emptyRange = Enumerable.Range(100, 0).ToList();
        Assert.That(emptyRange, Is.Empty);
    }

    [Test]
    public void Repeat_GeneratesSequenceWithOneRepeatedValue()
    {
        // Example 1: Repeat "hello" 3 times
        var repeatedHello = Enumerable.Repeat("hello", 3).ToList();
        Assert.That(repeatedHello, Is.EqualTo(new[] { "hello", "hello", "hello" }));

        // Example 2: Repeat number 7 five times
        var repeated7 = Enumerable.Repeat(7, 5).ToList();
        Assert.That(repeated7, Is.EqualTo(new[] { 7, 7, 7, 7, 7 }));

        // Example 3: Repeat an object (same instance)
        var personToRepeat = new Person { Name = "RepeatMe" };
        var repeatedPerson = Enumerable.Repeat(personToRepeat, 2).ToList();
        Assert.That(repeatedPerson, Has.Count.EqualTo(2));
        Assert.That(repeatedPerson[0], Is.EqualTo(personToRepeat));
        Assert.That(repeatedPerson[1], Is.EqualTo(personToRepeat));
    }

    [Test]
    public void Empty_ReturnsEmptySequence()
    {
        // Example 1: Empty sequence of integers
        var emptyInts = Enumerable.Empty<int>().ToList();
        Assert.That(emptyInts, Is.Empty);
        Assert.That(emptyInts, Has.Count.EqualTo(0));

        // Example 2: Empty sequence of strings
        var emptyStrings = Enumerable.Empty<string>().ToList();
        Assert.That(emptyStrings, Is.Empty);

        // Example 3: Use in methods expecting IEnumerable<T>
        var result = People.Concat(Enumerable.Empty<Person>()).ToList();
        Assert.That(result.Count, Is.EqualTo(People.Count));
    }

}
