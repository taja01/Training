namespace Training.CodeWars._2025.Jun
{
    public class Kata
    {
        public static bool ValidateHello(string greetings)
        {
            var hello = new[] { "hello", "ciao", "salut", "hallo", "hola", "ahoj", "czesc" };

            return hello.Any(word => greetings.Contains(word, StringComparison.OrdinalIgnoreCase));
        }
    }
}
