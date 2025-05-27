namespace HowToLinQ.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public List<string> Pets { get; set; } = new List<string>();

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Age == person.Age &&
                   City == person.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, City);
        }

        public override string ToString()
        {
            return $"{Name} ({Age}) from {City}";
        }
    }

}
