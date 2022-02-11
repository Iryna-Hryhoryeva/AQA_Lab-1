// See https://aka.ms/new-console-template for more information

/* Имитация конвертации валют.

Задача: Выполнить конвертацию USD, EUR, RUB - обязательно, другие валюты по желанию.
Используйте данные для определения курса валют из https://www.nbrb.by/statistics/rates/ratesdaily.asp.

    Пользователь вводит сумму, которую он хочет конвертировать. Например: “1000 USD” (см.п.1)
    Выбирает валюту конвертации. Например: "RUB".
    Видим сумму вывода на консоли "76 157.56 RUB", 
    округление до 2-ого знака после запятой + 3% снял банк за операцию от первоначальной суммы.

1 - Обработать строковый ввод суммы "one thousand USD" вместо “1000 USD”.
*/

Console.WriteLine("Здравствуйте! Введите сумму, которую хотите конвертировать. Например: 1000");
double moneyAmount;
moneyAmount = double.Parse(Console.ReadLine());

Console.WriteLine("Выберите валюту конвертации: USD, EUR, RUB, CAD");
string currencyName = Console.ReadLine();
double sum;
if (currencyName == "USD")
{
    sum = moneyAmount / 2.5712;
    double round = Math.Round(sum, 2, MidpointRounding.ToEven);
    double result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else if (currencyName == "EUR")
{
    sum = moneyAmount / 2.9314;
    double round = Math.Round(sum, 2, MidpointRounding.ToEven);
    double result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else if (currencyName == "RUB")
{
    sum = moneyAmount / 0.034155;
    double round = Math.Round(sum, 2, MidpointRounding.ToEven);
    double result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else if (currencyName == "CAD")
{
    sum = moneyAmount / 2.0256;
    double round = Math.Round(sum, 2, MidpointRounding.ToEven);
    double result = round - (moneyAmount * 0.03);
    Console.WriteLine(result + " " + currencyName);
}
else
    Console.WriteLine("Неизвестная валюта.");