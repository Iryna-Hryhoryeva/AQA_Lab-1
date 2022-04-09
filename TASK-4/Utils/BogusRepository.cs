using Bogus;
using TASK_4.Persons;

namespace TASK_4.Utils;

public class BogusRepository
{
    private int _startNumber = 500;
    private int _endNumber = 10000;

    public IEnumerable<Candidate> GetCandidates(List<Candidate> listOfObjects)
    {
        var candidateGenerator = new Faker<Candidate>()
            .RuleFor(c => c.Id, Guid.NewGuid())
            .RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.Surname, (f, c) => f.Name.LastName())
            .RuleFor(c => c.DesiredPosition, f => f.Name.JobTitle())
            .RuleFor(c => c.PositionDescription, (f, c) => f.Name.JobDescriptor())
            .RuleFor(c => c.DesiredSalary, f => f.Random.Double(_startNumber, _endNumber));

        return candidateGenerator.Generate(listOfObjects.Count);
    }

    public IEnumerable<Employee> GetEmployees(List<Employee> listOfObjects)
    {
        var employeeGenerator = new Faker<Employee>()
            .RuleFor(e => e.Id, Guid.NewGuid)
            .RuleFor(e => e.Name, (f, e) => f.Name.FirstName())
            .RuleFor(e => e.Surname, (f, e) => f.Name.LastName())
            .RuleFor(e => e.Position, (f, e) => f.Name.JobTitle())
            .RuleFor(e => e.PositionDescription, (f, e) => f.Name.JobDescriptor())
            .RuleFor(e => e.Salary, f => f.Random.Double(_startNumber, _endNumber))
            .RuleFor(e => e.CompanyName, f => f.Company.CompanyName())
            .RuleFor(e => e.CompanyAddress, f => f.Address.FullAddress())
            .RuleFor(e => e.CompanyCity, f => f.Address.City())
            .RuleFor(e => e.CompanyCountry, f => f.Address.Country());

        return employeeGenerator.Generate(listOfObjects.Count);
    }
}
