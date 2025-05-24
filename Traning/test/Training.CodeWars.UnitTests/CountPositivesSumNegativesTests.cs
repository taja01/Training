using Training.CodeWars._2025.May;

namespace Training.CodeWars.UnitTests;

public class CountPositivesSumNegativesTests
{
    [Test, Order(1)]
    public void CountPositivesSumNegatives_BasicTest()
    {
        int[] expectedResult = new int[] { 10, -65 };

        Assert.That(Kata.CountPositivesSumNegatives(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 }), Is.EqualTo(expectedResult));
    }

    [Test, Order(2)]
    public void CountPositivesSumNegatives_InputWithZeroes()
    {
        int[] expectedResult = new int[] { 8, -50 };

        Assert.That(Kata.CountPositivesSumNegatives(new[] { 0, 2, 3, 0, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14 }), Is.EqualTo(expectedResult));
    }

    [Test, Order(3)]
    public void CountPositivesSumNegatives_InputNull()
    {
        int[] expectedResult = new int[] { };

        Assert.That(Kata.CountPositivesSumNegatives(null), Is.EqualTo(expectedResult));
    }

    [Test, Order(4)]
    public void CountPositivesSumNegatives_InputEmpty()
    {
        int[] expectedResult = new int[] { };

        Assert.That(Kata.CountPositivesSumNegatives(new int[] { }), Is.EqualTo(expectedResult));
    }
}
