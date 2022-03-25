using Bogus;

namespace TASK;

public class BogusRepository
{
    private enum _vehicleModels
    {
        BMW,
        VW
    };

    public IEnumerable<Person> GetPersons(int number)
    {
        var personGenerator = new Faker<Person>()
            .CustomInstantiator(f => new Person(f.Name.FirstName(), f.Name.LastName(), f.Date.PastDateOnly(90)));
        return personGenerator.Generate(number);
    }

    public IEnumerable<DrivingLicense> GetDrivingLicenses(int number)
    {
        var drivingLicenseGenerator = new Faker<DrivingLicense>()
            .CustomInstantiator(f => new DrivingLicense(f.Date.PastDateOnly(10), f.Random.Guid()));
        return drivingLicenseGenerator.Generate(number);
    }

    public IEnumerable<Vehicle> GetVehicles(int number)
    {
        var vehicleGenerator = new Faker<Vehicle>()
            .CustomInstantiator(f => new Vehicle(f.PickRandom<_vehicleModels>().ToString(), f.Random.Int(1950, 2022),
                new Engine(f.Random.Int(45, 65), f.Random.Int(120, 300),
                    f.Random.Int(5, 13), f.Vehicle.Fuel(), f.Random.Int(80, 150))));
        return vehicleGenerator.Generate(number);
    }
}
