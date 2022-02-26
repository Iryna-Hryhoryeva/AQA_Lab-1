Задача:

1. Считать данные с json файла в объекты, используя Json.NET. Обработать возможные исключения при чтении файла appsettings.json (скачать в свой проект).

2. Реализовать метод, который посчитает количество телефонов в магазине по OperationSystemType (ios, android) в наличие (isAvailable = true). Вывести в консоль всю информацию о магазине, ниже – количество устройств ios и android в наличие.

3. Вывести в консоль сообщение «Какой телефон вы желаете приобрести?». 

Пользователь вводит модель телефона, который хочет купить
• Если такого телефона нету ни в одном из магазинов, вывести сообщение об ошибке «Введенный Вами товар не найден». Попросить ввести модель телефона заново (PhoenNotFoundException).
• Если телефон недоступен (закончился на складе), вывести «Данный товар отсутствует на складе». Попросить ввести модель телефона заново.
• В случае успешного запроса (необходимая модель найдена), вывести все доступные телефоны с информацией о них и магазине, в котором можно приобрести телефон.

4. Вывести сообщение «В каком магазине вы хотите приобрести {PhoneModel}?». 

Ввести название магазина (StoreNotFoundException).
• Если магазина не существует, вывести сообщение об этом пользователю, предложить ввести название магазина заново.
• В случае успешного запроса вывести сообщение «Заказ {PhoneInformation} на сумму {PhonePrice} успешно оформлен!». Сгенерировать отдельный json file типа чека. 

5. Использовать логгер вместо Console.Write();
