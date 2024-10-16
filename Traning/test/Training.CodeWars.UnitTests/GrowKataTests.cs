using Training.CodeWars.October;

namespace Training.CodeWars.UnitTests
{
    [TestFixture]
    public class GrowKataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.That(Kata.Grow(new[] { 1, 2, 3 }), Is.EqualTo(6));
            Assert.That(Kata.Grow(new[] { 4, 1, 1, 1, 4 }), Is.EqualTo(16));
            Assert.That(Kata.Grow(new[] { 2, 2, 2, 2, 2, 2 }), Is.EqualTo(64));
        }
    }
}
