using TASK_4.Persons;
using TASK_4.Reporters;
using TASK_4.Utils;

namespace TASK_4;

public class Program
{
    public static void Main(string[] args)
    {
        var (emptyListOfCandidates, emptyListOfCEmployees) = CreateEmptyListsOfCandidatesAndEmployees();

        var (candidates, employees) = FillInCreatedLists(emptyListOfCandidates, emptyListOfCEmployees);

        ShowCandidatesAndEmployeesInfo(candidates, employees);
        PressKeyToContinue();

        ReportOnCandidates(candidates);
        PressKeyToContinue();

        ReportOnEmployees(employees);
    }

    public static Tuple<List<Candidate>, List<Employee>> CreateEmptyListsOfCandidatesAndEmployees()
    {
        var listOfObjectsCandidates = new List<Candidate>();
        var listOfObjectsEmployees = new List<Employee>();
        for (var i = 0; i < RandomUtils.NumberOfObjects; i++)
        {
            var candidate = new Candidate();
            listOfObjectsCandidates.Add(candidate);

            var employee = new Employee();
            listOfObjectsEmployees.Add(employee);
        }

        return Tuple.Create(listOfObjectsCandidates, listOfObjectsEmployees);
    }

    public static Tuple<IEnumerable<Candidate>, IEnumerable<Employee>> FillInCreatedLists(
        List<Candidate> listOfObjectsCandidates,
        List<Employee> listOfObjectsEmployees)
    {
        var repository = new BogusRepository();
        var candidates = repository.GetCandidates(listOfObjectsCandidates);
        var employees = repository.GetEmployees(listOfObjectsEmployees);
        Console.WriteLine();

        return Tuple.Create(candidates, employees);
    }

    public static void ShowCandidatesAndEmployeesInfo(IEnumerable<Candidate> candidates,
        IEnumerable<Employee> employees)
    {
        const int userNumberInTheList = 0;
        candidates.ElementAt(userNumberInTheList).ShowUserInfo();
        employees.ElementAt(userNumberInTheList).ShowUserInfo();
        Console.WriteLine();
    }

    public static void ReportOnEmployees(IEnumerable<Employee> employees)
    {
        var reportEmployees = new EmployeeReportGenerator(employees);
        Console.WriteLine("List of employees:");
        reportEmployees.Report();
        Console.WriteLine();
    }

    public static void ReportOnCandidates(IEnumerable<Candidate> candidates)
    {
        var reportCandidates = new CandidateReportGenerator(candidates);
        Console.WriteLine("List of candidates:");
        reportCandidates.Report();
        Console.WriteLine();
    }

    public static void PressKeyToContinue()
    {
        Console.WriteLine("Press any key to continue.\n");
        Console.ReadKey();
    }
}
