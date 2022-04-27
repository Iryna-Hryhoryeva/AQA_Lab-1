using Newtonsoft.Json;
using TASK_6.Utils;
using TASK_6.Models;

namespace TASK_6.Services;

public class JsonDeserializer
{
    public static void GetDataFromJson(ref ListOfShopsFromJson listOfShopsFromJson)
    {
        try
        {
            var pathForData = $"Data{Path.DirectorySeparatorChar}appsettings.json";
            using (var streamReader = new StreamReader(pathForData))
            {
                var json = streamReader.ReadToEnd();
                listOfShopsFromJson = JsonConvert.DeserializeObject<ListOfShopsFromJson>(json);
                if (listOfShopsFromJson == null)
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
}
