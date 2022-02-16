
Console.WriteLine("Здравствуйте! Введите сумму, которую хотите конвертировать. Например: 1000");
double moneyAmount;
moneyAmount = double.Parse(Console.ReadLine());

Console.WriteLine("Выберите валюту конвертации: USD, EUR, RUB, CAD");
var currencyName = Console.ReadLine();
double sum;
if (currencyName == "USD")
{
    sum = moneyAmount / 2.5712;
    var round = Math.Round(sum, 2, MidpointRounding.ToEven);
    var result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else if (currencyName == "EUR")
{
    sum = moneyAmount / 2.9314;
    var round = Math.Round(sum, 2, MidpointRounding.ToEven);
    var result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else if (currencyName == "RUB")
{
    sum = moneyAmount / 0.034155;
    var round = Math.Round(sum, 2, MidpointRounding.ToEven);
    var result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else if (currencyName == "CAD")
{
    sum = moneyAmount / 2.0256;
    var round = Math.Round(sum, 2, MidpointRounding.ToEven);
    var result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else
{
    Console.WriteLine("Неизвестная валюта.");
}
