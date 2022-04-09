namespace TASK_4.Utils;

public static class RandomUtils
{
    private static Random _random = new Random();
    public static int NumberOfObjects = _random.Next(5, 20);
}
