namespace Task5;

public class Customer
{
    public string PassportId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Cart Cart { get; set; }

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
