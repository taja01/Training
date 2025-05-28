namespace HowToLinQ;

public class SelectExampleTests : BaseTests
{
    [Test]
    public void Select_ProjectsEachElement()
    {
        // Example 1: Get squares of numbers
        var squares = Numbers.Select(n => n * n).ToList();
        Assert.That(squares, Is.EquivalentTo(new[] { 1, 4, 9, 16, 25, 25, 36, 49, 64, 81, 100 }));

        // Example 2: Get names of people
        var names = People.Select(p => p.Name).ToList();
        Assert.That(names, Is.EquivalentTo(new[] { "Alice", "Bob", "Charlie", "David", "Eve" }));

        // Example 3: Create anonymous objects with name and city
        var nameAndCity = People.Select(p => new { p.Name, p.City }).ToList();
        Assert.That(nameAndCity[0].Name, Is.EqualTo("Alice"));
        Assert.That(nameAndCity[0].City, Is.EqualTo("New York"));
        Assert.That(nameAndCity[4].City, Is.EqualTo("London"));
    }
}
