namespace TASK_6.Models;

public class Receipt
{
    public Guid ReceiptId { get; }
    public Phone Phone { get; }
    public string ShopName { get; }
    public string ShopDescription { get; }

    public Receipt(Phone phone, string shopName, string shopDescription)
    {
        ReceiptId = Guid.NewGuid();
        Phone = phone;
        ShopName = shopName;
        ShopDescription = shopDescription;
    }
}
