namespace HowToLinQ;

public class SelectManyExampleTests : BaseTests
{
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
