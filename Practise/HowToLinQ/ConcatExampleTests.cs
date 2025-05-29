namespace HowToLinQ;

public class ConcatExampleTests : BaseTests
{
    [Test]
    public void Concat_ConcatenatesTwoSequences()
    {
        var firstNumbers = new List<int> { 1, 2, 6 };
        var secondNumbers = new List<int> { 4, 5, 6 };

        // Example 1: Concatenate two number lists
        var concatenatedNumbers = firstNumbers.Concat(secondNumbers).ToList();
        Assert.That(concatenatedNumbers, Is.EquivalentTo(new[] { 1, 2, 6, 4, 5, 6 }));

        // Example 2: Concatenate two lists of people
        var group1 = People.Take(2).ToList(); // Alice, Bob
        var group2 = People.Skip(2).Take(2).ToList(); // Charlie, David
        var combinedPeople = group1.Concat(group2).ToList();
        Assert.That(combinedPeople, Has.Count.EqualTo(4));
        Assert.That(combinedPeople[0].Name, Is.EqualTo("Alice"));
        Assert.That(combinedPeople[3].Name, Is.EqualTo("David"));

        // Example 3: Concatenate with an empty list
        var emptyList = new List<string>();
        var concatWithEmpty = Words.Concat(emptyList).ToList();
        Assert.That(concatWithEmpty, Is.EquivalentTo(Words));

        var emptyConcatWithWords = emptyList.Concat(Words).ToList();
        Assert.That(emptyConcatWithWords, Is.EquivalentTo(Words));
    }
}
