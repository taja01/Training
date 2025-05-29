namespace HowToLinQ;

public class ProjectionExampleTests : BaseTests
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

    [Test]
    public void SelectMany_ProjectsAndFlattens()
    {
        // Example 1: Get all pets from all people
        var allPets = People.SelectMany(p => p.Pets).ToList();
        Assert.That(allPets, Is.EquivalentTo(new[] { "Dog", "Cat", "Fish", "Dog", "Parrot", "Hamster" }));

        // Example 2: Characters from words
        var chars = Words.SelectMany(w => w.ToCharArray()).Distinct().ToList(); // Added Distinct for a cleaner example
        Assert.That(chars.Contains('a'));
        Assert.That(chars.Contains('p'));

        // Example 3: Pair numbers with their subsequent numbers
        var pairs = Numbers.Take(3) // Using a smaller list for a clearer example: {1, 2, 3}
                            .SelectMany(x => Numbers.SkipWhile(y => y <= x), // Pair x with y where y > x
                                        (x, y) => new { X = x, Y = y })
                            .ToList();
        // Expected pairs for {1,2,3}: (1,2), (1,3), (1,4)...(1,10), (2,3), (2,4)...(2,10), (3,4)...(3,10)
        Assert.That(pairs.Any(p => p.X == 1 && p.Y == 2));
        Assert.That(pairs.Any(p => p.X == 1 && p.Y == 10));
        Assert.That(pairs.Any(p => p.X == 2 && p.Y == 3));
        Assert.That(pairs.Any(p => p.X == 2 && p.Y == 1), Is.False); // y must be > x
    }
}
