using HowToLinQ.Models;

namespace HowToLinQ;

public class FilteringExampleTests : BaseTests
{
    [Test]
    public void Where_FiltersBasedOnPredicate()
    {
        // Example 1: Numbers greater than 5
        var result1 = Numbers.Where(n => n > 5).ToList();
        Assert.That(result1, Is.EquivalentTo(new[] { 6, 7, 8, 9, 10 }));

        // Example 2: People older than 25
        var result2 = People.Where(p => p.Age > 25).ToList();

        Assert.That(result2, Has.Count.EqualTo(2));
        Assert.That(result2, Has.All.Matches<Person>(p => p.Age > 25));

        // Example 3: Words with length greater than 5
        var result3 = Words.Where(w => w.Length > 5).ToList();
        Assert.That(result3, Is.EquivalentTo(new[] { "banana", "cherry", "elderberry" }));
    }

    [Test]
    public void OfType_FiltersBasedOnType()
    {
        var mixedList = new List<object> { "hello", 1, 2.5, "world", 3, new Person { Name = "Test" } };

        // Example 1: Filter strings
        var strings = mixedList.OfType<string>().ToList();
        Assert.That(strings, Is.EquivalentTo(new[] { "hello", "world" }));

        // Example 2: Filter integers
        var integers = mixedList.OfType<int>().ToList();
        Assert.That(integers, Is.EquivalentTo(new[] { 1, 3 }));

        // Example 3: Filter People
        var people = mixedList.OfType<Person>().ToList();
        Assert.That(people, Has.Count.EqualTo(1));
        Assert.That(people.First().Name, Is.EqualTo("Test"));
    }
}
