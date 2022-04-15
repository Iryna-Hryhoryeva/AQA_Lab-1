using NLog;

namespace TASK_6;

public class Receipt
{
    public Guid Id { get; set; }
    public Phone Phone { get; set; }
    public Shop Shop { get; set; }
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public Receipt(Phone phone, Shop shop)
    {
        Id = Guid.NewGuid();
        Phone = phone;
        Shop = shop;
        _logger.Info($"Заказ {Phone.Model} на сумму {Phone.Price} успешно оформлен!");
    }
}
