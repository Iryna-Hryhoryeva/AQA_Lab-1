using Task2_1;

var ticket = new Chatbot();

// Ввод и обработка неправильного пользовательского ввода фамилии.
ticket.UserSurname = Chatbot.InputName(1);

// Ввод и обработка неправильного пользовательского ввода имени.
ticket.UserName = Chatbot.InputName(2);

// Ввод и валидация ввода даты приема. Если пользователь ввел дату из прошлого, то выводится сообщение с просьбой ввести дату повторно.
ticket.Date = Chatbot.InputDate();

// Рандомная генерация времени.
var time = RandomUtils.GetRandomTime();

// Вывод данных о записи пациента.
Chatbot.ShowResult(ticket, time);
