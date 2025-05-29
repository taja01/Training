namespace HowToLinQ;

[TestFixture]
public class GroupingExampleTests : BaseTests
{
    [Test]
    public void GroupBy_GroupsElements()
    {
        // Example 1: Group people by City
        var groupsByCity = People.GroupBy(p => p.City).ToList();
        Assert.That(groupsByCity, Has.Count.EqualTo(3));

        var newYorkGroup = groupsByCity.First(g => g.Key == "New York").ToList();
        Assert.That(newYorkGroup, Has.Count.EqualTo(2));
        Assert.That(newYorkGroup.Any(p => p.Name == "Alice"));
        Assert.That(newYorkGroup.Any(p => p.Name == "David"));

        // Example 2: Group numbers by even/odd
        var evenOddGroups = Numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd").ToList();
        var evenGroup = evenOddGroups.First(g => g.Key == "Even");
        Assert.That(evenGroup, Is.EquivalentTo(new[] { 2, 4, 6, 8, 10 }));

        // Example 3: Group words by first letter
        var wordsByFirstLetter = Words.GroupBy(w => w[0]).ToList();
        var aGroup = wordsByFirstLetter.First(g => g.Key == 'a');
        Assert.That(aGroup, Is.EquivalentTo(new[] { "apple" }));
        var bGroup = wordsByFirstLetter.First(g => g.Key == 'b');
        Assert.That(bGroup, Is.EquivalentTo(new[] { "banana" }));
    }
}
