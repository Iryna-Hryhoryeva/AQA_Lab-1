﻿using TASK_6.Services;

namespace TASK_6;

public class Program
{
    public static void Main(string[] args)
    {
        var listOfShopsFromJson = JsonDeserializer.GetShops();
        ShopLogic.ShowShopInfo(listOfShopsFromJson);
        var dataForReceipt = ShopLogic.SelectPhone(listOfShopsFromJson);
        ShopLogic.ConfirmOrderSuccessfullyPlaced(dataForReceipt.Item1);
        ShopLogic.CreateReceipt(dataForReceipt.Item1, dataForReceipt.Item2);
    }
}
