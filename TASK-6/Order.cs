using NLog;

namespace TASK_6;

public class Order
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private Guid _id;
    private Phone _phone;
    private Shop _shop;

    public Order(Phone phone, Shop shop)
    {
        Id = Guid.NewGuid();
        Phone = phone;
        Shop = shop;
        _logger.Info($"Заказ {Phone.Model} на сумму {Phone.Price} успешно оформлен!");
    }
        
    public Guid Id { get => _id; set => _id = value; }
    public Phone Phone { get => _phone; set => _phone = value; }
    public Shop Shop { get => _shop; set => _shop = value; }
}
