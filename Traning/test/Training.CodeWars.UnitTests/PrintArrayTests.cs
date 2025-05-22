namespace Training.CodeWars.UnitTests;

[TestFixture]
public class PrintArrayTests
{

    [Test]
    public void BasicTests()
    {
        var data = new object[] { 2, 4, 5, 2 };
        Assert.That(_2025.May.Kata.PrintArray(data), Is.EqualTo("2,4,5,2"), "int test failed");
    }
}
