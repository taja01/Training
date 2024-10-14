using Training.CodeWars.October;

namespace Training.CodeWars.UnitTests
{
    [TestFixture]
    public class NumbersTest
    {
        [Test]
        public void Test_01()
        {
            Assert.That(Numbers.TwoDecimalPlaces(4.659725356), Is.EqualTo(4.66));
        }

        [Test]
        public void Test_02()
        {
            Assert.That(Numbers.TwoDecimalPlaces(173735326.3783732637948948), Is.EqualTo(173735326.38));
        }
    }
}