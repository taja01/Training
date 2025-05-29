using HowToLinQ.Models;

namespace HowToLinQ;

[TestFixture]
public class GroupExampleTests : BaseTests
{
    [Test]
    public void Join_CorrelatesElementsOfTwoSequences()
    {
        var categories = new List<(int Id, string Name)>
        {
            (1, "Fruit"), (2, "Vegetable")
        };
        var products = new List<(string Name, int CategoryId)>
        {
            ("Apple", 1), ("Banana", 1), ("Carrot", 2), ("Broccoli", 2), ("Date", 1)
        };

        // Example 1: Join products and categories
        var productCategories = products.Join(categories,
                                     product => product.CategoryId,
                                     category => category.Id,
                                     (product, category) => new { ProductName = product.Name, CategoryName = category.Name })
                                     .ToList();

        Assert.That(productCategories, Has.Count.EqualTo(5));
        Assert.That(productCategories.Any(pc => pc.ProductName == "Apple" && pc.CategoryName == "Fruit"));
        Assert.That(productCategories.Any(pc => pc.ProductName == "Carrot" && pc.CategoryName == "Vegetable"));

        // Example 2: People and their orders (simplified)
        var orders = new List<Order>
        {
            new Order { OrderId = 1, ProductName = "Book", Quantity = 1 }, // No person matches OrderId directly to Age
            new Order { OrderId = 2, ProductName = "Pen", Quantity = 10 }
        };

        // This example is a bit contrived as Join matches on equality.
        // Let's make a more meaningful join by adding a CustomerId to Person and Order.
        var peopleWithId = People.Select((p, index) => new { Person = p, CustomerId = index + 1 }).ToList();
        var ordersWithCustomerId = new List<(int OrderId, string ProductName, int CustomerId)>
        {
            (101, "Laptop", 1), (102, "Mouse", 2), (103, "Keyboard", 1), (104, "Monitor", 3)
        };

        var customerOrders = peopleWithId.Join(ordersWithCustomerId,
                                        pwi => pwi.CustomerId,
                                        order => order.CustomerId,
                                        (pwi, order) => new { CustomerName = pwi.Person.Name, order.ProductName })
                                        .ToList();
        Assert.That(customerOrders, Has.Count.EqualTo(4));
        Assert.That(customerOrders.Any(co => co.CustomerName == "Alice" && co.ProductName == "Laptop"));
        Assert.That(customerOrders.Any(co => co.CustomerName == "Bob" && co.ProductName == "Mouse"));
    }

    [Test]
    public void GroupJoin_CorrelatesWithGroupedResults()
    {
        var categories = new List<(int Id, string Name)>
        {
            (1, "Electronics"), (2, "Books")
        };
        var products = new List<(string Name, int CategoryId, int Price)>
        {
            ("Laptop", 1, 1200), ("Mouse", 1, 25), ("Keyboard", 1, 75),
            ("C# Programming", 2, 45), ("Clean Code", 2, 35)
        };

        // Example 1: Categories and their products
        var categoryProducts = categories.GroupJoin(products,
                                            cat => cat.Id,
                                            prod => prod.CategoryId,
                                            (category, prods) => new { CategoryName = category.Name, Products = prods.ToList() })
                                            .ToList();

        Assert.That(categoryProducts, Has.Count.EqualTo(2));

        var electronics = categoryProducts.First(cp => cp.CategoryName == "Electronics");
        Assert.That(electronics.Products, Has.Count.EqualTo(3));
        Assert.That(electronics.Products.Any(p => p.Name == "Laptop"));

        var books = categoryProducts.First(cp => cp.CategoryName == "Books");
        Assert.That(books.Products, Has.Count.EqualTo(2));
        Assert.That(books.Products.Any(p => p.Name == "C# Programming"));

        // Example 2: People and their pets (if pets were a separate list of objects with OwnerName)
        var petOwners = new List<string> { "Alice", "Bob", "Charlie", "Eve" };
        var allPetsList = new List<(string Name, string OwnerName)> {
            ("Dog", "Alice"), ("Cat", "Alice"), ("Fish", "Bob"), ("Dog", "Charlie"),
            ("Parrot", "Eve"), ("Hamster", "Eve"), ("Turtle", "Unknown")
        };

        var peopleAndTheirPets = People.GroupJoin(allPetsList,
                                        person => person.Name,
                                        pet => pet.OwnerName,
                                        (person, petsOfPerson) => new { Owner = person, Pets = petsOfPerson.ToList() })
                                        .ToList();

        var alice = peopleAndTheirPets.First(p => p.Owner.Name == "Alice");
        Assert.That(alice.Pets, Has.Count.EqualTo(2));
        Assert.That(alice.Pets.Any(p => p.Name == "Dog"));

        var david = peopleAndTheirPets.First(p => p.Owner.Name == "David");
        Assert.That(david.Pets, Has.Count.EqualTo(0));
    }
}
