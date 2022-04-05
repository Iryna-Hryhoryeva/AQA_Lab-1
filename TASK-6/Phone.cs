using NLog;

namespace TASK_6;

public class Phone
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private string _model;
    private string _operationSystemType;
    private string _marketLaunchDate;
    private string _price;
    private bool _isAvailable;
    private int _shopId;

    public string Model { get => _model; set => _model = value; }
    public string OperationSystemType { get => _operationSystemType; set => _operationSystemType = value; }
    public string MarketLaunchDate { get => _marketLaunchDate; set => _marketLaunchDate = value; }
    public string Price { get => _price; set => _price = value; }
    public bool IsAvailable { get => _isAvailable; set => _isAvailable = value; }
    public int ShopId { get => _shopId; set => _shopId = value; }

    public void Report()
    {
        _logger.Info(
            $"Модель: {Model}, тип ОС: {OperationSystemType}, дата выпуска: {MarketLaunchDate}, " +
            $"стоимость: {Price}, магазин: {Program.JsonShops.ShopByNumber(ShopId)}\n");
    }
}
