using Bogus;

namespace Task5;

public class Menu
{
    private static int _menuChoice;
    private static int _selectedNumberOfCustomer;
    private static string _header = string.Format("№№ | {0,20} | {1,30} | {2,10} | {3} ", "Категория", "Наименование",
        "Стоимость", "Идентификационный номер");
    private static string _line = "\n" + new string('-', _header.Length);

    public static void Implementor(List<Ware> wares, List<Customer> users)
    {
        do
        {
            ShowMenuOptions();
            switch (_menuChoice)
            {
                case 1:
                    ShowListOfAllCustomers(users);

                    break;

                case 2:
                    Console.WriteLine("Выберите номер покупателя (1-" + ShopLogic.NumberOfCustomers + "): ");
                    ShowListOfAllCustomers(users);
                    Console.Write("Ваш выбор: ");
                    _selectedNumberOfCustomer = Convert.ToInt16(Console.ReadLine());

                    var customerWares = ShowWaresOfADefiniteCustomer(_selectedNumberOfCustomer, users);
                    ShowTotalSumOfWares(_line, customerWares);

                    break;

                case 3:
                    var newListOfCustomers = AddNewCustomerToList(users);
                    users = newListOfCustomers;

                    break;

                case 4:
                    Console.WriteLine(
                        "Введите номер покупателя, которому Вы хотите добавить/удалить товар из корзины: ");
                    ShowListOfAllCustomers(users);
                    Console.Write("Ваш выбор: ");
                    _selectedNumberOfCustomer = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Добавить (1) или удалить (2)? ");
                    var addOrRemove = Convert.ToInt16(Console.ReadLine());
                    switch (addOrRemove)
                    {
                        case 1:
                            AddWare(wares, users, _selectedNumberOfCustomer);

                            break;

                        case 2:
                            RemoveWare(users, _selectedNumberOfCustomer);

                            break;

                        default:
                            Console.WriteLine("\nНеизвестный номер.");

                            break;
                    }

                    break;

                case 0:
                    Console.WriteLine("Выхожу...");

                    break;

                default:
                    Console.WriteLine("\nНеизвестный номер.");

                    break;
            }
        } while (_menuChoice != 0);
    }

    private static List<Customer> AddNewCustomerToList(List<Customer> users)
    {
        Console.Write("Введите номер паспорта: ");
        var passportNumberOfCustomer = Console.ReadLine();
        while (passportNumberOfCustomer.Length != new Faker().Finance.Account().Length)
        {
            Console.Write($"Номер паспорта должен составлять {new Faker().Finance.Account().Length} цифр. " +
                          $"Пожалуйста, введите корректный номер паспорта: ");
            passportNumberOfCustomer = Console.ReadLine();
        }

        Console.Write("Введите имя покупателя: ");
        var nameOfCustomer = Console.ReadLine();

        const string okMessage = "Введите возраст покупателя: ";
        const string errorMessage = "Вы ввели некорректный возраст. Попробуйте еще раз: ";
        var ageOfCustomer = 0;
        var ageIsOkay = true;
        do
        {
            try
            {
                Console.Write(ageIsOkay ? okMessage : errorMessage);
                ageOfCustomer = Convert.ToInt16(Console.ReadLine());
                ageIsOkay = ageOfCustomer >= Customer.MinimumAge && ageOfCustomer <= Customer.MaximumAge;
                if (!ageIsOkay)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                ageIsOkay = false;
            }
        } while (!ageIsOkay);

        var newCustomer = new Customer(passportNumberOfCustomer, nameOfCustomer, ageOfCustomer, new Cart());

        var found = users.Where(u => u.Equals(newCustomer)).Count() > 0;
        if (found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Покупатель не добавлен, т.к. такой уже существует.\n");
            Console.ResetColor();
        }
        else
        {
            users.Add(newCustomer);
            Console.WriteLine("Добавлен новый пользователь.\n");
        }

        return users;
    }

