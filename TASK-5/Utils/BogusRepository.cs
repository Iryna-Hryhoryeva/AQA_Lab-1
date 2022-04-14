using Bogus;

namespace Task5.Utils;

public class BogusRepository
{
    public static string BogusPassportId = new Faker().Finance.Account();
    
    public List<Ware> GetWares(List<Ware> listOfWares)
    {
        var wareGenerator = new Faker<Ware>()
            .RuleFor(w => w.Id, (f, w) => f.Commerce.Ean8())
            .RuleFor(w => w.Name, (f, w) => f.Commerce.ProductName())
            .RuleFor(w => w.Category, (f, w) => f.Commerce.Categories(1)[0])
            .RuleFor(w => w.Price, (f, w) => f.Commerce.Price());
        
        return wareGenerator.Generate(listOfWares.Count);
    }

    public List<Customer> GetCustomers(List<Customer> listOfCustomers)
    {
        var customerGenerator = new Faker<Customer>()
            .RuleFor(c => c.PassportId, (f, c) => BogusPassportId) 
            .RuleFor(c => c.Name, (f, c) => f.Name.FullName())
            .RuleFor(c => c.Age, (f, c) => f.Person.Random.Int(Customer.MinimumAge, Customer.MaximumAge))
            .RuleFor(c => c.Cart, () => new Cart());
        
        return customerGenerator.Generate(listOfCustomers.Count);
    }
}
