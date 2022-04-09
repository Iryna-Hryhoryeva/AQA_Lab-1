using TASK_4.Persons;
using TASK_4.Reporters;
using TASK_4.Utils;

namespace TASK_4;

public class UserFactory
{
    public static void ShowNewUsers(UserTypes userType)
    {
        var newUsers = UserGenerator(userType);
        switch (userType)
        {
            case UserTypes.Employee:
                var newEmployees = newUsers.Cast<Employee>().ToList();

                var newEmployeesReport = new EmployeeReportGenerator(newEmployees);
                Console.WriteLine("List of new employees:");
                newEmployeesReport.Report();
                break;

            case UserTypes.Candidate:
                var newCandidates = newUsers.Cast<Candidate>().ToList();

                var newCandidatesReport = new CandidateReportGenerator(newCandidates);
                Console.WriteLine("List of new candidates:");
                newCandidatesReport.Report();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(userType), userType, "Неизвестный тип пользователя.");
        }
    }

    public static List<User> UserGenerator(UserTypes userType)
    {
        Console.Write("Please, enter the required number of new users: ");
        var numberOfUsers = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        var repository = new BogusRepository();
        switch (userType)
        {
            case UserTypes.Employee:
                var listOfEmployees = new List<Employee>(numberOfUsers);
                for (int i = 0; i < numberOfUsers; i++)
                {
                    listOfEmployees.Add(new Employee());
                }

                var iEnumerableEmployees = repository.GetEmployees(listOfEmployees);
                listOfEmployees = iEnumerableEmployees.ToList();
                var usersEmployees = new List<User>(listOfEmployees);

                return usersEmployees;

            case UserTypes.Candidate:
                var listOfCandidates = new List<Candidate>(numberOfUsers);
                for (int i = 0; i < numberOfUsers; i++)
                {
                    listOfCandidates.Add(new Candidate());
                }

                var iEnumerableCandidates = repository.GetCandidates(listOfCandidates);
                listOfCandidates = iEnumerableCandidates.ToList();
                var usersCandidates = new List<User>(listOfCandidates);

                return usersCandidates;

            default:
                throw new ArgumentOutOfRangeException(nameof(userType), userType, "Неизвестный тип пользователя.");
        }
    }
}
