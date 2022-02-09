// See https://aka.ms/new-console-template for more information

/*  Чат-бот для записи на прием.

    Задача: имитировать “диалог” пользователя и бота через консоль.

    Пример диалога:
    Бот: Здравствуйте! Введите вашу фамилию.
    Пользователь: Иванов. 
    Бот: Введите ваше имя.
    Пользователь: Иван (см.п.1).
    Бот: Введите дату приема в формате дд/мм/гггг (или выбираете из C# и .NET | Работа с датами и временем ).
    Пользователь: пользователь вводит дату	(см.п.2).
    Бот: {Имя} {Фамилия}, Вы записаны на прием {дата}. (см.п.3).

    1 - Сделать обработку неправильного пользовательского ввода: регистр (“иван”->”Иван”) 
    или недопустимый символ (“Иван18670ов” -> “Иванов”).
    2 - Добавить валидацию даты на степе ввода даты приема. Если пользователь ввел дату из прошлого, 
    то выводится сообщение с просьбой ввести дату повторно.
    3 - Бот: {Имя} {Фамилия}, Вы записаны на прием {дата} {время}.
    {время} - рандомная генерация
*/

Console.WriteLine("Здравствуйте! Введите Ваше имя:");
string userName = Console.ReadLine();

while (Char.IsLower(userName, 0))
{
    Console.WriteLine("Пожалуйста, введите имя с заглавной буквы:");    // "обработка" неправильного пользовательского ввода
    userName = Console.ReadLine();
}

foreach (Char symbol in userName)   // где-то в этом блоке баг: если первый ввод некорректный, то идет
                                    // бесконечный вывод "Имя должно состоять из букв" в ответ
                                    // как на последующий некорректный ввод, так и на корректный.
{
    while (Char.IsNumber(symbol) || Char.IsPunctuation(symbol) || Char.IsWhiteSpace(symbol))
    {
        Console.WriteLine("Имя должно состоять из букв.");
        userName = Console.ReadLine();
    }
}

Console.WriteLine("Введите Вашу фамилию:");
string userSurname = Console.ReadLine();
while (Char.IsLower(userSurname, 0))
{
    Console.WriteLine("Пожалуйста, введите фамилию с заглавной буквы:");    // "обработка" неправильного пользовательского ввода
    userSurname = Console.ReadLine();
}

foreach (Char symbol in userSurname)    //где-то в этом блоке баг: смотри строки 33-35
{
    while (Char.IsNumber(symbol) || Char.IsPunctuation(symbol) || Char.IsWhiteSpace(symbol))
    {
        Console.WriteLine("Фамилия должна состоять из букв.");
        userSurname = Console.ReadLine();
    }
}

Console.WriteLine("Введите дату приема в формате дд/мм/гггг:");
DateTime date = new DateTime();
date = DateTime.Parse(Console.ReadLine());

DateTime currentDate = new DateTime();
currentDate = DateTime.Today;
int comparisonResult = DateTime.Compare(date, currentDate); // Проверка ввода даты приема.
                                                            // Если пользователь ввел дату из прошлого, то выводится сообщение
                                                            // с просьбой ввести дату повторно.
while (comparisonResult < 0)
{
    Console.WriteLine("Пожалуйста, введите актуальную дату:");
    date = DateTime.Parse(Console.ReadLine());
    break;
}

Random randomTime = new Random();   // {время} - рандомная генерация
int hour = randomTime.Next(8, 20);
int minute = randomTime.Next(0, 59);

Console.WriteLine($"{userName} {userSurname}, Вы записаны на прием {date.ToString("d")}, {hour}:{minute}");