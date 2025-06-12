using Training.CodeWars._2025.Jun;

namespace Training.CodeWars.UnitTests;

public class ValidateHelloTests
{
    [Test]
    public void Test()
    {
        Assert.That(Kata.ValidateHello("hello"), Is.True);
        Assert.That(Kata.ValidateHello("ciao bella!"), Is.True);
        Assert.That(Kata.ValidateHello("salut"), Is.True);
        Assert.That(Kata.ValidateHello("hallo, salut"), Is.True);
        Assert.That(Kata.ValidateHello("hombre! Hola!"), Is.True);
        Assert.That(Kata.ValidateHello("Hallo, wie geht's dir?"), Is.True);
        Assert.That(Kata.ValidateHello("AHOJ!"), Is.True);
        Assert.That(Kata.ValidateHello("czesc"), Is.True);
        Assert.That(Kata.ValidateHello("Ahoj"), Is.True);
        Assert.That(Kata.ValidateHello("meh"), Is.False);
    }
}
