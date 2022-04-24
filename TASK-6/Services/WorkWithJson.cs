using Newtonsoft.Json;
using TASK_6.Utils;
using TASK_6.Models;

namespace TASK_6.Services;

public class WorkWithJson
{
    public static ListOfShopsFromJson ListOfShopsFromJson { get; set; }

    public static void GetDataFromJson()
    {
        try
        {
            const string pathForData = "Data/appsettings.json";
            using (var streamReader = new StreamReader(pathForData))
            {
                var json = streamReader.ReadToEnd();
                ListOfShopsFromJson = JsonConvert.DeserializeObject<ListOfShopsFromJson>(json);
                if (ListOfShopsFromJson == null)
                {
                    throw new Exception();
                }
            }
        }
        catch (Exception exception)
        {
            Log.Warn($"Возникла ошибка {exception.GetType()}: {exception.Message}");
        }
    }

    public static void CreateReceipt(Phone selectedPhone, Shop selectedShop)
    {
        var receipt = new Receipt(selectedPhone, selectedShop.Name, selectedShop.Description);
        var json = JsonConvert.SerializeObject(receipt);
        const string pathForReceipt = "Data/receipt.txt";
        using (var file = File.CreateText(pathForReceipt))
        {
            file.Write(json);
            file.Close();
            Log.Info("Товар Вы можете забрать в пункте самовывоза по чеку ниже. " +
                     $"Благодарим за выбор нашего сервиса!\n{json}");
        }
    }
}
