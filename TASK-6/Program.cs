using TASK_6.Models;
using TASK_6.Services;

namespace TASK_6;

public class Program
{
    public static void Main(string[] args)
    {
        var listOfShopsFromJson = new ListOfShopsFromJson();
        JsonDeserializer.GetDataFromJson(ref listOfShopsFromJson);
        ShopLogic.ShowShopInfo(listOfShopsFromJson);
        var dataForReceipt = ShopLogic.SelectPhone(listOfShopsFromJson);
        ShopLogic.ConfirmOrderSuccessfullyPlaced(dataForReceipt.Item1);
        ShopLogic.CreateReceipt(dataForReceipt.Item1, dataForReceipt.Item2);
    }
}
