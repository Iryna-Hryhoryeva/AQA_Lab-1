namespace Task2_1;

public class RandomUtils
{
    public static string GetRandomTime()
    {
        var randomTime = new Random();
        var hour = randomTime.Next(8, 20);
        var minute = randomTime.Next(0, 59);
        var time = $"{hour,2}:{minute,2}".Replace(" ", "0");
        return time;
    }
}
