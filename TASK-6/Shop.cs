using NLog;

namespace TASK_6;

public class Shop
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private int _id;
    private string _name;
    private string _description;
    private List<Phone> _phones;

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public List<Phone> Phones { get => _phones; set => _phones = value; }

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
