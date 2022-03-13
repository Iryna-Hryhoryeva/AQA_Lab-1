namespace Task5;

public class Cart
{
    private List<Ware> _wares;

    public List<Ware> Wares { get => _wares; set => _wares = value; }

    public Cart()
    {
        Wares = new List<Ware>();
    }
}
