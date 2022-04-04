using NLog;
using TASK_6.Exceptions;

namespace TASK_6;

[Serializable]
public class JsonShops
{
    public class Order
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Guid _id;
        private Phone _phone;
        private Shop _shop;

        public Order(Phone phone, Shop shop)
        {
            Id = Guid.NewGuid();
            Phone = phone;
            Shop = shop;
            logger.Info($"Заказ {Phone.Model} на сумму {Phone.Price} успешно оформлен!");
        }
        
        public Guid Id { get => _id; set => _id = value; }
        public Phone Phone { get => _phone; set => _phone = value; }
        public Shop Shop { get => _shop; set => _shop = value; }
    }

    public class Phone
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string _model;
        private string _operationSystemType;
        private string _marketLaunchDate;
        private string _price;
        private bool _isAvailable;
        private int _shopId;

        public string Model { get => _model; set => _model = value; }
        public string OperationSystemType { get => _operationSystemType; set => _operationSystemType = value; }
        public string MarketLaunchDate { get => _marketLaunchDate; set => _marketLaunchDate = value; }
        public string Price { get => _price; set => _price = value; }
        public bool IsAvailable { get => _isAvailable; set => _isAvailable = value; }
        public int ShopId { get => _shopId; set => _shopId = value; }

        public void Report()
        {
            logger.Info(
                $"Модель: {Model}, тип ОС: {OperationSystemType}, дата выпуска: {MarketLaunchDate}, " +
                $"стоимость: {Price}, магазин: {Program.Shops.ShopByNumber(ShopId)}\n");
        }
    }

    public class Shop
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private int _id;
        private string _name;
        private string _description;
        private List<Phone> _phones;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public List<Phone> Phones { get => _phones; set => _phones = value; }

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
        private List<Shop> _shops;

        public List<Shop> Shops { get => _shops; set => _shops = value; }

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

                    Program.FoundPhones = found;

                    if (Program.FoundPhones.Count == 0)
                    {
                        logger.Info("Введенный Вами товар не найден");
                    }

                    var inStorage = Program.FoundPhones.Find(p => p.IsAvailable);

                    if (inStorage == null)
                    {
                        logger.Info("Данный товар отсутствует на складе.");
                        throw new PhoneNotFoundException("Пожалуйста, введите модель телефона заново.");
                    }
                    else
                    {
                        var successfulRequest = Program.FoundPhones.FindAll(p => p.IsAvailable);
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
