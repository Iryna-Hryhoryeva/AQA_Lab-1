namespace Task5;

public class Program
{
    public static void Main(string[] args)
    {
        var createdWares = ShopLogic.CreateWares();
        var emptyCarts = ShopLogic.CreateEmptyCarts();
        var cartsWithWares = ShopLogic.PutWaresInCarts(wares: createdWares, carts: emptyCarts);
        var users = ShopLogic.CreateCustomers();
        var usersWithCarts = ShopLogic.GiveCartsToCustomers(cartsWithWares, users);
        Menu.Implementor(createdWares, usersWithCarts);
    }
}
