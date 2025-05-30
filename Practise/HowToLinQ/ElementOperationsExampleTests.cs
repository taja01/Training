using HowToLinQ.Models;

namespace HowToLinQ;

public class ElementOperationsExampleTests : BaseTests
{
    [Test]
    public void First_ReturnsFirstElementSatisfyingCondition()
    {
        // Example 1: First even number
        Assert.That(Numbers.First(n => n % 2 == 0), Is.EqualTo(2));

        // Example 2: First person from London
        var firstLondoner = People.First(p => p.City == "London");
        Assert.That(firstLondoner.Name, Is.EqualTo("Bob"));

        // Example 3: First without predicate
        Assert.That(Numbers.First(), Is.EqualTo(1));

        // Example 4: Throws if no element found
        Assert.Throws<InvalidOperationException>(() => Numbers.First(n => n > 100));
        Assert.Throws<InvalidOperationException>(() => new List<int>().First());
    }

    [Test]
    public void FirstOrDefault_ReturnsFirstOrDefaultForNoMatch()
    {
        // Example 1: First number greater than 100 (or default)
        Assert.That(Numbers.FirstOrDefault(n => n > 100), Is.EqualTo(0)); // Default for int is 0

        // Example 2: First person from "Berlin" (or default)
        var berlinPerson = People.FirstOrDefault(p => p.City == "Berlin");
        Assert.That(berlinPerson, Is.Null); // Default for reference type is null

        // Example 3: First of empty list
        Assert.That(new List<int>().FirstOrDefault(), Is.EqualTo(0));
        Assert.That(new List<string>().FirstOrDefault(), Is.Null);
    }

    [Test]
    public void Last_ReturnsLastElementSatisfyingCondition()
    {
        // Example 1: Last odd number
        Assert.That(Numbers.Last(n => n % 2 != 0), Is.EqualTo(9));

        // Example 2: Last person from New York
        var lastNewYorker = People.Last(p => p.City == "New York");
        Assert.That(lastNewYorker.Name, Is.EqualTo("David")); // Alice, David -> David is last

        // Example 3: Last without predicate
        Assert.That(Numbers.Last(), Is.EqualTo(10));

        // Example 4: Throws if no element found
        Assert.Throws<InvalidOperationException>(() => Numbers.Last(n => n < 0));
        Assert.Throws<InvalidOperationException>(() => new List<string>().Last());
    }

    [Test]
    public void LastOrDefault_ReturnsLastOrDefaultForNoMatch()
    {
        // Example 1: Last number less than 0 (or default)
        Assert.That(Numbers.LastOrDefault(n => n < 0), Is.EqualTo(0));

        // Example 2: Last person with age > 50 (or default)
        Assert.That(People.LastOrDefault(p => p.Age > 50), Is.Null);

        // Example 3: Last of empty list
        Assert.That(new List<int>().LastOrDefault(), Is.EqualTo(default(int))); // 0
        Assert.That(new List<Person>().LastOrDefault(), Is.Null);
    }

    [Test]
    public void Single_ReturnsSingleElementSatisfyingCondition()
    {
        // Example 1: Single number equal to 7
        Assert.That(Numbers.Single(n => n == 7), Is.EqualTo(7));

        // Example 2: Single person named "Charlie"
        var charlie = People.Single(p => p.Name == "Charlie");
        Assert.That(charlie.Age, Is.EqualTo(30));

        // Example 3: Throws if no element or more than one
        Assert.Throws<InvalidOperationException>(() => Numbers.Single(n => n == 100)); // None
        Assert.Throws<InvalidOperationException>(() => Numbers.Single(n => n == 5)); // Multiple (two 5s)
        Assert.Throws<InvalidOperationException>(() => People.Single(p => p.City == "London")); // Multiple
        Assert.Throws<InvalidOperationException>(() => new List<int>().Single());
    }

    [Test]
    public void SingleOrDefault_ReturnsSingleOrDefaultForNoOrMultipleMatches()
    {
        // Example 1: Single number equal to 8
        Assert.That(Numbers.SingleOrDefault(n => n == 8), Is.EqualTo(8));

        // Example 2: Single person with age 22
        var personAge22 = People.SingleOrDefault(p => p.Age == 22);
        Assert.That(personAge22.Name, Is.EqualTo("David"));

        // Example 3: Returns default if no element
        Assert.That(Numbers.SingleOrDefault(n => n == 100), Is.EqualTo(0)); // None
        Assert.That(People.SingleOrDefault(p => p.Name == "Unknown"), Is.Null);

        // Example 4: Throws if more than one element
        Assert.Throws<InvalidOperationException>(() => Numbers.SingleOrDefault(n => n == 5)); // Multiple
        Assert.Throws<InvalidOperationException>(() => People.SingleOrDefault(p => p.City == "New York")); // Multiple
    }

    [Test]
    public void ElementAt_ReturnsElementAtSpecificIndex()
    {
        // Example 1: Element at index 3
        Assert.That(Numbers.ElementAt(3), Is.EqualTo(4)); // 0-indexed: 1,2,3,4

        // Example 2: Person at index 1
        Assert.That(People.ElementAt(1).Name, Is.EqualTo("Bob"));

        // Example 3: Throws if index is out of range
        Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.ElementAt(100));
        Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.ElementAt(-1));
    }

    [Test]
    public void ElementAtOrDefault_ReturnsElementOrDefaultForOutOfRangeIndex()
    {
        // Example 1: Element at index 0
        Assert.That(Numbers.ElementAtOrDefault(0), Is.EqualTo(1));

        // Example 2: Element at out-of-range index (numbers)
        Assert.That(Numbers.ElementAtOrDefault(100), Is.EqualTo(0)); // Default for int
        Assert.That(Numbers.ElementAtOrDefault(-1), Is.EqualTo(0));

        // Example 3: Element at out-of-range index (people)
        Assert.That(People.ElementAtOrDefault(10), Is.Null); // Default for Person (class)
    }
}
