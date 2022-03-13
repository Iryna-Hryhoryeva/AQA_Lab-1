namespace Task5;

public class Customer
{
    private string _passportId;
    private string _name;
    private int _age;
    private Cart _cart;

    public string PassportId { get => _passportId; set => _passportId = value; }
    public string Name { get => _name; set => _name = value; } 
    public int Age { get => _age; set => _age = value; }
    public Cart Cart { get => _cart; set => _cart = value; }

    public void SetCustomer(string passportId, string name, int age, Cart cart)
    {
        PassportId = passportId;
        Name = name;
        Age = age;
        Cart = cart;
    }

    public bool Equals(Customer customer)
    {
        return PassportId == customer.PassportId;
    }

    public void AddWare(Ware ware)
    {
        Cart.Wares.Add(ware);
    }
}
