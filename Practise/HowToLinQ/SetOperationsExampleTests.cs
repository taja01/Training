using HowToLinQ.Models;

namespace HowToLinQ;

public class SetOperationsExampleTests : BaseTests
{
    [Test]
    public void Distinct_ReturnsDistinctElements()
    {
        // Example 1: Distinct numbers
        var distinctNumbers = Numbers.Distinct().ToList(); // { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10 }
        Assert.That(distinctNumbers, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
        Assert.That(distinctNumbers, Has.Count.EqualTo(10));

        // Example 2: Distinct ages of people
        var distinctAges = People.Select(p => p.Age).Distinct().OrderBy(a => a).ToList();
        Assert.That(distinctAges, Is.EquivalentTo(new[] { 22, 25, 30 }));

        // Example 3: Distinct cities
        var distinctCities = People.Select(p => p.City).Distinct().ToList();
        Assert.That(distinctCities, Is.EquivalentTo(new[] { "New York", "London", "Paris" }));
    }

    [Test]
    public void Union_ReturnsSetUnionOfTwoSequences()
    {
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 3, 4, 5, 6 };

        // Example 1: Union of two number lists
        var unionResult = list1.Union(list2).ToList();
        Assert.That(unionResult, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6 })); // Order not guaranteed for AreEquivalent
        Assert.That(unionResult, Contains.Item(1)); // Better to check individual items or sort for AreEqual
        Assert.That(unionResult.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key), Does.Not.Contain(3)); // No duplicates

        // Example 2: Union of two string lists
        var words1 = new List<string> { "apple", "banana" };
        var words2 = new List<string> { "banana", "cherry" };
        var unionWords = words1.Union(words2).ToList();
        Assert.That(unionWords, Is.EquivalentTo(new[] { "apple", "banana", "cherry" }));

        // Example 3: Union with custom objects (requires custom comparer or rely on default Equals/GetHashCode if suitable)
        var people1 = new List<Person> { People[0], People[1] }; // Alice, Bob
        var people2 = new List<Person> { People[1], People[2] }; // Bob, Charlie
        var unionPeople = people1.Union(people2).ToList(); // Relies on Person.Equals
        Assert.That(unionPeople, Has.Count.EqualTo(3)); // Alice, Bob, Charlie
        Assert.That(unionPeople.Any(p => p.Name == "Alice"));
        Assert.That(unionPeople.Any(p => p.Name == "Bob"));
        Assert.That(unionPeople.Any(p => p.Name == "Charlie"));
    }

    [Test]
    public void Intersect_ReturnsSetIntersection()
    {
        var list1 = new List<int> { 1, 2, 3, 4, 5 };
        var list2 = new List<int> { 3, 4, 5, 6, 7 };

        // Example 1: Intersection of number lists
        var intersectionResult = list1.Intersect(list2).ToList();
        Assert.That(intersectionResult, Is.EquivalentTo(new[] { 3, 4, 5 }));

        // Example 2: Intersection of string lists
        var words1 = new List<string> { "apple", "banana", "cherry" };
        var words2 = new List<string> { "banana", "date" };
        var intersectionWords = words1.Intersect(words2).ToList();
        Assert.That(intersectionWords, Is.EquivalentTo(new[] { "banana" }));

        // Example 3: Intersection with custom objects
        var p1 = new Person { Name = "Common", Age = 10 };
        var p2 = new Person { Name = "Common", Age = 10 }; // Same content, different instance
        var listA = new List<Person> { People[0], p1 }; // Alice, Common
        var listB = new List<Person> { People[2], p2 }; // Charlie, Common
        var intersectionPeople = listA.Intersect(listB).ToList(); // Uses Person.Equals
        Assert.That(intersectionPeople, Has.Count.EqualTo(1));
        Assert.That(intersectionPeople.First().Name, Is.EqualTo("Common"));
    }

    [Test]
    public void Except_ReturnsSetDifference()
    {
        var list1 = new List<int> { 1, 2, 3, 4, 5 };
        var list2 = new List<int> { 3, 4, 6 };

        // Example 1: Elements in list1 not in list2
        var exceptResult1 = list1.Except(list2).ToList();
        Assert.That(exceptResult1, Is.EquivalentTo(new[] { 1, 2, 5 }));

        // Example 2: Elements in list2 not in list1
        var exceptResult2 = list2.Except(list1).ToList();
        Assert.That(exceptResult2, Is.EquivalentTo(new[] { 6 }));

        // Example 3: Except with custom objects
        var peopleGroupA = new List<Person> { People[0], People[1], People[2] }; // Alice, Bob, Charlie
        var peopleGroupB = new List<Person> { People[1], People[3] };         // Bob, David
        var resultPeople = peopleGroupA.Except(peopleGroupB).ToList(); // People in A but not in B
        Assert.That(resultPeople, Has.Count.EqualTo(2));
        Assert.That(resultPeople.Any(p => p.Name == "Alice"));
        Assert.That(resultPeople.Any(p => p.Name == "Charlie"));
    }
}
