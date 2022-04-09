namespace Persons;

public class Program
{
    public static void Main(string[] args)
    {
        var (emptyListOfCandidates, emptyListOfCEmployees) = CreateEmptyListsOfCandidatesAndEmployees();

        var (candidates, employees) = FillInCreatedLists(emptyListOfCandidates, emptyListOfCEmployees);

        ShowCandidatesAndEmployeesInfo(candidates, employees);
        
        ReportOnCandidates(candidates);
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
        var repository = new PersonsRepository();
        var candidates = repository.GetCandidates(listOfObjectsCandidates);
        var employees = repository.GetEmployees(listOfObjectsEmployees);
        Console.WriteLine();

        return Tuple.Create(candidates, employees);
    }

    public static void ShowCandidatesAndEmployeesInfo(IEnumerable<Candidate> candidates,
        IEnumerable<Employee> employees)
    {
        candidates.ElementAt(0).ShowUserInfo();
        employees.ElementAt(0).ShowUserInfo();
        Console.WriteLine();
    }

    public static void ReportOnEmployees(IEnumerable<Employee> employees)
    {
        var reportEmployees = new EmployeeReportGenerator(employees);
        reportEmployees.Report();
        Console.WriteLine();
    }

    public static void ReportOnCandidates(IEnumerable<Candidate> candidates)
    {
        var reportCandidates = new CandidateReportGenerator(candidates);
        reportCandidates.Report();
        Console.WriteLine();
    }
}
