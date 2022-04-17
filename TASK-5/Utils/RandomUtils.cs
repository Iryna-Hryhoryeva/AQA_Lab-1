namespace Task5.Utils;

public class RandomUtils
{
    private static Random _randomNumber = new();

    public static int GetRandomNumber()
    {
        return _randomNumber.Next(2, 20);
    }

    public static int GetRandomWareIndex(IEnumerable<Ware> wares)
    {
        return _randomNumber.Next(wares.Count() - 1);
    }
}
