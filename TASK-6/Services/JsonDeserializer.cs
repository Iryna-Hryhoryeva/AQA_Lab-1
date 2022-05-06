using Newtonsoft.Json;
using TASK_6.Utils;
using TASK_6.Models;

namespace TASK_6.Services;

public class JsonDeserializer
{
    private static readonly string _pathForData = $"Data{Path.DirectorySeparatorChar}appsettings.json";
    private static ListOfShops _listOfShops = new ();
    
    public static ListOfShops GetShops()
    {
        try
        {
            using (var streamReader = new StreamReader(_pathForData))
            {
                var json = streamReader.ReadToEnd();
                _listOfShops = JsonConvert.DeserializeObject<ListOfShops>(json);
                if (_listOfShops == null)
                {
                    throw new Exception();
                }
            }
        }
        catch (Exception exception)
        {
            Log.Warn($"Возникла ошибка {exception.GetType()}: {exception.Message}");
        }

        return _listOfShops;
    }
}
