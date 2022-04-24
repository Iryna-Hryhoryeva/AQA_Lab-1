using TASK_6.Services;

namespace TASK_6;

public class Program
{
    public static void Main(string[] args)
    {
        WorkWithJson.GetDataFromJson();
        ShopLogic.ShowShopInfo();
        var dataForReceipt = ShopLogic.SelectPhone();
        ShopLogic.ConfirmOrderSuccessfullyPlaced(dataForReceipt.Item1);
        WorkWithJson.CreateReceipt(dataForReceipt.Item1, dataForReceipt.Item2);
    }
}
