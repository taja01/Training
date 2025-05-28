using NUnit.Framework.Legacy;

namespace HowToLinQ
{
    [TestFixture]
    internal class OrderExampleTests : BaseTests
    {
        [Test]
        public void OrderBy_SortsElements()
        {
            // Example 1: Order numbers ascending
            var orderedNumbers = Numbers.OrderBy(n => n).ToList(); // Numbers already somewhat ordered, but Distinct makes it clearer
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10 }, orderedNumbers);

            // Example 2: Order people by age
            var orderedPeopleByAge = People.OrderBy(p => p.Age).ToList();
            Assert.That(orderedPeopleByAge.First().Name, Is.EqualTo("David"));
            Assert.That(orderedPeopleByAge.First().Age, Is.EqualTo(22));
            Assert.That(orderedPeopleByAge.Last().Age, Is.EqualTo(30));

            // Example 3: Order words by length
            var orderedWordsByLength = Words.OrderBy(w => w.Length).ToList();
            CollectionAssert.AreEqual(new[] { "date", "apple", "banana", "cherry", "elderberry" }, orderedWordsByLength);
        }

        [Test]
        public void ThenBy_SecondarySort()
        {
            // Example 1: Order people by City, then by Name
            var orderedPeople = People.OrderBy(p => p.City).ThenBy(p => p.Name).ToList();
            Assert.That(orderedPeople[0].Name, Is.EqualTo("Bob"));
            Assert.That(orderedPeople[1].Name, Is.EqualTo("Eve"));
            Assert.That(orderedPeople[2].Name, Is.EqualTo("Alice"));
            Assert.That(orderedPeople[3].Name, Is.EqualTo("David"));
            Assert.That(orderedPeople[4].Name, Is.EqualTo("Charlie"));

            // Example 2: Order people by Age, then by Name
            var orderedPeopleByAgeThenName = People.OrderBy(p => p.Age).ThenBy(p => p.Name).ToList();
            Assert.That(orderedPeopleByAgeThenName[0].Name, Is.EqualTo("David"));
            Assert.That(orderedPeopleByAgeThenName[1].Name, Is.EqualTo("Bob"));
            Assert.That(orderedPeopleByAgeThenName[2].Name, Is.EqualTo("Eve"));
            Assert.That(orderedPeopleByAgeThenName[3].Name, Is.EqualTo("Alice"));
            Assert.That(orderedPeopleByAgeThenName[4].Name, Is.EqualTo("Charlie"));
        }

        [Test]
        public void ThenByDescending_SecondarySortDescending()
        {
            // Example 1: Order people by City, then by Name Descending
            var orderedPeople = People.OrderBy(p => p.City).ThenByDescending(p => p.Name).ToList();
            Assert.That(orderedPeople[0].Name, Is.EqualTo("Eve"));
            Assert.That(orderedPeople[1].Name, Is.EqualTo("Bob"));
            Assert.That(orderedPeople[2].Name, Is.EqualTo("David"));
            Assert.That(orderedPeople[3].Name, Is.EqualTo("Alice"));
            Assert.That(orderedPeople[4].Name, Is.EqualTo("Charlie"));

            // Example 2: Order people by Age Ascending, then by Name Descending
            var orderedPeopleByAgeThenNameDesc = People.OrderBy(p => p.Age).ThenByDescending(p => p.Name).ToList();
            Assert.That(orderedPeopleByAgeThenNameDesc[0].Name, Is.EqualTo("David"));
            Assert.That(orderedPeopleByAgeThenNameDesc[1].Name, Is.EqualTo("Eve"));
            Assert.That(orderedPeopleByAgeThenNameDesc[2].Name, Is.EqualTo("Bob"));
            Assert.That(orderedPeopleByAgeThenNameDesc[3].Name, Is.EqualTo("Charlie"));
            Assert.That(orderedPeopleByAgeThenNameDesc[4].Name, Is.EqualTo("Alice"));
        }

        [Test]
        public void Reverse_ReversesOrderOfElements()
        {
            // Example 1: Reverse numbers
            var reversedNumbers = Numbers.ToList();
            reversedNumbers.Reverse();

            var linqReversedNumbers = Numbers.AsEnumerable().Reverse().ToList();
            CollectionAssert.AreEqual(new[] { 10, 9, 8, 7, 6, 5, 5, 4, 3, 2, 1 }, linqReversedNumbers);

            // Example 2: Reverse people (order as initially defined)
            var reversedPeople = People.AsEnumerable().Reverse().ToList();
            Assert.That(reversedPeople.First().Name, Is.EqualTo("Eve"));
            Assert.That(reversedPeople.Last().Name, Is.EqualTo("Alice"));

            // Example 3: Reverse already ordered words
            var orderedWords = Words.OrderBy(w => w).ToList();
            var reversedOrderedWords = orderedWords.AsEnumerable().Reverse().ToList();
            CollectionAssert.AreEqual(new[] { "elderberry", "date", "cherry", "banana", "apple" }, reversedOrderedWords);
        }
    }
}
