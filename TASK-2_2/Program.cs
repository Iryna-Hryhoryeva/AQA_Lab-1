namespace Task2_2;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Здравствуйте! ");

        while (CurrencyConverter.GetInputData() == 1)
        {
            CurrencyConverter.ChooseTargetCurrency();
            CurrencyConverter.ShowResult();
        }
    }
}
