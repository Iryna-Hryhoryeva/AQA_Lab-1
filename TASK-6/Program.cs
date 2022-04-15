namespace TASK_6;

public class Program
{
    public static void Main(string[] args)
    {
        ShopLogic.GetDataFromJson();
        ShopLogic.ShowShopInfo();
        var dataForReceipt = ShopLogic.SelectPhone();
        ShopLogic.CreateReceipt(dataForReceipt.Item1, dataForReceipt.Item2);
    }
}
