namespace Persons;

public class UserFactory
{
    public static User ReturnGeneratedTypeOfUser()
    {
        Console.WriteLine("Введите тип пользователя: Employee или Candidate");
        var typeOfUser = Console.ReadLine();

        if (typeOfUser == "Employee")
        {
            return (User)new Employee();
        }
        else
        {
            return (User)new Candidate();
        }
    }
}
