using HowToLinQ.Models;

namespace HowToLinQ;

public class AggregationExampleTests : BaseTests
{
    [Test]
    public void Count_ReturnsNumberOfElements()
    {
        // Example 1: Count all numbers
        Assert.That(Numbers, Has.Count.EqualTo(11));

        // Example 2: Count people older than 25
        Assert.That(People.Count(p => p.Age > 25), Is.EqualTo(2));

        // Example 3: Count words starting with 'c'
        Assert.That(Words.Count(w => w.StartsWith("c")), Is.EqualTo(1));
    }

    [Test]
    public void Sum_CalculatesSumOfNumericValues()
    {
        // Example 1: Sum of all numbers
        Assert.That(Numbers.Sum(), Is.EqualTo(60));

        // Example 2: Sum of ages of all people
        Assert.That(People.Sum(p => p.Age), Is.EqualTo(30 + 25 + 30 + 22 + 25));

        // Example 3: Sum of quantities of orders
        var orders = new List<Order>
        {
            new Order { ProductName = "A", Quantity = 5 },
            new Order { ProductName = "B", Quantity = 10 }
        };
        Assert.That(orders.Sum(o => o.Quantity), Is.EqualTo(15));
    }

    [Test]
    public void Min_FindsMinimumValue()
    {
        // Example 1: Minimum number
        Assert.That(Numbers.Min(), Is.EqualTo(1));

        // Example 2: Minimum age of people
        Assert.That(People.Min(p => p.Age), Is.EqualTo(22));

        // Example 3: Length of the shortest word
        Assert.That(Words.Min(w => w.Length), Is.EqualTo(4));
    }

    [Test]
    public void Max_FindsMaximumValue()
    {
        // Example 1: Maximum number
        Assert.That(Numbers.Max(), Is.EqualTo(10));

        // Example 2: Maximum age of people
        Assert.That(People.Max(p => p.Age), Is.EqualTo(30));

        // Example 3: Length of the longest word
        Assert.That(Words.Max(w => w.Length), Is.EqualTo(10));
    }

    [Test]
    public void Average_CalculatesAverageOfNumericValues()
    {
        // Example 1: Average of numbers
        Assert.That(Numbers.Average(), Is.EqualTo(60.0 / 11.0));

        // Example 2: Average age of people
        Assert.That(People.Average(p => p.Age), Is.EqualTo(132.0 / 5.0));

        // Example 3: Average length of words
        // Lengths: apple(5), banana(6), cherry(6), date(4), elderberry(10) -> Sum = 31
        Assert.That(Words.Average(w => w.Length), Is.EqualTo(31.0 / 5.0));
    }

    [Test]
    public void Aggregate_AppliesAccumulatorFunction()
    {
        // Example 1: Product of numbers (use Take for smaller set to avoid overflow)
        var product = Numbers.Take(4).Aggregate((acc, n) => acc * n); // 1*2*3*4
        Assert.That(product, Is.EqualTo(24));

        // Example 2: Concatenate all names of people
        var allNames = People.Select(p => p.Name).Aggregate((current, next) => current + ", " + next);
        Assert.That(allNames, Is.EqualTo("Alice, Bob, Charlie, David, Eve"));

        // Example 3: Sum of word lengths with a seed
        var sumOfLengths = Words.Aggregate(0, (acc, word) => acc + word.Length); // Seeded
        Assert.That(sumOfLengths, Is.EqualTo(31));
    }
}
