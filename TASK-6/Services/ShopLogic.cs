using Newtonsoft.Json;
using TASK_6.Exceptions;
using TASK_6.Models;
using TASK_6.Models.Enums;
using TASK_6.Utils;

namespace TASK_6.Services;

public class ShopLogic
{
    private static readonly string _pathForReceipt = $"Data{Path.DirectorySeparatorChar}receipt.txt";
    private static List<Phone> _foundPhones;

    public static void ShowShopInfo(ListOfShops listOfShops)
    {
        foreach (var shop in listOfShops.Shops)
        {
            ReportShops(shop);
        }
    }

    private static void ReportShops(Shop shop)
    {
        Log.Info(
            $"Магазин №{shop.Id} {shop.Name} - {shop.Description}." +
            "\nКоличество устройств IOS в наличии: " +
            $"{CountPhonesWithOsType(shop, OsTypes.IOS)}\nКоличество устройств Android в наличии: " +
            $"{CountPhonesWithOsType(shop, OsTypes.Android)}\n");
    }

    private static int CountPhonesWithOsType(Shop shop, OsTypes osType)
    {
        var foundPhones = shop.Phones.FindAll(phone =>
            phone.IsAvailable &&
            phone.OperationSystemType == (osType == OsTypes.IOS ? "IOS" : "Android"));

        return foundPhones.Count();
    }

    private static void ReportFoundPhones(List<Phone> foundPhones, ListOfShops listOfShops)
    {
        foreach (var foundPhone in foundPhones)
        {
            Log.Info(
                $"Модель: {foundPhone.Model}, тип ОС: {foundPhone.OperationSystemType}, " +
                $"дата выпуска: {foundPhone.MarketLaunchDate}, " +
                $"стоимость: {foundPhone.Price}, магазин: {ShowShopNameByNumber(foundPhone.ShopId, listOfShops)}");
        }
    }

    private static string ShowShopNameByNumber(int shopId, ListOfShops listOfShops)
    {
        var shop = listOfShops.Shops.Find(shop => shop.Id == shopId);

        return shop.Name;
    }

    public static Tuple<Phone, Shop> SelectPhone(ListOfShops listOfShops)
    {
        var selectedPhoneModelAvailableInAllShops = FindPhoneModelCustomerRequests(listOfShops);
        var selectedShop = SelectShop(selectedPhoneModelAvailableInAllShops, listOfShops);
        var selectedPhone = _foundPhones.Find(p =>
            p.Model == selectedPhoneModelAvailableInAllShops && p.ShopId == selectedShop.Id);

        return Tuple.Create(selectedPhone, selectedShop);
    }

    private static string FindPhoneModelCustomerRequests(ListOfShops listOfShops)
    {
        string selectedPhoneModel;
        var foundPhones = new List<Phone>();
        Phone foundPhoneOfSelectedModel;
        do
        {
            try
            {
                Log.Info("Какой телефон вы желаете приобрести? ");
                selectedPhoneModel = Console.ReadLine();
                Log.Debug(selectedPhoneModel);
                foreach (var shop in listOfShops.Shops)
                {
                    foundPhoneOfSelectedModel = shop.Phones.Find(phone => phone.Model == selectedPhoneModel);
                    if (foundPhoneOfSelectedModel != null)
                    {
                        foundPhones.Add(foundPhoneOfSelectedModel);
                    }
                }

                _foundPhones = foundPhones;
                if (_foundPhones.Count == 0)
                {
                    Log.Info("Введенный Вами товар не найден");
                }

                var phoneInStorage = _foundPhones.Find(phone => phone.IsAvailable);
                if (phoneInStorage == null)
                {
                    Log.Info("Данный товар отсутствует на складе.");

                    throw new PhoneNotFoundException("Пожалуйста, введите модель телефона заново.");
                }
                else
                {
                    var successfulPhoneRequest = _foundPhones.FindAll(phone => phone.IsAvailable);
                    ReportFoundPhones(successfulPhoneRequest, listOfShops);

                    break;
                }
            }
            catch (Exception exception)
            {
                Log.Warn(exception.Message);
            }
        } while (true);

        return selectedPhoneModel;
    }

    private static Shop SelectShop(string selectedPhoneModelCanBeAvailableInAllShops, ListOfShops listOfShops)
    {
        string selectedShopName;
        do
        {
            Log.Info($"В каком магазине вы хотите приобрести {selectedPhoneModelCanBeAvailableInAllShops}?");
            selectedShopName = Console.ReadLine();
            Log.Debug(selectedShopName);

            var foundShop = listOfShops.Shops.Find(
                shop => shop.Name == selectedShopName && 
                        shop.Phones.Find(phone => phone.Model == selectedPhoneModelCanBeAvailableInAllShops) != null);
            if (foundShop != null)
            {
                return foundShop;
            }

            try
            {
                throw new StoreNotFoundException( "Пожалуйста, введите корректное название магазина.");
            }
            catch (Exception exception)
            {
                Log.Warn(exception.Message);
            }
        } while (true);
    }

    public static void ConfirmOrderSuccessfullyPlaced(Phone selectedPhone)
    {
        Log.Info($"Заказ {selectedPhone.Model} на сумму {selectedPhone.Price} успешно оформлен!");
    }
    
    public static void CreateReceipt(Phone selectedPhone, Shop selectedShop)
    {
        var receipt = new Receipt(selectedPhone, selectedShop.Name, selectedShop.Description);
        var json = JsonConvert.SerializeObject(receipt);
        
        using (var file = File.CreateText(_pathForReceipt))
        {
            file.Write(json);
            file.Close();
            Log.Info("Товар Вы можете забрать в пункте самовывоза по чеку ниже. " +
                     $"Благодарим за выбор нашего сервиса!\n{json}");
        }
    }
}
