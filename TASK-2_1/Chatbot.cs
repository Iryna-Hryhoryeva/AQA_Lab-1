using System.Text.RegularExpressions;

namespace Task2_1;

public class Chatbot
{
    public string UserName { get; set; }
    public string UserSurname { get; set; }

    public DateTime Date { get; set; }

    public static string InputName(int nameType)
    {
        string name;
        const string pattern = @"\d*\s*\W*";
        const string target = "";
        var regex = new Regex(pattern);

        do
        {
            Console.Write("Введите Ваш" + (nameType == 1 ? "у фамилию: " : "е имя: "));
            name = Console.ReadLine();
            name = regex.Replace(name, target);
        } while (name == ""); // проверка на пустую строку

        name = name.Substring(0, 1).ToUpper() + name.Substring(1);

        return name;
    }

    public static DateTime InputDate()
    {
        var currentDate = DateTime.Today;
        var date = new DateTime();
        int comparisonResult;
        var message = "Введите дату в формате дд/мм/гггг: ";
        do
        {
            Console.Write(message);
            try // обработка ошибок
            {
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e) // сюда попадает в случае ошибки
            {
                Console.WriteLine("Введена некорректная дата (" + e.Message + ")");
                message = "Пожалуйста, введите актуальную дату в формате дд/мм/гггг: ";
            }

            comparisonResult = DateTime.Compare(date, currentDate);
        } while (comparisonResult <= 0);

        return date;
    }

    public static void ShowResult(Chatbot ticket, string time)
    {
        Console.WriteLine(
            $"{ticket.UserSurname} {ticket.UserName}, Вы записаны на прием {ticket.Date.ToString("d")}, {time}");
    }
}
