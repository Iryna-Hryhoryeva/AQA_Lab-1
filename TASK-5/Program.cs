namespace Task5;

public class Program
{
    public static void Main(string[] args)
    {
        const int numberOfCustomers = 5;

        var repository = new BogusRepository();
        var listOfWares = new List<Ware>();

        for (var i = 0; i < numberOfCustomers; i++)
        {
            var ware = new Ware();
            listOfWares.Add(ware);
        }

        var wares = repository.GetWares(listOfWares);
        var randomNumber = new Random();
        var carts = new List<Cart>();

        for (var i = 0; i < numberOfCustomers; i++)
        {
            carts.Add(new Cart());
            for (var j = 0; j < randomNumber.Next(2, 20); j++)
            {
                carts[i].Wares.Add(wares.ElementAt(randomNumber.Next(wares.Count() - 1)));
            }
        }

        var listOfCustomers = new List<Customer>();

        for (var i = 0; i < numberOfCustomers; i++)
        {
            var customer = new Customer();
            listOfCustomers.Add(customer);
        }

        var users = repository.GetCustomers(listOfCustomers);

        for (var i = 0; i < numberOfCustomers; i++)
        {
            users.ElementAt(i).Cart = carts[i];
        }

        var menuChoice = "";
        var customerChoice = 0;

        do
        {
            Console.WriteLine($"Меню ({customerChoice}):");
            Console.WriteLine("1. Просмотреть всех покупателей");
            Console.WriteLine("2. Просмотреть товары определенного покупателя с итоговой суммой всех товаров в корзине");
            Console.WriteLine("3. Добавить нового покупателя с консоли");
            Console.WriteLine("4. Добавить/удалить товар из корзины");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите 0-4: ");
            menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    Console.WriteLine($"№№ ▐ {"Имя",20} ▐ {"Возраст",7} ▐ {"Номер паспорта"}");

                    for (var i = 0; i < users.Count(); i++)
                    {
                        Console.WriteLine("{3,2} ▐ {0,20} ▐ {1,7} ▐ {2}", users.ElementAt(i).Name, users.ElementAt(i).Age,
                            users.ElementAt(i).PassportId,
                            i + 1);
                    }
                    break;

                case "2":
                    Console.Write("Выберите номер покупателя (1-" + numberOfCustomers + "): ");
                    customerChoice = Convert.ToInt16(Console.ReadLine());

                    var customerWares = users.ElementAt(customerChoice - 1).Cart.Wares;
                    var header = string.Format("№№ | {0,20} | {1,30} | {2,10} | {3} ", "Категория", "Наименование", "Стоимость",
                        "Идентификационный номер");
                    var line = "\n" + new string('-', header.Length);

                    Console.WriteLine(header + line);

                    for (var i = 0; i < customerWares.Count(); i++)
                    {
                        Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ", customerWares[i].Category,
                            customerWares[i].Name,
                            customerWares[i].Price, customerWares[i].Id, i + 1);
                    }

                    Console.WriteLine(line + "\nИтоговая сумма: " + customerWares.Sum(w => Convert.ToDouble(w.Price)) + line);
                    break;

                case "3":
                    Console.Write("Введите номер паспорта: ");
                    var passportNumberOfCustomer = Console.ReadLine();

                    Console.Write("Введите имя покупателя: ");
                    var nameOfCustomer = Console.ReadLine();

                    Console.Write("Введите возраст покупателя: ");
                    var ageOfCustomer = Convert.ToInt16(Console.ReadLine());

                    var newCustomer = new Customer();
                    newCustomer.SetCustomer(passportNumberOfCustomer, nameOfCustomer, ageOfCustomer, new Cart());

                    var found = users.Where(u => u.Equals(newCustomer)).Count() > 0;

                    if (found)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Покупатель не добавлен, т.к. такой уже существует");
                        Console.ResetColor();
                    }
                    else
                    {
                        users.Append(newCustomer);

                        Console.WriteLine("Добавлен новый пользователь.");
                    }
                    break;

                case "4":
                    Console.Write("Добавить (1) или удалить (2)?");

                    switch (Console.ReadLine())
                    {
                        case "1":

                            for (var i = 0; i < wares.Count(); i++)
                            {
                                Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ", wares.ElementAt(i).Category,
                                    wares.ElementAt(i).Name,
                                    wares.ElementAt(i).Price, wares.ElementAt(i).Id, i + 1);
                            }

                            Console.Write("Введите номер товара в магазине: ");
                            var wareNumberInShop = Convert.ToInt16(Console.ReadLine());

                            if (wares.ElementAt(wareNumberInShop - 1).Category == "Alcohol" &&
                                users.ElementAt(customerChoice - 1).Age < 18)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Продажа алкоголя осуществляется после наступления 18 лет");
                                Console.ResetColor();
                            }
                            else
                            {
                                users.ElementAt(customerChoice - 1).AddWare(wares.ElementAt(wareNumberInShop - 1));
                            }
                            break;

                        case "2":
                            Console.Write("Введите номер товара в корзине: ");
                            var wareNumberChoice = Convert.ToInt16(Console.ReadLine());
                            users.ElementAt(customerChoice - 1).Cart.Wares.RemoveAt(wareNumberChoice - 1);
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Выхожу...");
                    break;
            }
        } while (menuChoice != "0");
    }
}
