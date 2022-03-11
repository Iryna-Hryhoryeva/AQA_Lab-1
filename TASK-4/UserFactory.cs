namespace Persons;

public class UserFactory
{
    public User UserObject()
    {
        string input;

        Console.WriteLine("Введите тип пользователя: Employee или Candidate");
        input = Console.ReadLine();

        switch (input)
        {
            case "Candidate":
                var newCandidate = new Candidate();

                Console.WriteLine("Создан экземпляр класса Candidate");
                return newCandidate;
            case "Employee":
                var newEmployee = new Employee();

                Console.WriteLine("Создан экземпляр класса Employee");
                return newEmployee;
            default:
                Console.WriteLine("Неизвестный тип пользователя");
                return null;
        }

    }
}
