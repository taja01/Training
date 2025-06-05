namespace Delegates
{
    [TestFixture]
    public class FuncTests
    {
        [Test]
        public void Test_Square_Func()
        {
            // Arrange
            Func<int, int> square = x => x * x;

            // Act
            int result = square(5);

            // Assert
            Assert.That(result, Is.EqualTo(25), "Square calculation result is incorrect");
        }

        [Test]
        public void Test_AddNumbers_Func()
        {
            // Arrange
            Func<int, int, int> addNumbers = (a, b) => a + b;

            // Act
            int result = addNumbers(5, 10);

            // Assert
            Assert.That(result, Is.EqualTo(15), "Addition result is incorrect");
        }
    }
}
