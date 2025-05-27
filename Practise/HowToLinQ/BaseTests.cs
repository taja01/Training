using HowToLinQ.Models;

namespace HowToLinQ
{
    [TestFixture]
    public class BaseTests
    {
        protected List<Person> People;
        protected List<int> Numbers;
        protected List<string> Words;

        [SetUp]
        public void Setup()
        {
            People = new List<Person>
        {
            new Person { Name = "Alice", Age = 30, City = "New York", Pets = new List<string> { "Dog", "Cat" } },
            new Person { Name = "Bob", Age = 25, City = "London", Pets = new List<string> { "Fish" } },
            new Person { Name = "Charlie", Age = 30, City = "Paris", Pets = new List<string> { "Dog" } },
            new Person { Name = "David", Age = 22, City = "New York", Pets = new List<string>() },
            new Person { Name = "Eve", Age = 25, City = "London", Pets = new List<string> { "Parrot", "Hamster" } }
        };

            Numbers = new List<int> { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10 };
            Words = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };
        }
    }
}
