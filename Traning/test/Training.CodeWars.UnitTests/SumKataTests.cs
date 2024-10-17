using Training.CodeWars.October;

namespace Training.CodeWars.UnitTests
{
    [TestFixture]
    internal class SumKataTests
    {
        [Test]
        public void SumPositives()
        {
            Assert.That(Kata.Sum(new[] { 6, 2, 1, 8, 10 }), Is.EqualTo(16));
        }

        [Test]
        public void SumNull()
        {
            Assert.That(Kata.Sum(null), Is.EqualTo(0));
        }

        [Test]
        public void SumAlone()
        {
            Assert.That(Kata.Sum(new[] { 10 }), Is.EqualTo(0));
        }

    }
}
