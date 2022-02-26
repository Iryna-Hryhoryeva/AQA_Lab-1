namespace Task2_2;

public static class CurrencyConverter
{
    public static double MoneyAmount { get; set; }
    public static string UserInput { get; set; }

    public static double RatioIn { get; set; }
    public static double RatioOut { get; set; }
    public static string TargetCurrency { get; set; }

    public static double GetRatio(string name)
    {
        if (Enum.TryParse(name, out Currency.Name enumName))
        {
            return Data.Ratio[(int) enumName];
        }
        else
        {
            Console.WriteLine("Неверная валюта.");
            return 0;
        }
    }

    public static byte GetInputData()
    {
        double ratio = 0;
        do
        {
            Console.Write(
                "Введите сумму, которую хотите конвертировать. Например: 1000 USD (для выхода нажмите 0): ");

            UserInput = Console.ReadLine();
            if (UserInput == "0")
            {
                return 0;
            }

            var data = UserInput.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            MoneyAmount = double.Parse(data[0]);
            ratio = GetRatio(data[1]);
        } while (ratio == 0);

        RatioIn = ratio;
        return 1;
    }

    public static void ChooseTargetCurrency()
    {
        double ratio;
        do
        {
            Console.WriteLine("Выберите валюту конвертации: USD, EUR, RUB");
            TargetCurrency = Console.ReadLine();
            ratio = GetRatio(TargetCurrency);
        } while (ratio == 0);

        RatioOut = ratio;
    }

    public static void ShowResult()
    {
        var result = MoneyAmount * RatioIn / RatioOut;
        var rate = (MoneyAmount * 0.03) * RatioIn / RatioOut;
        result -= rate;
        result = Math.Round(result, 2);

        Console.WriteLine(result + " " + TargetCurrency);
    }
}
