using HowToLinQ.Models;

namespace HowToLinQ;

public class QuantifiersExampleTests : BaseTests
{
    [Test]
    public void All_ChecksIfAllElementsSatisfyCondition()
    {
        // Example 1: Are all numbers positive?
        Assert.That(Numbers.All(n => n > 0));

        // Example 2: Are all people adults (age >= 18)?
        Assert.That(People.All(p => p.Age >= 18));

        // Example 3: Do all words have length at least 3?
        Assert.That(Words.All(w => w.Length >= 3));
        Assert.That(Words.All(w => w.Length > 4), Is.False);
    }

    [Test]
    public void Any_ChecksIfAnyElementSatisfiesCondition()
    {
        // Example 1: Is there any even number?
        Assert.That(Numbers.Any(n => n % 2 == 0));

        // Example 2: Is there any person named "Bob"?
        Assert.That(People.Any(p => p.Name == "Bob"));
        Assert.That(People.Any(p => p.Name == "Unknown"), Is.False);

        // Example 3: Is there any word longer than 8 characters?
        Assert.That(Words.Any(w => w.Length > 8));
    }

    [Test]
    public void Contains_ChecksIfSequenceContainsElement()
    {
        // Example 1: Does numbers list contain 5?
        Assert.That(Numbers.Contains(5));
        Assert.That(Numbers.Contains(100), Is.False);

        // Example 2: Does people list contain a specific person instance?
        // Note: Requires Person class to implement Equals and GetHashCode correctly.
        var alice = People.First(p => p.Name == "Alice");
        Assert.That(People.Contains(alice)); // We defined Equals for Person
        var nonExistentPerson = new Person { Name = "Zoe", Age = 40, City = "Test" };
        Assert.That(People.Contains(nonExistentPerson), Is.False);

        // Example 3: Does words list contain "cherry"?
        Assert.That(Words.Contains("cherry"));
    }
}
