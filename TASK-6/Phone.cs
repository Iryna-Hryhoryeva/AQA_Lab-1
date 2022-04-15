using NLog;

namespace TASK_6;

public class Phone
{
    public string Model { get; set; }
    public string OperationSystemType { get; set; }
    public string MarketLaunchDate { get; set; }
    public string Price { get; set; }
    public bool IsAvailable { get; set; }
    public int ShopId { get; set; }
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    
    public void Report()
    {
        _logger.Info(
            $"Модель: {Model}, тип ОС: {OperationSystemType}, дата выпуска: {MarketLaunchDate}, " +
            $"стоимость: {Price}, магазин: {ShopLogic.JsonShops.ShopByNumber(ShopId)}");
    }
}
