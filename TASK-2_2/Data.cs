namespace Task2_2;

public static class Data
{
    private const double UsdRatio = 2.7977;
    private const double EurRatio = 3.1375;
    private const double RubRatio = 3.2391 / 100;

    public static double GetRatio(string name)
    {
        if (Enum.TryParse(name, out Currency enumName))
        {
            switch ((int) enumName)
            {
                case 0: return UsdRatio;
                case 1: return EurRatio;
                case 2: return RubRatio;
            }
        }
        else
        {
            Console.WriteLine("Неверная валюта.");
            return 0;
        }

        throw new InvalidOperationException();
    }
}