    private static void ShowListOfAllCustomers(List<Customer> users)
    {
        Console.WriteLine($"№№ ▐ {"Имя",20} ▐ {"Возраст",7} ▐ {"Номер паспорта"}");
        for (var i = 0; i < users.Count(); i++)
        {
            Console.WriteLine("{3,2} ▐ {0,20} ▐ {1,7} ▐ {2}", users.ElementAt(i).Name,
                users.ElementAt(i).Age, users.ElementAt(i).PassportId, i + 1);
        }

        Console.WriteLine();
    }

    private static void ShowMenuOptions()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Просмотреть всех покупателей");
        Console.WriteLine("2. Просмотреть товары определенного покупателя с итоговой суммой всех товаров в корзине");
        Console.WriteLine("3. Добавить нового покупателя с консоли");
        Console.WriteLine("4. Добавить/удалить товар из корзины");
        Console.WriteLine("0. Выход");
        Console.Write("Выберите 0-4: ");
        _menuChoice = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine();
    }

    private static void ShowTotalSumOfWares(string line, List<Ware> customerWares)
    {
        Console.WriteLine(line + "\nИтоговая сумма: " + customerWares.Sum(w => Convert.ToDouble(w.Price)) + line);
        Console.WriteLine();
    }

    private static List<Ware> ShowWaresOfADefiniteCustomer(int selectedNumberOfCustomer, List<Customer> users)
    {
        var customerWares = users.ElementAt(selectedNumberOfCustomer - 1).Cart.Wares;

        Console.WriteLine(_header + _line);
        for (var i = 0; i < customerWares.Count(); i++)
        {
            Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ", customerWares[i].Category,
                customerWares[i].Name,
                customerWares[i].Price, customerWares[i].Id, i + 1);
        }

        return customerWares;
    }

    private static void AddWare(List<Ware> wares, List<Customer> users, int _selectedNumberOfCustomer)
    {
        for (var i = 0; i < wares.Count(); i++)
        {
            Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ",
                wares.ElementAt(i).Category,
                wares.ElementAt(i).Name,
                wares.ElementAt(i).Price, wares.ElementAt(i).Id, i + 1);
        }

        Console.Write("Введите номер товара в магазине: ");
        var wareNumberInShop = Convert.ToInt16(Console.ReadLine());
        if (wares.ElementAt(wareNumberInShop - 1).Category == "Alcohol" &&
            users.ElementAt(_selectedNumberOfCustomer - 1).Age < 18)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Продажа алкоголя осуществляется после наступления 18 лет.");
            Console.ResetColor();
        }
        else
        {
            users.ElementAt(_selectedNumberOfCustomer - 1).AddWare(wares.ElementAt(wareNumberInShop - 1));
            Console.WriteLine("Товар успешно добавлен.\n");
        }
    }

    private static void RemoveWare(List<Customer> users, int _selectedNumberOfCustomer)
    {
        Console.WriteLine("Введите номер товара в корзине: ");
        for (var i = 0; i < users.ElementAt(_selectedNumberOfCustomer - 1).Cart.Wares.Count(); i++)
        {
            Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ",
                users.ElementAt(_selectedNumberOfCustomer - 1).Cart.Wares.ElementAt(i).Category,
                users.ElementAt(_selectedNumberOfCustomer - 1).Cart.Wares.ElementAt(i).Name,
                users.ElementAt(_selectedNumberOfCustomer - 1).Cart.Wares.ElementAt(i).Price,
                users.ElementAt(_selectedNumberOfCustomer - 1).Cart.Wares.ElementAt(i).Id, i + 1);
        }

        Console.Write("Ваш выбор: ");
        var wareNumberChoice = Convert.ToInt16(Console.ReadLine());

        users.ElementAt(_selectedNumberOfCustomer - 1).Cart.Wares.RemoveAt(wareNumberChoice - 1);
        Console.WriteLine("Товар успешно удален.\n");
    }
}
