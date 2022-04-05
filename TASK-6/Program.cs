using Newtonsoft.Json;

namespace TASK_6;

public static class Program
{
    private static JsonShops _shops;
    private static List<Phone> _foundPhones;

    public static JsonShops JsonShops { get => _shops; set => _shops = value; }
    public static List<Phone> FoundPhones { get => _foundPhones; set => _foundPhones = value; }

    public static void Main(string[] args)
    {
        string json;
        using (var streamReader = new StreamReader("appsettings.json"))
        {
            json = streamReader.ReadToEnd();
        }
        
        JsonShops = JsonConvert.DeserializeObject<JsonShops>(json);
        Console.WriteLine();

        foreach (var shop in JsonShops.Shops)
        {
            shop.Report();
        }

        var chosenPhone = JsonShops.FindPhone();
        var chosenShop = JsonShops.ChooseShop(chosenPhone);
        var selectedPhone = FoundPhones.Find(p => p.Model == chosenPhone && p.ShopId == chosenShop.Id);

        var order = new Order(selectedPhone, chosenShop);
        var json2 = JsonConvert.SerializeObject(order);
        using (StreamWriter file = File.CreateText(@"D:\order.txt"))
        {
            file.Write(json2);
            file.Close();
        }
    }
}
