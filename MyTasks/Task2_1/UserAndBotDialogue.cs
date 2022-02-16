
Console.WriteLine("Здравствуйте! Введите Ваше имя:");
var userName = Console.ReadLine();

while (char.IsLower(userName, 0))
{
    Console.WriteLine("Пожалуйста, введите имя с заглавной буквы:");    // "обработка" неправильного пользовательского ввода
    userName = Console.ReadLine();
}

foreach (var symbol in userName)   // где-то в этом блоке баг: если первый ввод некорректный, то идет
                                    // бесконечный вывод "Имя должно состоять из букв" в ответ
                                    // как на последующий некорректный ввод, так и на корректный.
{
    while (char.IsNumber(symbol) || char.IsPunctuation(symbol) || char.IsWhiteSpace(symbol))
    {
        Console.WriteLine("Имя должно состоять из букв.");
        userName = Console.ReadLine();
    }
}

Console.WriteLine("Введите Вашу фамилию:");
var userSurname = Console.ReadLine();

while (char.IsLower(userSurname, 0))
{
    Console.WriteLine("Пожалуйста, введите фамилию с заглавной буквы:");    // "обработка" неправильного пользовательского ввода
    userSurname = Console.ReadLine();
}

foreach (var symbol in userSurname)    //где-то в этом блоке баг: смотри строки 10-12
{
    while (char.IsNumber(symbol) || char.IsPunctuation(symbol) || char.IsWhiteSpace(symbol))
    {
        Console.WriteLine("Фамилия должна состоять из букв.");
        userSurname = Console.ReadLine();
    }
}

Console.WriteLine("Введите дату приема в формате дд/мм/гггг:");
var date = new DateTime();
date = DateTime.Parse(Console.ReadLine());

var currentDate = new DateTime();
currentDate = DateTime.Today;
var comparisonResult = DateTime.Compare(date, currentDate); // Проверка ввода даты приема.
                                                            // Если пользователь ввел дату из прошлого, то выводится сообщение
                                                            // с просьбой ввести дату повторно.
while (comparisonResult < 0)
{
    Console.WriteLine("Пожалуйста, введите актуальную дату:");
    date = DateTime.Parse(Console.ReadLine());
    break;
}

var randomTime = new Random();   // {время} - рандомная генерация
var hour = randomTime.Next(8, 20);
var minute = randomTime.Next(0, 59);

Console.WriteLine($"{userName} {userSurname}, Вы записаны на прием {date.ToString("d")}, {hour}:{minute}");
