namespace HowToLinQ;

public class PartitioningExampleTests : BaseTests
{
    [Test]
    public void Take_TakesSpecifiedNumberOfElements()
    {
        // Example 1: Take first 3 numbers
        var first3Numbers = Numbers.Take(3).ToList();
        Assert.That(first3Numbers, Is.EquivalentTo(new[] { 1, 2, 3 }));

        // Example 2: Take first 2 people
        var first2People = People.Take(2).ToList();
        Assert.That(first2People, Has.Count.EqualTo(2));
        Assert.That(first2People[0].Name, Is.EqualTo("Alice"));
        Assert.That(first2People[1].Name, Is.EqualTo("Bob"));

        // Example 3: Take more elements than available
        var takeTooMany = Words.Take(10).ToList(); // Words has 5 elements
        Assert.That(takeTooMany, Is.EqualTo(Words));

        // Example 4: Take 0 elements
        var takeZero = Numbers.Take(0).ToList();
        Assert.That(takeZero, Is.Empty);
    }

    [Test]
    public void Skip_SkipsSpecifiedNumberOfElements()
    {
        // Example 1: Skip first 3 numbers
        var skip3Numbers = Numbers.Skip(3).ToList();
        Assert.That(skip3Numbers, Is.EqualTo(new[] { 4, 5, 5, 6, 7, 8, 9, 10 }));

        // Example 2: Skip first 2 people
        var skip2People = People.Skip(2).ToList();
        Assert.That(skip2People, Has.Count.EqualTo(3));
        Assert.That(skip2People[0].Name, Is.EqualTo("Charlie"));

        // Example 3: Skip more elements than available
        var skipTooMany = Words.Skip(10).ToList();
        Assert.That(skipTooMany, Is.Empty);

        // Example 4: Skip 0 elements
        var skipZero = Numbers.Skip(0).ToList();
        Assert.That(skipZero, Is.EqualTo(Numbers));
    }

    [Test]
    public void TakeWhile_TakesElementsWhileConditionIsTrue()
    {
        // Example 1: Take numbers while less than 6
        var takeWhileLessThan6 = Numbers.TakeWhile(n => n < 6).ToList(); // 1,2,3,4,5,5 (stops at first 6)
        Assert.That(takeWhileLessThan6, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 5 }));

        // Example 2: Take people while age is less than 30
        // People ages: 30(A), 25(B), 30(C), 22(D), 25(E)
        // If sorted by age: 22(D), 25(B), 25(E), 30(A), 30(C)
        var sortedByAge = People.OrderBy(p => p.Age).ToList();
        var takeWhileAgeLessThan30 = sortedByAge.TakeWhile(p => p.Age < 30).ToList();
        Assert.That(takeWhileAgeLessThan30, Has.Count.EqualTo(3)); // David (22), Bob (25), Eve (25)

        // Example 3: Condition is false for the first element
        var takeNone = Numbers.TakeWhile(n => n > 10).ToList();
        Assert.That(takeNone, Is.Empty);
    }

    [Test]
    public void SkipWhile_SkipsElementsWhileConditionIsTrue()
    {
        // Example 1: Skip numbers while less than 5
        var skipWhileLessThan5 = Numbers.SkipWhile(n => n < 5).ToList(); // Skips 1,2,3,4. Starts from first 5
        Assert.That(skipWhileLessThan5, Is.EqualTo(new[] { 5, 5, 6, 7, 8, 9, 10 }));

        // Example 2: Skip people while name starts with 'A' or 'B' (from original list)
        // People: Alice, Bob, Charlie, David, Eve
        var skipAB = People.SkipWhile(p => p.Name.StartsWith("A") || p.Name.StartsWith("B")).ToList();
        Assert.That(skipAB, Has.Count.EqualTo(3));
        Assert.That(skipAB[0].Name, Is.EqualTo("Charlie"));

        // Example 3: Condition is false for the first element (skips none)
        var skipNone = Numbers.SkipWhile(n => n > 10).ToList();
        Assert.That(skipNone, Is.EqualTo(Numbers));
    }

    [Test]
    public void Chunk_SplitsElementsIntoChunksOfSpecifiedSize() // .NET 6+
    {
        // Example 1: Chunk numbers into size 3
        var chunksOf3 = Numbers.Chunk(3).ToList(); // {1..10}, 5,5
        // Expected: [[1,2,3], [4,5,5], [6,7,8], [9,10]]
        Assert.That(chunksOf3, Has.Count.EqualTo(4));
        Assert.That(chunksOf3[0], Is.EqualTo(new[] { 1, 2, 3 }));
        Assert.That(chunksOf3[1], Is.EqualTo(new[] { 4, 5, 5 }));
        Assert.That(chunksOf3[2], Is.EqualTo(new[] { 6, 7, 8 }));
        Assert.That(chunksOf3[3], Is.EqualTo(new[] { 9, 10 }));

        // Example 2: Chunk words into size 2
        var wordChunks = Words.Chunk(2).ToList(); // 5 words
        // Expected: [["apple", "banana"], ["cherry", "date"], ["elderberry"]]
        Assert.That(wordChunks, Has.Count.EqualTo(3));
        Assert.That(wordChunks[0], Is.EqualTo(new[] { "apple", "banana" }));
        Assert.That(wordChunks[1], Is.EqualTo(new[] { "cherry", "date" }));
        Assert.That(wordChunks[2], Is.EqualTo(new[] { "elderberry" }));

        // Example 3: Chunk size larger than collection
        var largeChunks = Numbers.Chunk(20).ToList();
        Assert.That(largeChunks, Has.Count.EqualTo(1));
        Assert.That(largeChunks[0], Is.EqualTo(Numbers));

        // Example 4: Chunk empty list
        var emptyChunks = Enumerable.Empty<int>().Chunk(5).ToList();
        Assert.That(emptyChunks, Is.Empty);
    }
}
