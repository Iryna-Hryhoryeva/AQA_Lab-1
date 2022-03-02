using NLog;

namespace TASK_6;

[Serializable]
public class JsonShops
{
    public class Order
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Guid Id;

        public Phone Phone;

        public Shop Shop;

        public Order(Phone phone, Shop shop)
        {
            Id = Guid.NewGuid();
            Phone = phone;
            Shop = shop;
            logger.Info($"Заказ {Phone.Model} на сумму {Phone.Price} успешно оформлен!");
        }
    }

    public class Phone
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string Model { get; set; }

        public string OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public string Price { get; set; }

        public bool IsAvailable { get; set; }

        public int ShopId { get; set; }

        public void Report()
        {
            logger.Info(
                $"Модель: {Model}, тип ОС: {OperationSystemType}, дата выпуска: {MarketLaunchDate}, " +
                $"стоимость: {Price}, магазин: {Program.shops.ShopByNumber(ShopId)}\n");
        }
    }

    public class Shop
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Phone> Phones { get; set; }

        public int CountPhonesWithOsType(string osType)
        {
            var foundPhones = Phones.FindAll(p => p.OperationSystemType == osType && p.IsAvailable);
            var numberOfPhones = foundPhones.Count();

            return numberOfPhones;
        }

        public void Report()
        {
            logger.Info(
                "\nМагазин №{0} {1} - {2}.\nКоличество устройств IOS в наличии: {3}\nКоличество устройств Android в наличии: {4}\n",
                Id, Name, Description, CountPhonesWithOsType("IOS"), CountPhonesWithOsType("Android"));
        }
    }

    public class AllShops
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<Shop> Shops { get; set; }


        public string ShopByNumber(int shopId)
        {
            var shop = Shops.Find(s => s.Id == shopId);
            return shop.Name;
        }

        public Shop ChooseShop(string phoneChoice)
        {
            string shopChoice;

            do
            {
                logger.Info($"В каком магазине вы хотите приобрести {phoneChoice}?");
                shopChoice = Console.ReadLine();
                var foundShop = Shops.Find(s => s.Name == shopChoice);
                if (foundShop != null)
                {
                    return foundShop;
                }

                logger.Info("Такого магазина не существует.");
                try
                {
                    throw new StoreNotFoundException(message: "Пожалуйста, введите название магазина заново:");
                }
                catch (Exception e)
                {
                    logger.Info(e);
                }
            } while (true);
        }

        public string FindPhone()
        {
            string phoneChoice;
            var found = new List<Phone>();
            var phone = new Phone();
            do
            {
                try
                {
                    logger.Info("Какой телефон вы желаете приобрести? ");
                    phoneChoice = Console.ReadLine();

                    foreach (var shop in Shops)
                    {
                        phone = shop.Phones.Find(p => p.Model == phoneChoice);
                        if (phone != null)
                        {
                            found.Add(phone);
                        }
                    }

                    Program.foundPhones = found;

                    if (Program.foundPhones.Count == 0)
                    {
                        logger.Info("Введенный Вами товар не найден");
                    }

                    var inStorage = Program.foundPhones.Find(p => p.IsAvailable);

                    if (inStorage == null)
                    {
                        logger.Info("Данный товар отсутствует на складе.");
                        throw new PhoneNotFoundException("Пожалуйста, введите модель телефона заново.");
                    }
                    else
                    {
                        var successfulRequest = Program.foundPhones.FindAll(p => p.IsAvailable);
                        successfulRequest.ForEach(p => p.Report());

                        break;
                    }
                }
                catch (Exception e)
                {
                    logger.Info(e.Message);
                }
            } while (true);

            return phoneChoice;
        }
    }
}
