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

    }
}
