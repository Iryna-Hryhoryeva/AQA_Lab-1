namespace Task5;
using Bogus;

public class BogusRepository
{
    public IEnumerable<Ware> GetWares(List<Ware> listOfWares)
    {
        Randomizer.Seed = new Random(123456);

        var wareGenerator = new Faker<Ware>()
            .RuleFor(w => w.Id, (f, w) => f.Commerce.Ean8())
            .RuleFor(w => w.Name, (f, w) => f.Commerce.ProductName())
            .RuleFor(w => w.Category, (f, w) => f.Commerce.Categories(1)[0])
            .RuleFor(w => w.Price, (f, w) => f.Commerce.Price());
        return wareGenerator.Generate(listOfWares.Count);
    }

    public IEnumerable<Customer> GetCustomers(List<Customer> listOfCustomers)
    {
        var customerGenerator = new Faker<Customer>()
            .RuleFor(c => c.PassportId, (f, c) => f.Finance.Account()) 
            .RuleFor(c => c.Name, (f, c) => f.Name.FullName())
            .RuleFor(c => c.Age, (f, c) => f.Person.Random.Int(6, 110))
            .RuleFor(c => c.Cart, () => new Cart());
        return customerGenerator.Generate(listOfCustomers.Count);
    }
}
