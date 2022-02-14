using Bogus;

namespace Persons;

public class PersonsRepository
{
    public IEnumerable<Candidate> GetCandidates(List<Candidate> listOfObjects)
    {
        // Randomizer.Seed = new Random(123456);

        var candidateGenerator = new Faker<Candidate>()
            .RuleFor(c => c.Id, Guid.NewGuid())
            .RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.Surname, (f, c) => f.Name.LastName())
            .RuleFor(c => c.DesiredPosition, (f, c) => f.Name.JobTitle())
            .RuleFor(c => c.PositionDescription, (f, c) => f.Name.JobDescriptor())
            .RuleFor(o => o.DesiredSalary, f => f.Random.Double(0, 10000));
        return candidateGenerator.Generate(listOfObjects.Count);
    }

    public IEnumerable<Employee> GetEmployees(List<Employee> listOfObjects)
    {
        var employeeGenerator = new Faker<Employee>()
            .RuleFor(o => o.Id, Guid.NewGuid)
            .RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.Surname, (f, c) => f.Name.LastName())
            // .RuleFor(o => o.Date, f => f.Date.Past(3))
            .RuleFor(c => c.Position, (f, c) => f.Name.JobTitle())
            .RuleFor(c => c.PositionDescription, (f, c) => f.Name.JobDescriptor())
            .RuleFor(o => o.Salary, f => f.Random.Double(0, 10000))
            // .RuleFor(o => o.Shipped, f => f.Random.Bool(0.9f));
            .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
            .RuleFor(c => c.CompanyAddress, f => f.Address.FullAddress())
            .RuleFor(c => c.CompanyCity, f => f.Address.City())
            .RuleFor(c => c.CompanyCountry, f => f.Address.Country());
        return employeeGenerator.Generate(listOfObjects.Count);
    }
}