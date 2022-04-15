using NLog;

namespace TASK_6;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Phone> Phones { get; set; }
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public int CountPhonesWithOsType(string osType)
    {
        var foundPhones = Phones.FindAll(p => p.OperationSystemType == osType && p.IsAvailable);
        var numberOfPhones = foundPhones.Count();

        return numberOfPhones;
    }

    public void Report()
    {
        _logger.Info(
            "\nМагазин №{0} {1} - {2}.\nКоличество устройств IOS в наличии: {3}\nКоличество устройств Android в наличии: {4}\n",
            Id, Name, Description, CountPhonesWithOsType("IOS"), CountPhonesWithOsType("Android"));
    }
}
