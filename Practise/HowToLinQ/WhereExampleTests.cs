using HowToLinQ.Models;

namespace HowToLinQ;

public class WhereExampleTests : BaseTests
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
}
