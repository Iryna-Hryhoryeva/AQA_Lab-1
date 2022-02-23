using Persons;

var random = new Random();

var numberOfObjects = random.Next(5, 20);

List<Candidate> listOfObjectsCandidates = new List<Candidate>();
List<Employee> listOfObjectsEmployees = new List<Employee>();
for (int i = 0; i < numberOfObjects; i++)
{
    var candidate = new Candidate();
    
    listOfObjectsCandidates.Add(candidate);
    var employee = new Employee();
    
    listOfObjectsEmployees.Add(employee);
}

// заполненение первичных данных из библиотеки
var repository = new PersonsRepository();

var candidates = repository.GetCandidates(listOfObjectsCandidates);

var employees = repository.GetEmployees(listOfObjectsEmployees);

Console.WriteLine("\n");

candidates.ElementAt(0).ShowUserInfo();

Console.WriteLine("\n");

var reportEmployees = new EmployeeReportGenerator(employees);
reportEmployees.Report();

Console.WriteLine("\n");
var reportCandidates = new CandidateReportGenerator(candidates);

reportCandidates.Report();

Console.WriteLine("\n");
var userFactory = new UserFactory();

userFactory.UserObject();
