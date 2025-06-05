namespace Delegates
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void Test_PrintMessage_Action()
        {
            // Arrange
            Action<string> printMessage = message => Console.WriteLine(message);

            // Act
            printMessage("Hello, I'm an Action!");

            // Assert
            Assert.Pass("Action executed without errors");
        }

        [Test]
        public void Test_AddNumbers_Action()
        {
            // Arrange
            Action<int, int> addNumbers = (a, b) => Console.WriteLine($"Sum: {a + b}");

            // Act
            addNumbers(5, 10);

            // Assert
            Assert.Pass("Action executed without errors");
        }
    }
}
