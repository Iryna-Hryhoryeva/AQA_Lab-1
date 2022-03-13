using Newtonsoft.Json;

namespace TASK_6;

public class Program
{
    private static JsonShops.AllShops _shops;
    private static List<JsonShops.Phone> _foundPhones;

    public static JsonShops.AllShops Shops { get => _shops; set => _shops = value; }
    public static List<JsonShops.Phone> FoundPhones { get => _foundPhones; set => _foundPhones = value; }

    public static void Main(string[] args)
    {
        string json;
        using (var streamReader = new StreamReader("appsettings.json"))
        {
            json = streamReader.ReadToEnd();
        }

        Shops = JsonConvert.DeserializeObject<JsonShops.AllShops>(json);
        Console.WriteLine();

        foreach (var shop in Shops.Shops)
        {
            shop.Report();
        }

        var chosenPhone = Shops.FindPhone();
        var chosenShop = Shops.ChooseShop(chosenPhone);

        var selectedPhone = FoundPhones.Find(p => p.Model == chosenPhone && p.ShopId == chosenShop.Id);

        var order = new JsonShops.Order(selectedPhone, chosenShop);
        var json2 = JsonConvert.SerializeObject(order);
        using (StreamWriter file = File.CreateText(@"D:\order.txt"))
        {
            file.Write(json2);
            file.Close();
        }
    }
}
