using NLog;
using TASK_6.Exceptions;

namespace TASK_6;

[Serializable]
public class JsonShops
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
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
                _logger.Info($"В каком магазине вы хотите приобрести {phoneChoice}?");
                shopChoice = Console.ReadLine();
                _logger.Info(shopChoice);
                
                var foundShop = Shops.Find(s => s.Name == shopChoice);
                if (foundShop != null)
                {
                    return foundShop;
                }

                _logger.Info("Такого магазина не существует.");
                try
                {
                    throw new StoreNotFoundException(message: "Пожалуйста, введите название магазина заново:");
                }
                catch (Exception e)
                {
                    _logger.Info(e);
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
                    _logger.Info("Какой телефон вы желаете приобрести? ");
                    phoneChoice = Console.ReadLine();
                    _logger.Info(phoneChoice);

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
                        _logger.Info("Введенный Вами товар не найден");
                    }

                    var inStorage = Program.FoundPhones.Find(p => p.IsAvailable);

                    if (inStorage == null)
                    {
                        _logger.Info("Данный товар отсутствует на складе.");
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
                    _logger.Info(e.Message);
                }
            } while (true);

            return phoneChoice;
        }
    }
