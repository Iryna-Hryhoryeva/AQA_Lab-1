using Task5.Utils;

namespace Task5;

public class ShopLogic
{
    public const int NumberOfCustomers = 5;
    private static BogusRepository _repository = new BogusRepository();

    public static List<Ware> CreateWares()
    {
        var listOfWares = new List<Ware>();
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            listOfWares.Add(new Ware());
        }

        var wares = _repository.GetWares(listOfWares);

        return wares;
    }

    public static List<Cart> CreateEmptyCarts()
    {
        var carts = new List<Cart>();

        return carts;
    }

    public static List<Cart> PutWaresInCarts(List<Cart> carts, List<Ware> wares)
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

    public static List<Customer> CreateCustomers()
    {
        var listOfCustomers = new List<Customer>();
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            listOfCustomers.Add(new Customer());
        }

        var users = _repository.GetCustomers(listOfCustomers);

        return users;
    }

    public static List<Customer> GiveCartsToCustomers(List<Cart> carts, List<Customer> users)
    {
        for (var i = 0; i < NumberOfCustomers; i++)
        {
            users.ElementAt(i).Cart = carts[i];
        }

        return users;
    }
}
