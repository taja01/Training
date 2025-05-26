using Training.CodeWars._2025.May;

namespace Training.CodeWars.UnitTests;

public class DatingRangeTests
{

    [Test, Description("Example Test Cases")]
    public void Test()
    {
        Assert.That(Kata.DatingRange(17), Is.EqualTo("15-20"));
        Assert.That(Kata.DatingRange(40), Is.EqualTo("27-66"));
        Assert.That(Kata.DatingRange(15), Is.EqualTo("14-16"));
        Assert.That(Kata.DatingRange(35), Is.EqualTo("24-56"));
        Assert.That(Kata.DatingRange(10), Is.EqualTo("9-11"));
    }
}
