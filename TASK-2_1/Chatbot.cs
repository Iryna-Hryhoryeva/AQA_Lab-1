using System.Text.RegularExpressions;

namespace Task2_1;

public class Chatbot
{
    public Chatbot(string userSurname, string userName, DateTime date)
    {
        UserSurname = userSurname;
        UserName = userName;
        Date = date;
    }

    private string UserSurname { get; set; }
    private string UserName { get; set; }
    private DateTime Date { get; set; }

    public static string InputName(string username)
    {
        string name;
        const string pattern = @"\d*\s*\W*";
        var regex = new Regex(pattern);

        do
        {
            Console.Write("Введите Ваш" + (username == "surname" ? "у фамилию: " : "е имя: "));
            name = Console.ReadLine();
            name = regex.Replace(name, "");
        } while (String.IsNullOrEmpty(name));

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
            try
            {
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
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
