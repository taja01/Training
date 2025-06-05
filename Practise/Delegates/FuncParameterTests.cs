namespace Delegates
{
    [TestFixture]
    public class FuncParameterTests
    {
        private int PerformCalculation(Func<int, int, int> calculation, int a, int b)
        {
            return calculation(a, b); // Invoke the passed-in Func delegate
        }

        [Test]
        public void Test_PerformCalculation_With_Addition_Func()
        {
            // Arrange
            Func<int, int, int> add = (x, y) => x + y;

            // Act
            int result = PerformCalculation(add, 10, 5);

            // Assert
            Assert.That(result, Is.EqualTo(15), "Addition result is incorrect");
        }

        [Test]
        public void Test_PerformCalculation_With_Multiplication_Func()
        {
            // Arrange
            Func<int, int, int> multiply = (x, y) => x * y;

            // Act
            int result = PerformCalculation(multiply, 10, 5);

            // Assert
            Assert.That(result, Is.EqualTo(50), "Multiplication result is incorrect");
        }
    }
}
