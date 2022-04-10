using Task5.Utils;

namespace Task5;

public class Program
{
    public static void Main(string[] args)
    {
        var createdWares = CreateWares();
        var emptyCarts = CreateEmptyCarts();
        var cartsWithWares = PutWaresInCarts(wares: createdWares, carts: emptyCarts);
        var users = CreateCustomers();
        var usersWithCarts = GiveCartsToCustomers(cartsWithWares, users);
        Menu.Implementor(createdWares, usersWithCarts);
    }
    
    public const int NumberOfCustomers = 5;
    private static BogusRepository _repository = new BogusRepository();

    private static IEnumerable<Ware> CreateWares()
    {
        var listOfWares = new List<Ware>();
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            listOfWares.Add(new Ware());
        }

        var wares = _repository.GetWares(listOfWares);

        return wares;
    }

    private static List<Cart> CreateEmptyCarts()
    {
        var carts = new List<Cart>();

        return carts;
    }

    private static List<Cart> PutWaresInCarts(List<Cart> carts, IEnumerable<Ware> wares)
    {
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            carts.Add(new Cart());
            for (var j = 0; j < RandomUtils.RandomNumberOfCarts; j++)
            {
                carts[i].Wares.Add(wares.ElementAt(RandomUtils.GetRandomWareIndex(wares)));
            }
        }

        return carts;
    }

    private static IEnumerable<Customer> CreateCustomers()
    {
        var listOfCustomers = new List<Customer>();
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            listOfCustomers.Add(new Customer());
        }

        var users = _repository.GetCustomers(listOfCustomers);

        return users;
    }

    private static IEnumerable<Customer> GiveCartsToCustomers(List<Cart> carts, IEnumerable<Customer> users)
    {
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            users.ElementAt(i).Cart = carts[i];
        }

        return users;
    }
}
