using Bogus;

namespace Persons;

public class PersonsRepository
{
    private readonly string[] companyNames = { "Z", "Apple", "Yandex", "Google" };
    private readonly string[] desiredPositions = { "Dynamic Identity Engineer",
      "Dynamic Intranet Facilitator","Global Creative Engineer", "Internal Markets Agent", "International Accounts Representative" };

    public IEnumerable<Candidate> GetCandidates(List<Candidate> listOfObjects)
    {
        var candidateGenerator = new Faker<Candidate>()
            .RuleFor(c => c.Id, Guid.NewGuid())
            .RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.Surname, (f, c) => f.Name.LastName())
            .RuleFor(c => c.DesiredPosition, f => f.PickRandom(desiredPositions))
            .RuleFor(c => c.PositionDescription, (f, c) => f.Name.JobDescriptor())
            .RuleFor(c => c.DesiredSalary, f => f.Random.Double(500, 10000));
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
            .RuleFor(e => e.Salary, f => f.Random.Double(500, 10000))
            .RuleFor(e => e.CompanyName, f => f.PickRandom(companyNames))
            .RuleFor(e => e.CompanyAddress, f => f.Address.FullAddress())
            .RuleFor(e => e.CompanyCity, f => f.Address.City())
            .RuleFor(e => e.CompanyCountry, f => f.Address.Country());
        return employeeGenerator.Generate(listOfObjects.Count);
    }
}
