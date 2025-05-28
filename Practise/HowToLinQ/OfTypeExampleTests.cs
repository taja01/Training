using HowToLinQ.Models;

namespace HowToLinQ;

public class OfTypeExampleTests : BaseTests
{
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
