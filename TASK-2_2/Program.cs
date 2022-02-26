using Task2_2;

Console.Write("Здравствуйте! ");

//Ввод суммы в исходной валюте и получение коэффициента
while (CurrencyConverter.GetInputData() == 1)
{
    // Назначение валюты обмена и получение коэффициента
    CurrencyConverter.ChooseTargetCurrency();

    // расчет итоговой суммы с учетом снятых процетнов
    CurrencyConverter.ShowResult();
}
