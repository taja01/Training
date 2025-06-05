namespace Delegates
{
    [TestFixture]
    public class ActionParameterTests
    {
        private void PerformAction(Action<string> action, string data)
        {
            action(data); // Invoke the passed-in Action delegate
        }

        [Test]
        public void Test_PerformAction_With_PrintMessage_Action()
        {
            // Arrange
            Action<string> printMessage = message => Console.WriteLine($"Message: {message}");

            // Act
            PerformAction(printMessage, "Hello from Action as a parameter!");

            // Assert
            Assert.Pass("Action executed without errors");
        }
    }
}
