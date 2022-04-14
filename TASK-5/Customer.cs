namespace Task5;

public class Customer
{
    public const int MinimumAge = 4;
    public const int MaximumAge = 130;
    public string PassportId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Cart Cart { get; set; }

    public Customer()
    {
    }

    public Customer(string passportId, string name, int age, Cart cart)
    {
        PassportId = passportId;
        Name = name;
        Age = age;
        Cart = cart;
    }


    public override bool Equals(object? passportId)
    {
        return PassportId == (string)passportId;
    }

    public void AddWare(Ware ware)
    {
        Cart.Wares.Add(ware);
    }
}
