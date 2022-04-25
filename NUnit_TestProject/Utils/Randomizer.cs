using NUnit.Framework;

namespace NUnit_TestProject.Utils;

public class Randomizer
{
    private static (int, int) _lesserInt = (0, 100);
    private static (int, int) _greaterInt = (101, 200);
    private static (double, double) _lesserDouble = (10, 20);
    private static double _greaterDouble = 100;

    public static int GetLesserRandomIntValue()
    {
        return TestContext.CurrentContext.Random.Next(_lesserInt.Item1, _lesserInt.Item2);
    }

    public static int GetGreaterRandomIntValue()
    {
        return TestContext.CurrentContext.Random.Next(_greaterInt.Item1, _greaterInt.Item2);
    }

    public static double GetLesserRandomDoubleValue()
    {
        return TestContext.CurrentContext.Random.NextDouble(_lesserDouble.Item1, _lesserDouble.Item2);
    }

    public static double GetGreaterRandomDoubleValue()
    {
        return TestContext.CurrentContext.Random.NextDouble(_greaterDouble);
    }
}
