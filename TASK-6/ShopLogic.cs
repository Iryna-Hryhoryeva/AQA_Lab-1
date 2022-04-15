using Newtonsoft.Json;
using NLog;

namespace TASK_6;

public class ShopLogic
{
    public static JsonShops JsonShops { get; set; }
    public static List<Phone> FoundPhones { get; set; }
    private static string _path = "appsettings.json";
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public static void GetDataFromJson()
    {
        try
        {
            using (var streamReader = new StreamReader(_path))
            {
                var json = streamReader.ReadToEnd();
                JsonShops = JsonConvert.DeserializeObject<JsonShops>(json);
            }
        }
        catch (Exception exception)
        {
            _logger.Info($"Возникла ошибка {exception.GetType()}: {exception.Message}");
        }
    }

    public static void ShowShopInfo()
    {
        foreach (var shop in JsonShops.Shops)
        {
            shop.Report();
        }
    }

    public static Tuple<Phone, Shop> SelectPhone()
    {
        var selectedPhoneModel = JsonShops.FindPhoneCustomerRequests();
        var selectedShop = JsonShops.SelectShop(selectedPhoneModel);
        var selectedPhone = FoundPhones.Find(p => p.Model == selectedPhoneModel && p.ShopId == selectedShop.Id);

        return Tuple.Create(selectedPhone, selectedShop);
    }

    public static void CreateReceipt(Phone selectedPhone, Shop selectedShop)
    {
        var order = new Receipt(selectedPhone, selectedShop);
        var json = JsonConvert.SerializeObject(order);
        _path = "receipt.txt";
        using (StreamWriter file = File.CreateText(_path))
        {
            file.Write(json);
            file.Close();
        }
    }
}
