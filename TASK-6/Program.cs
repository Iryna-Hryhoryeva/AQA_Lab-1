using Newtonsoft.Json;

namespace TASK_6;

public class Program
{
    public static JsonShops.AllShops shops;

    public static List<JsonShops.Phone> foundPhones;

    public static void Main(string[] args)
    {
        string json;
        using (var streamReader = new StreamReader("appsettings.json"))
        {
            json = streamReader.ReadToEnd();
        }

        shops = JsonConvert.DeserializeObject<JsonShops.AllShops>(json);
        Console.WriteLine();

        foreach (var shop in shops.Shops)
        {
            shop.Report();
        }

        var chosenPhone = shops.FindPhone();
        var chosenShop = shops.ChooseShop(chosenPhone);

        var selectedPhone = foundPhones.Find(p => p.Model == chosenPhone && p.ShopId == chosenShop.Id);

        var order = new JsonShops.Order(selectedPhone, chosenShop);
        var json2 = JsonConvert.SerializeObject(order);
        using (StreamWriter file = File.CreateText(@"D:\order.txt"))
        {
            file.Write(json2);
            file.Close();
        }
    }
}
